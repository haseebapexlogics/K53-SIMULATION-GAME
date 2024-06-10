using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZebraCheckerC : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.CompareTag("Player"))
        {
            if (GetComponentInParent<TrafficSignalC>().Signalindex == 1 || GetComponentInParent<TrafficSignalC>().Signalindex == 2)
            {
                AlertHandler.Instance.OnShowPopUp("Road Rule not Followed", Color.red);
            }
            else if (GetComponentInParent<TrafficSignalC>().Signalindex == 3)
            {
                AlertHandler.Instance.OnShowPopUp("Road Rule Followed", Color.green);
                GameManager.Instance.NumberOfRulesFollowed++;
            }

            this.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
