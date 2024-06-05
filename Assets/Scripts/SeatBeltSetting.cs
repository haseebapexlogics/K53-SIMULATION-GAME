using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            AlertHandler.Instance.OnShowPopUp("SeatBelt Done !!!", Color.green);
            GameManager.Instance.NumberOfControlsFollowed++;
        }
      
    }
    
}
