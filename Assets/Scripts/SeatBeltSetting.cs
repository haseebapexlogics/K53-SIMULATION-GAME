using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeatBeltSetting : MonoBehaviour
{
    public static SeatBeltSetting Instance;

    public GameObject SeatBeltBtn;
    public bool StopChecking;

    private void Start()
    {
        Instance = this;
    }

    public void SetSeatbeltTrue()
    {
        if (!StopChecking)
        {
            SeatbeltChecker.Instance.isSeatBelt = true;
            SeatBeltBtn.GetComponent<Button>().interactable = false;
            AlertHandler.Instance.OnShowPopUp("Road Rule Followed !", Color.green);
            GameManager.Instance.NumberOfRulesFollowed++;
            StopChecking = true;
        }
      
    }
    
}
