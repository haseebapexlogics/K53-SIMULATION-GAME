using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccidentalChecker : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.CompareTag("Player"))
        {
            if (AccidentalTraffic.Instance.isAccidentalTrafficOn)
            {
                AlertHandler.Instance.OnShowPopUp("Road Rule Followed", Color.green);
                GameManager.Instance.NumberOfRulesFollowed++;
            }
        }
    }
}
