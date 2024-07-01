using UnityEngine;

public class HornCheckUI : MonoBehaviour
{
    [HideInInspector] public bool HornRuleCheck;
    [HideInInspector] public bool HornsRuleViolated;
    [HideInInspector] public bool VehicleReachesEndPoint;
    public GameObject HornBtn;
    public GameObject BikeHornBtn;
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
            AlertHandler.Instance.OnShowPopUp("Sign Rule Not Followed”", Color.red);
        }
    }
    public void OnReachingEndPoint()
    {
        VehicleReachesEndPoint = true;
        if (!HornsRuleViolated)
        {
            AlertHandler.Instance.OnShowPopUp("Sign Rule Followed", Color.green);
            GameManager.Instance.NumberOfSignsFollowed++;
        }
    }
}
