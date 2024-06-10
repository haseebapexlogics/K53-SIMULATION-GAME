using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberPlateChecker : MonoBehaviour
{
    public GameObject NumberPlateBtn;

    public GameObject CorrectNoPlate;

    public GameObject WrongNoPlate;


    bool once = false;

    public void NumberPlateBtnClicked()
    {
        if (!once)
        {
            AlertHandler.Instance.OnShowPopUp("Road Rule Followed", Color.green);
            GameManager.Instance.NumberOfRulesFollowed++;
            NumberPlateBtn.SetActive(false);
            CorrectNoPlate.SetActive(true);
            WrongNoPlate.SetActive(false);

            once = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.CompareTag("Player"))
        {
            if (!once)
            {
                AlertHandler.Instance.OnShowPopUp("Road Rule Not Followed", Color.red);
            }
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
            NumberPlateBtn.SetActive(false);

        }
    }
}
