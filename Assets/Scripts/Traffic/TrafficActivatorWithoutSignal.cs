using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SWS;
public class TrafficActivatorWithoutSignal : MonoBehaviour
{
    public GameObject[] AICars;
    public GameObject[] Waypoints;

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.CompareTag("Player"))
        {
            GetComponent<BoxCollider>().enabled = false;
            for (int i = 0; i < AICars.Length; i++)
            {
                AICars[i].SetActive(true);
                AICars[i].GetComponent<TrafficAI>().Movement = true;
                AICars[i].GetComponent<splineMove>().StartMove();
            }
            for (int i = 0; i < Waypoints.Length; i++)
            {
                Waypoints[i].SetActive(true);
            }
        }
    }
}
