using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZebraChecker : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.CompareTag("Player"))
        {
            if (GetComponentInParent<TrafficSignal>().Signalindex == 1 || GetComponentInParent<TrafficSignal>().Signalindex == 2)
            {
                AlertHandler.Instance.OnShowPopUp("Zebra Crossing Rule not followed.", Color.red);
            }
            else if (GetComponentInParent<TrafficSignal>().Signalindex == 3)
            {
                AlertHandler.Instance.OnShowPopUp("Zebra Crossing Rule followed.", Color.green);
            }

        }
    }
}
