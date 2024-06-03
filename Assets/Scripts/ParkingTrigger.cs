using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkingTrigger : MonoBehaviour
{
    public bool PlayerTouchingTrigger;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.transform.parent.transform.CompareTag("Player"))
        {
            transform.parent.GetComponent<ParkingCheck>().OnStyingTrigger();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.parent.transform.CompareTag("Player"))
        {
            transform.parent.GetComponent<ParkingCheck>().OnExitingTrigger();
        }
    }
}
