using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SWS;

public class TrafficStopper : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("TrafficVehicle"))
        {
            if (other.gameObject.GetComponentInParent<TrafficSignalC>().Signalindex == 1 || other.gameObject.GetComponentInParent<TrafficSignalC>().Signalindex == 2)
            {
                other.gameObject.GetComponent<TrafficAI>().Movement = false;
            }
            else
            {
                other.gameObject.GetComponent<TrafficAI>().Movement = true;
            }
        }
    }
}
