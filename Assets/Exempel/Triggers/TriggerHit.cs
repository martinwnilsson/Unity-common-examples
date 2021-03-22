using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerHit : MonoBehaviour
{
    private Vector3 orgPosition; // privat egenskap att spara spelarens originalsposition i
    
    // Start is called before the first frame update
    void Start()
    {
        orgPosition = transform.position; // sparar originalposition
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Skapar metoden 'OnTriggerEnter' som körs när en trigger händer (börjar, finns för slutar och håller på också)
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger happend");
        if(other.tag == "good")
        {
            Debug.Log("Colliding with good");
            Destroy(other.gameObject);
        }
        if (other.tag == "bad")
        {
            Debug.Log("Colliding with bad");
            // återställer spelarens position
            transform.position = orgPosition;
        }
    }
}
