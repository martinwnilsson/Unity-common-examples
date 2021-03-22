using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpReciever : MonoBehaviour
{
    public float spawnHeight = 0; // vilket y ovanför recievern warpade object ska flyttas till. Läses av WarpTriggern

    [HideInInspector] // ska vara public, men vill inte visa i inspector
    public bool isRecieving = false; // sätts till true av en Warp Trigger som skickar hit, för att en local Warp Trigger inte direkt ska skicka vidare/tillbaka 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Körs när ett objekt lämnar triggern
    private void OnTriggerExit(Collider other)
    {
        // Ställer isRecieving till false (igen) om den var true, så lokal Warp Trigger ska reagera igen
        if (isRecieving)
        {
            isRecieving = false;
        }
    }
}
