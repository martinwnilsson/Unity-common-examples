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
        float moveX = speed *Input.GetAxis("Horizontal") * Time.deltaTime;
        float moveZ = speed * Input.GetAxis("Vertical") * Time.deltaTime;

        Vector3 move = new Vector3(moveX, 0, moveZ);

        transform.Translate(move, Space.World);
    }
}
