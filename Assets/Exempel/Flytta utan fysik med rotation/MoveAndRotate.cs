using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAndRotate : MonoBehaviour
{
    public float moveSpeed = 3f; // units/s
    public float steerSpeed = 45f; // grader/s - hur mycket vinkeln kan ändras/s    

    //private float steerAngle = 0; // aktuell förflyttningsvinkel i radianer

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Tar fram en rotationsändring baserat på horisontell input och styr-hastighet
        float steerAngle = steerSpeed * (Input.GetAxis("Horizontal") * Time.deltaTime);
        // Rotate() roterar objekt X grader runt varje axel. Roterar runt Y (uppåt), 0 på övriga.
        transform.Rotate(0, steerAngle, 0);

        // förvald hastighet, stå stilla
        float speed = 0;
       

        // W är "gå-knapp" (default hastighet)
        if (Input.GetKey(KeyCode.W))
        {
            speed = moveSpeed;
        }

        // Shift (+W) är "sprint-knapp" (dubbla hastigheten)
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W))
        {
            speed = moveSpeed * 2;
        }

        // Translate() fungerar som Rotate() ovan, lägger till en förflyttningsposition till axlarna.
        // flyttar i objektets riktning 'forward' (z+), riktningen får den från rotationen ovan.
        // Vector3.forward = [0, 0, 1] och * t.ex 3 blir det [0, 0, 3] som läggs på nuvarande position
        // Space.self betyder "forward" (z+) är efter objektets lokala koordinatsystem och inte världens.
        Vector3 move = Vector3.forward * speed * Time.deltaTime;
        transform.Translate(move, Space.Self);
    }
}
