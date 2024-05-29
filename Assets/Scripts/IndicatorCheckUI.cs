using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatorCheckUI : MonoBehaviour
{
    [HideInInspector] public bool checkIndicatorRight;
    [HideInInspector] public bool checkindicatorLeft;
    [HideInInspector] public bool checkIndicatorDouble;
    public bool RightIndictorRuleFollowed;
    public bool LeftIndictorRuleFollowed;
    public bool DoubleIndictorRuleFollowed;
    public bool VehicleReachesEndPoint;
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
        if (checkindicatorLeft)
        {
            LeftIndictorRuleFollowed = true;
        }
    }
    public void ClickOnRightIndecator()
    {
        if (checkIndicatorRight)
        {
            RightIndictorRuleFollowed = true;
        }
    }
    public void ClickOnDoubleIndecator()
    {
        if (checkIndicatorDouble)
        {
            DoubleIndictorRuleFollowed = true;
        }
    }

}
