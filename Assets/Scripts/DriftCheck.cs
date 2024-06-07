using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DriftCheck : MonoBehaviour
{
    public static DriftCheck Instance;

    public GameObject DriftBtn;

    bool once = false;


    private void Start()
    {
        Instance = this;
    }
    

    
    public void DriftBtnClicked()
    {
        if (!once)
        {
            AlertHandler.Instance.OnShowPopUp("Road Rule Not Followed", Color.red);
            once = true;
        }

    }

    void DriftBtnNotClicked()
    {
        AlertHandler.Instance.OnShowPopUp("Road Rule Followed", Color.green);
        GameManager.Instance.NumberOfRulesFollowed++;

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.CompareTag("Player"))
        {
            if (!once)
            {
                DriftBtnNotClicked();
            }
            this.GetComponent<BoxCollider>().enabled = false;
            DriftBtn.SetActive(false);
        }
        
    }

}
