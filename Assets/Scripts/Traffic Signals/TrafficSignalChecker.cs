using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficSignalChecker : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent.CompareTag("Player"))
        {
            if (GetComponentInParent<TrafficSignal>().Signalindex == 1 || GetComponentInParent<TrafficSignal>().Signalindex == 2)
            {
                AlertHandler.Instance.OnShowPopUp("Signal Rule not followed." , Color.red);
            }
            else if (GetComponentInParent<TrafficSignal>().Signalindex == 3)
            {
                AlertHandler.Instance.OnShowPopUp("Signal Rule followed.", Color.green);
            }
        }
    }
}
