using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatorCheckUI : MonoBehaviour
{
    [HideInInspector]public bool checkIndicatorRight;
    [HideInInspector] public bool checkIndicatorLeft;
    [HideInInspector] public bool checkIndicatorDouble;
    bool RightIndictorRuleFollowed;
    bool LeftIndictorRuleFollowed;
    bool DoubleIndictorRuleFollowed;
    [HideInInspector] public bool VehicleReachesEndPoint;
    [HideInInspector] public bool CheckTriggerEnable;

    
    public static IndicatorCheckUI Instance;
    
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }        
    }

    public void ClickOnLeftIndecator()
    {
        if (checkIndicatorLeft && CheckTriggerEnable && !VehicleReachesEndPoint)
        {
            LeftIndictorRuleFollowed = true;
        }
    }
    public void ClickOnRightIndecator()
    {
        if (checkIndicatorRight && CheckTriggerEnable && !VehicleReachesEndPoint)
        {
            RightIndictorRuleFollowed = true;
        }
    }
    public void ClickOnDoubleIndecator()
    {
        if (checkIndicatorDouble && CheckTriggerEnable && !VehicleReachesEndPoint)
        {
            DoubleIndictorRuleFollowed = true;
        }
    }

    public void CheckRulesOnEndingTrigger()
    {
        VehicleReachesEndPoint = true;
        if (checkIndicatorLeft)
        {
            if (LeftIndictorRuleFollowed)
            {
                AlertHandler.Instance.OnShowPopUp("Follow Left Indecator Rule", Color.green);
            }
            else
            {
                AlertHandler.Instance.OnShowPopUp("Not Follow Left Indecator Rule", Color.red);
            }
            
        }
        if (checkIndicatorRight)
        {
            if (RightIndictorRuleFollowed)
            {
                AlertHandler.Instance.OnShowPopUp("Follow Right Indecator Rule", Color.green);
            }
            else
            {
                AlertHandler.Instance.OnShowPopUp("Not Follow Right Indecator Rule", Color.red);
            }

        }
        if (checkIndicatorDouble)
        {
            if (DoubleIndictorRuleFollowed)
            {
                AlertHandler.Instance.OnShowPopUp("Follow Double Indecator Rule", Color.green);
            }
            else
            {
                AlertHandler.Instance.OnShowPopUp("Not Follow Double Indecator Rule", Color.red);
            }

        }
    }

}
