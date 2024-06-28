using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BikeStandSetting : MonoBehaviour
{
    public static BikeStandSetting Instance;

    public GameObject BikeStandBtn;
    public bool StopChecking;

    private void Awake()
    {
        Instance = this;
    }

    public void SetBikeStandTrue()
    {
        if (!StopChecking)
        {
            StandChecker.Instance.isStand = true;
            BikeStandBtn.GetComponent<Button>().interactable = false;
            AlertHandler.Instance.OnShowPopUp("Road Rule Followed !", Color.green);
            GameManager.Instance.NumberOfRulesFollowed++;
            StopChecking = true;
        }

    }
}
