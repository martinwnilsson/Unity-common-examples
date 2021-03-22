using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRigidbody : MonoBehaviour
{
    public float moveForce = 500f; // En kraft, svårt att veta hur stor, beror på objektstorlek och fysikmaterial, man får prova
    public float jumpForce = 50f; // En kraft, svårt att veta hur stor, beror på objektstorlek och fysikmaterial, man får prova
    public float maxSpeed = 5f; // units/s

    private bool isJumping = false;

    // en privat egenskap att spara RigidBody-komponenten i, fyiskkomponenten vi ska styra
    // Den styr i sin tur objektets transform (som vi styr direkt när vi flyttar utan fysik)
    private Rigidbody rb; 
    
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();    
    }

    // Fysik/Rigidbody-uppdatering bör göras i FixedUpdate som inte körs lika ofta som update
    // Rigidbody kommer fortfarande flytta på objektet vid varje vanlig update
    void FixedUpdate()
    {
        // Gör bara user-kraft-input om inte max hastiighet
        float speed = rb.velocity.magnitude;
        if(speed < maxSpeed)
        {
            rb.AddForce(Vector3.forward * moveForce * Input.GetAxis("Vertical") * Time.deltaTime);
            rb.AddForce(Vector3.right * moveForce * Input.GetAxis("Horizontal") * Time.deltaTime);
        }
        
        if (Input.GetKey(KeyCode.Space) && !isJumping)
        {
            //Apply a force to this Rigidbody in direction of this GameObjects up axis
            rb.AddForce(Vector3.up * jumpForce);
            // sätter att hopp pågår, så att man inte evighetshoppa i luften
            isJumping = true;
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        // när objektet "når" något (krockar), stäng av att hopp pågår
        if (isJumping == true)
        {
            isJumping = false;
        }
    }
}
