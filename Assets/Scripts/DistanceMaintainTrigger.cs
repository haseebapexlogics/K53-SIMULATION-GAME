using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceMaintainTrigger : MonoBehaviour
{
    public bool EntryPoint;
    public bool ExitPoint;
    public bool Rule;
    public bool Sign;
    public string FollowString;
    public string UnFollowString;
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
                    other.transform.parent.GetComponent<DIstanceMaintainCheck>().StopChecking = false;
                }
            }
            if (ExitPoint)
            {
                transform.GetComponent<BoxCollider>().enabled = false;
                if (other.transform.parent.GetComponent<DIstanceMaintainCheck>().isActiveAndEnabled)
                {
                    Debug.Log("punnn");
                    other.transform.parent.GetComponent<DIstanceMaintainCheck>().enabled = false;
                    AlertHandler.Instance.OnShowPopUp(FollowString,Color.green);
                    if (Rule)
                    {
                        GameManager.Instance.NumberOfRulesFollowed++;
                    }
                    if (Sign)
                    {
                        GameManager.Instance.NumberOfSignsFollowed++;
                    }
                }

            }
            
        }
    }
}
