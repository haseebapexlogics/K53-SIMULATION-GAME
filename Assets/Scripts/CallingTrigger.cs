using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallingTrigger : MonoBehaviour
{
    public bool EntryPoint;
    public bool ExitPoint;
    // Start is called before the first frame update
    void Start()
    {
       

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.CompareTag("Player"))
        {
            if (EntryPoint)
            {
                transform.GetComponent<BoxCollider>().enabled = false;
                RingingCallUI.Instance.ShowCallPanel();
                RingingCallUI.Instance.CheckFunctionality = true;
            }
            if (ExitPoint)
            {
                transform.GetComponent<BoxCollider>().enabled = false;
                RingingCallUI.Instance.HideCallPanel();
                if (RingingCallUI.Instance.DontCheck==false)
                {
                    if (RingingCallUI.Instance.CheckFunctionality)
                    {
                        AlertHandler.Instance.OnShowPopUp("Road Rules Followed", Color.green);
                        GameManager.Instance.NumberOfRulesFollowed++;
                    }
                   
                }
            }

        }

        
    }
}
