using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CarEngineTurnOff : MonoBehaviour
{
    public Button BreakBtn;

    public Button GasBtn;

    public Button DuplicateGasBtn;

    public GameObject CarSmoke;


    public GameObject HazardButton;

    bool HazardDone = false;


    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.CompareTag("Player"))
        {
            BreakBtn.GetComponent<RCC_UIController>().pressing = true;
            GasBtn.GetComponent<RCC_UIController>().pressing = false;
            GasBtn.GetComponent<RCC_UIController>().enabled = false;
            GasBtn.gameObject.SetActive(false);
            DuplicateGasBtn.gameObject.SetActive(true);
            CarSmoke.SetActive(true);



            HazardButton.GetComponent<Animation>().enabled = true;
            HazardButton.GetComponent<Animation>().Play();


            StartCoroutine(Timer());

        }
    }


    IEnumerator Timer()
    {
        yield return new WaitForSeconds(8f);
        CarSmoke.SetActive(false);
        if (!HazardDone)
        {
            AlertHandler.Instance.OnShowPopUp("Road Rule Not Followed", Color.red);
        }

        HazardButton.GetComponent<Animation>().Stop();
        HazardButton.GetComponent<Animation>().enabled = false;



        BreakBtn.GetComponent<RCC_UIController>().pressing = false;
        //GasBtn.GetComponent<RCC_UIController>().pressing = true;
        GasBtn.GetComponent<RCC_UIController>().enabled = true;
        GasBtn.gameObject.SetActive(true);
        DuplicateGasBtn.gameObject.SetActive(false);

        //yield return new WaitForSeconds(2f);
        //GasBtn.GetComponent<RCC_UIController>().pressing = false;
    }


    public void HazardButtonLevel2()
    {
        if (!HazardDone)
        {
            AlertHandler.Instance.OnShowPopUp("Road Rule Followed", Color.green);
            GameManager.Instance.NumberOfRulesFollowed++;

            HazardDone = true;
        }
    }



}
