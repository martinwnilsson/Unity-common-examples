using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHuntOther : MonoBehaviour
{
    public Transform target;

    public float moveSpeed = 3f; // units/s - jakt-hastighet
    public float steerSpeed = Mathf.PI; // radians/s - hur mycket hastighetsvinkeln kan ändras/s    
    public float aggroDistance = 10f;

    private Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = startPosition;


        if (Vector3.Distance(transform.position, target.position) < aggroDistance)
        {
            targetPosition = target.position;
        }
        
        float moveStep = moveSpeed * Time.deltaTime;

        Vector3 newPosition = Vector3.MoveTowards(transform.position, targetPosition, moveStep);
        transform.position = newPosition;
        transform.LookAt(targetPosition);



    }
}
