using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineRuleImplementation : MonoBehaviour
{
    public GameObject EngineStartPanel;
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
        EngineStartPanel.SetActive(true);
    }

    public void ClickOnEngineBtn()
    {
        EngineStartPanel.SetActive(false);
        AlertHandler.Instance.OnShowPopUp("Engine Rule Followed",Color.green);
        GameManager.Instance.NumberOfControlsFollowed++;


    }
}
