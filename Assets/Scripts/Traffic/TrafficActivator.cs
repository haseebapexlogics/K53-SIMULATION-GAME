using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SWS;

public class TrafficActivator : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.CompareTag("Player"))
        {
            Debug.Log("Here");
        }
        for (int i = 0; i< GetComponentInParent<TrafficSignalC>().TrafficCars.Length; i++)
        {
            GetComponentInParent<TrafficSignalC>().TrafficCars[i].GetComponent<TrafficAI>().Movement = true;
            GetComponentInParent<TrafficSignalC>().TrafficCars[i].GetComponent<splineMove>().StartMove();
        }
    }
}
