using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkingTrigger : MonoBehaviour
{
    public bool PlayerTouchingTrigger;
    public bool MainArea;
    public bool ExitPont;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (MainArea)
        {
            if (other.transform.root.transform.CompareTag("Player"))
            {
                transform.parent.GetComponent<ParkingCheck>().OnStyingTrigger();
            }
        }
        if (ExitPont)
        {
            GetComponent<BoxCollider>().enabled = false;
            transform.parent.GetComponent<ParkingCheck>().OnHittingExitPoint();
        }
      
    }
    private void OnTriggerExit(Collider other)
    {
        if (MainArea)
        {
            if (other.transform.root.transform.CompareTag("Player"))
            {
                transform.parent.GetComponent<ParkingCheck>().OnExitingTrigger();
            }
        }
       
    }
}
