using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingingCallUI : MonoBehaviour
{
    public static RingingCallUI Instance;
    public GameObject PhoneUI;
    public bool CheckFunctionality;

    public bool DontCheck;
    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    public void ShowCallPanel()
    {
        PhoneUI.SetActive(true);
    }
    public void HideCallPanel()
    {
        PhoneUI.SetActive(false);
    }

    public void ClickOnAcceptBtn()
    {
        CheckFunctionality = false;
        PhoneUI.SetActive(false);
        DontCheck = true;
        AlertHandler.Instance.OnShowPopUp("Road Rules Not Followed", Color.red);
    }
    public void ClickOnRejectBtn()
    {
        if (CheckFunctionality)
        {
            CheckFunctionality = false;
            PhoneUI.SetActive(false);
            DontCheck = true;
            AlertHandler.Instance.OnShowPopUp("Road Rules Followed",Color.green);
            GameManager.Instance.NumberOfRulesFollowed++;
        }

    }
}
