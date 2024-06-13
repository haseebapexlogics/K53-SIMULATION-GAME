using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseHornsControlTrigger : MonoBehaviour
{
    public bool EntryPoint;
    public bool ExitPoit;
    // Start is called before the first frame update
    private void Start()
    {
        UseHornsControl.Instance.HornBtn.SetActive(true);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.tag == "Player")
        {
            if (EntryPoint)
            {
               
                GetComponent<BoxCollider>().enabled = false;
                UseHornsControl.Instance.HornRuleCheck = true;


            }
            if (ExitPoit)
            {
                GetComponent<BoxCollider>().enabled = false;
                UseHornsControl.Instance.OnReachingEndPoint();


            }

        }
    }
}
