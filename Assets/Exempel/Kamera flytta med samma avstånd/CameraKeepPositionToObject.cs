using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraKeepPositionToObject : MonoBehaviour
{
    public Transform target;
    private Vector3 distanceVector;
    
    // Start is called before the first frame update
    void Start()
    {
        distanceVector = transform.position - target.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = target.position + distanceVector;
        transform.position = newPosition;
    }
}
