using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficSignalCheckerChowk : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.CompareTag("Player"))
        {
            if (GetComponentInParent<TrafficSignalC>().Signalindex == 1 || GetComponentInParent<TrafficSignalC>().Signalindex == 2)
            {
                AlertHandler.Instance.OnShowPopUp("Signal Rule not followed.", Color.red);
            }
            else if (GetComponentInParent<TrafficSignalC>().Signalindex == 3)
            {
                AlertHandler.Instance.OnShowPopUp("Signal Rule followed.", Color.green);
            }
            this.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
