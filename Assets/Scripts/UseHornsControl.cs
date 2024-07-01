using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseHornsControl : MonoBehaviour
{

    [HideInInspector] public bool HornRuleCheck;
    [HideInInspector] public bool HornsRuleFollowed;
    [HideInInspector] public bool VehicleReachesEndPoint;
    public GameObject HornBtn;
    public GameObject BikeHornBtn;

    public static UseHornsControl Instance;
    // Start is called before the first frame update
   
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void ClickOnHornBtn()
    {
        if (HornRuleCheck && !VehicleReachesEndPoint)
        {
            HornRuleCheck = false;
            HornsRuleFollowed = true;
            AlertHandler.Instance.OnShowPopUp("Control Rule Followed", Color.green);
            GameManager.Instance.NumberOfControlsFollowed++;
            
        }
    }
    public void OnReachingEndPoint()
    {
        VehicleReachesEndPoint = true;
        if (!HornsRuleFollowed)
        {
            AlertHandler.Instance.OnShowPopUp("Control Rule Not Followed", Color.red);
        }
    }
}
