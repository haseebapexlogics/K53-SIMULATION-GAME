using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZebraCheckerT : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent.CompareTag("Player"))
        {
            if (GetComponentInParent<TrafficSignalT>().Signalindex == 1 || GetComponentInParent<TrafficSignalT>().Signalindex == 2)
            {
                AlertHandler.Instance.OnShowPopUp("Zebra Crossing Rule not followed.", Color.red);
            }
            else if (GetComponentInParent<TrafficSignalT>().Signalindex == 3)
            {
                AlertHandler.Instance.OnShowPopUp("Zebra Crossing Rule followed.", Color.green);
            }

        }
    }
}
