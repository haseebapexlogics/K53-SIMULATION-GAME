using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakAndIndicatorCheckUI : MonoBehaviour
{
    [HideInInspector] public bool BreakCheckRuleCheck;
    [HideInInspector] public bool BreakCheckRuleFollowed;
    [HideInInspector] public bool VehicleReachesEndPoint;
    public static BreakAndIndicatorCheckUI Instance;
    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    public void ClickOnBreakORIndecatorBtn()
    {
        if (BreakCheckRuleCheck && !VehicleReachesEndPoint)
        {
            BreakCheckRuleCheck = false;
            BreakCheckRuleFollowed = true;
            //AlertHandler.Instance.OnShowPopUp("Road Rule Not Followed”", Color.red);
        }
    }
    public void OnReachingEndPoint()
    {
        VehicleReachesEndPoint = true;
        if (BreakCheckRuleFollowed)
        {
            AlertHandler.Instance.OnShowPopUp("Road Rule Followed", Color.green);
            GameManager.Instance.NumberOfRulesFollowed++;
        }
        else
        {
            AlertHandler.Instance.OnShowPopUp("Road Rule Not Followed”", Color.red);
        }
    }

}
