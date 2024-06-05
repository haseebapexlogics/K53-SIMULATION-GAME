using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceMaintainTrigger : MonoBehaviour
{
    public bool EntryPoint;
    public bool ExitPoint;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent.CompareTag("Player"))
        {
            if (EntryPoint)
            {
                transform.GetComponent<BoxCollider>().enabled = false;
                if (other.transform.parent.GetComponent<DIstanceMaintainCheck>())
                {
                    
                    other.transform.parent.GetComponent<DIstanceMaintainCheck>().enabled = true;
                }
            }
            if (ExitPoint)
            {
                transform.GetComponent<BoxCollider>().enabled = false;
                if (other.transform.parent.GetComponent<DIstanceMaintainCheck>())
                {
                    Debug.Log("punnn");
                    other.transform.parent.GetComponent<DIstanceMaintainCheck>().enabled = false;
                    AlertHandler.Instance.OnShowPopUp("You Maintain Proper Distance",Color.green);
                }

            }
            
        }
    }
}
