using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentLaneTrigger : MonoBehaviour
{
    public bool AllowedArea;
    public bool NotAllowedArea;
    public bool EntryPoint;
    public bool ExitPoint;
    // Start is called before the first frame update
    void Start()
    {
        if (EntryPoint)
        {
            transform.parent.GetComponent<LaneCheckerTrigger>().EntryPoint = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.CompareTag("Player"))
        {
           
            if (EntryPoint)
            {         
                transform.parent.GetComponent<LaneCheckerTrigger>().EntryPoint = true;
                GetComponent<BoxCollider>().enabled = false;
            }
            if (NotAllowedArea)
            {
                transform.parent.GetComponent<LaneCheckerTrigger>().NotAllowedArea = true;
                GetComponent<BoxCollider>().enabled = false;
            }
            if (AllowedArea)
            {
                transform.parent.GetComponent<LaneCheckerTrigger>().AllowedArea = true;
                //GetComponent<BoxCollider>().enabled = false;
            }
            if (ExitPoint)
            {
                transform.parent.GetComponent<LaneCheckerTrigger>().EndOfTrigger = true;
                GetComponent<BoxCollider>().enabled = false;
            }
            transform.parent.GetComponent<LaneCheckerTrigger>().OnTrigger();
        }
        
        
    }
}
