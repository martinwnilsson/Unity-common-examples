using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed = 5f; // units/s

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // läser av nuvarande
        Vector3 oldPosition = transform.position;
        
        //Hämta mängd horisontell input, värde 0-1
        //Vad det "Horizontal" och "Vertical" är för inputs ställs i Settings/input/axis, bl.a WASD som default
        float horizontalInput = Input.GetAxis("Horizontal");
        //Hämta mängd horisontell input, värde 0-1
        float verticalInput = Input.GetAxis("Vertical");

        // uppdaterar den nya positionen
        float horizontalToAdd = horizontalInput * speed * Time.deltaTime;
        float verticalToAdd = verticalInput * speed * Time.deltaTime;
        // skapar positionToAdd som uppdaterar X och Z (på "marken"), byt till X och Y om rörelse i "upp-ner"-planet
        Vector3 positionToAdd = new Vector3(horizontalToAdd, 0, verticalToAdd);

        transform.position = oldPosition + positionToAdd;
    }
}
