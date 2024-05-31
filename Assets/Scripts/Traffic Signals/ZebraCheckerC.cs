using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZebraCheckerC : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent.CompareTag("Player"))
        {
            if (GetComponentInParent<TrafficSignalC>().Signalindex == 1 || GetComponentInParent<TrafficSignalC>().Signalindex == 2)
            {
                AlertHandler.Instance.OnShowPopUp("Zebra Crossing Rule not followed.", Color.red);
            }
            else if (GetComponentInParent<TrafficSignalC>().Signalindex == 3)
            {
                AlertHandler.Instance.OnShowPopUp("Zebra Crossing Rule followed.", Color.green);
            }

        }
    }
}
