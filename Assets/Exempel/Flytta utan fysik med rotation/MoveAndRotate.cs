using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAndRotate : MonoBehaviour
{
    public float moveSpeed = 3f; // units/s
    public float steerSpeed = Mathf.PI; // radians/s - hur mycket vinkeln kan ändras/s    

    private float steerAngle = 0; // aktuell förflyttningsvinkel i radianer

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // ändrar hastighetsriktning med input-horizontal
        steerAngle = steerAngle + (Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime);

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

        // steerSpeed (length) och steerAngle (vinkel) på en triangel
        // där dX och dZ (XZ är markplan i Unity) - som ska adderas på positionen - är katetrarna
        float dX = Mathf.Sin(steerAngle) * speed * Time.deltaTime;
        float dZ = Mathf.Cos(steerAngle) * speed * Time.deltaTime;

        // hämtar nuvarande position
        Vector3 orgPosition = transform.position;
        // Skapa positions-vektor att addera till nuvarande position
        Vector3 addPosition = new Vector3(dX, 0, dZ);
        // skapar ny position och uppdaterar
        Vector3 newPosition = orgPosition + addPosition;

        // roterar efter aktuell riktning, "tittar" mot ny position
        transform.LookAt(newPosition);
        
        // "lägger in" nya positionen
        transform.position = newPosition;
    }
}
