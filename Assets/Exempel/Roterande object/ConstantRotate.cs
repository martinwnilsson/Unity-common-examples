using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantRotate : MonoBehaviour
{
    public float speed = 50f; //roterar 50 grader (som förval) per sekund

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, speed * Time.deltaTime, 0); //rotaterar speed runt y axeln (flytta speed för andra axlar)
    }
}
