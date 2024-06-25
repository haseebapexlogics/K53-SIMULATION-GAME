using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedLimitTigger : MonoBehaviour
{
    public bool EntryPoint;
    public bool ExitPoit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.CompareTag("Player"))
        {
            GetComponent<BoxCollider>().enabled = false;
            if (EntryPoint)
            {
                //Can be use for Hint Purpose
                transform.parent.GetComponent<SpeedLimitChecker>().OnTriggerStart(other.transform.root.gameObject);
            }
            if (ExitPoit)
            {
                transform.parent.GetComponent<SpeedLimitChecker>().OnTriggerEnd();
            }
        }
    }
}
