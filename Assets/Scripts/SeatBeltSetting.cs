using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeatBeltSetting : MonoBehaviour
{
    public static SeatBeltSetting Instance;

    public GameObject SeatBeltBtn;


    private void Start()
    {
        Instance = this;
    }

    public void SetSeatbeltTrue()
    {
        SeatbeltChecker.Instance.isSeatBelt = true;
        AlertHandler.Instance.OnShowPopUp("SeatBelt Done !!!", Color.green);
    }
}
