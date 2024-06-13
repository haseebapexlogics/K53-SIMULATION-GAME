using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakAndIndicatorCheckTrigger : MonoBehaviour
{
    public bool EntryPoint;
    public bool ExitPoit;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.tag == "Player")
        {
            if (EntryPoint)
            {
                GetComponent<BoxCollider>().enabled = false;
                BreakAndIndicatorCheckUI.Instance.BreakCheckRuleCheck = true;


            }
            if (ExitPoit)
            {
                GetComponent<BoxCollider>().enabled = false;
                BreakAndIndicatorCheckUI.Instance.OnReachingEndPoint();


            }

        }
    }
}
