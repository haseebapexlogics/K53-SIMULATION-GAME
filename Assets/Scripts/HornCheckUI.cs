using UnityEngine;

public class HornCheckUI : MonoBehaviour
{
    [HideInInspector] public bool HornRuleCheck;
    [HideInInspector] public bool HornsRuleViolated;
    [HideInInspector] public bool VehicleReachesEndPoint;
   
    public static HornCheckUI Instance;
    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    public void ClickOnHornBtn()
    {
        if (HornRuleCheck &&  !VehicleReachesEndPoint)
        {
            HornRuleCheck = false;
            HornsRuleViolated = true;
            AlertHandler.Instance.OnShowPopUp("Not Follow Horn Rule", Color.red);
        }
    }
    public void OnReachingEndPoint()
    {
        VehicleReachesEndPoint = true;
        if (!HornsRuleViolated)
        {
            AlertHandler.Instance.OnShowPopUp("Follow Horn Rule",Color.green);
        }
    }
}
