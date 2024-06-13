using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineRuleImplementation : MonoBehaviour
{
    public GameObject EngineStartPanel;
    bool CheckEngineRule;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("CurrentLevel") == 1 && PlayerPrefs.GetString("CurrentVehicle") == "LMV")
        {
            ApplyEngineRule();
        }
    }
    public void ApplyEngineRule()
    {
        CheckEngineRule = true;
        EngineStartPanel.SetActive(true);
    }

    public void ClickOnEngineBtn()
    {
        if (CheckEngineRule)
        {
            CheckEngineRule = false;
            EngineStartPanel.SetActive(false);
            AlertHandler.Instance.OnShowPopUp("Engine Rule Followed", Color.green);
            GameManager.Instance.NumberOfControlsFollowed++;
        }
       


    }
}
