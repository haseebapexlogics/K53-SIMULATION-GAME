using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CarEngineTurnOff : MonoBehaviour
{
    public Button BreakBtn;

    public Button GasBtn;

    public GameObject HazardButton;




    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.CompareTag("Player"))
        {
            BreakBtn.GetComponent<RCC_UIController>().pressing = true;
            GasBtn.GetComponent<RCC_UIController>().pressing = false;
            GasBtn.GetComponent<RCC_UIController>().enabled = false;

            HazardButton.GetComponent<Animation>().enabled = true;
            HazardButton.GetComponent<Animation>().Play();




        }
    }


    IEnumerator Timer()
    {
        yield return new WaitForSeconds(1f);

    }



}
