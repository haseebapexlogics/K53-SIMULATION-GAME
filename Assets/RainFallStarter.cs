using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainFallStarter : MonoBehaviour
{
    public GameObject WiperBtn;

    bool once = false;




    public void WiperBtnClicked()
    {
        if (!once)
        {
            AlertHandler.Instance.OnShowPopUp("Control Rule Followed", Color.green);
            GameManager.Instance.NumberOfControlsFollowed++;

            once = true;
        }
    }

    



    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.CompareTag("Player"))
        {
            if (!once)
            {
                AlertHandler.Instance.OnShowPopUp("Control Rule Not Followed", Color.red);
            }
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
            WiperBtn.SetActive(false);

        }
    }


   


}
