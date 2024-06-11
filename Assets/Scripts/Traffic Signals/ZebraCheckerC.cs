using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZebraCheckerC : MonoBehaviour
{
    public bool sign = false;
    public bool rule = false;

    public string FollowedString;
    public string NotFollowedString;



    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.CompareTag("Player"))
        {
            if (GetComponentInParent<TrafficSignalC>().Signalindex == 1 || GetComponentInParent<TrafficSignalC>().Signalindex == 2)
            {
                AlertHandler.Instance.OnShowPopUp(NotFollowedString, Color.red);
            }
            else if (GetComponentInParent<TrafficSignalC>().Signalindex == 3)
            {
                if (sign)
                {
                    AlertHandler.Instance.OnShowPopUp(FollowedString, Color.green);
                    GameManager.Instance.NumberOfSignsFollowed++;

                }
                else if (rule)
                {
                    AlertHandler.Instance.OnShowPopUp(FollowedString, Color.green);
                    GameManager.Instance.NumberOfRulesFollowed++;
                }
                
            }

            this.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
