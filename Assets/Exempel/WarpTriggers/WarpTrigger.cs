using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpTrigger : MonoBehaviour
{
    public WarpReciever targetWarpReciever; // Ett gameobject med en WarkReciever-skript/komponent på sig
    
    private WarpReciever localWarpReciever; // sparar eventuell reciever som sitter på denna trigger
    
    // Start is called before the first frame update
    void Start()
    {
        localWarpReciever = GetComponent<WarpReciever>(); // Hämtar eventuell reciever som sitter på detta objekt
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Skapar metoden 'OnTriggerEnter' som körs när en trigger händer (börjar, finns för slutar och håller på också)
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger happend");
        // Filter för att bara spelaren ska warpa (behöver inte vara så)
        if(other.tag == "Player")
        {
            if (localWarpReciever && localWarpReciever.isRecieving) // om det finns en lokalreciever och den håller på att ta emot
            {
                // något har precis warpat hit och triggern ska inte göra något
                // Här ska inget göras
            }
            else
            {
                Debug.Log("Warping");
                targetWarpReciever.isRecieving = true; // sätter till true för att inte eventuell trigger på reciever objektet ska dirket warpa vidare
                
                // läser av position av target reciever och lägger på spawn height.
                Vector3 warpPosition = targetWarpReciever.transform.position;
                warpPosition.y = warpPosition.y + targetWarpReciever.spawnHeight;
                // uppdaterar position för warpande object
                other.transform.position = warpPosition;
            }
        }
    }
}
