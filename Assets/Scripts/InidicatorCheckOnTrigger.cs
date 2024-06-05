
using UnityEngine;

public class InidicatorCheckOnTrigger : MonoBehaviour
{
    public bool EntryPoint;
    public bool ExitPoit;
    public bool LeftIndicator;
    public bool RightIndicator;
    public bool DoubleIndicator;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.root.tag=="Player")
        {
            if (EntryPoint)
            {
                GetComponent<BoxCollider>().enabled = false;
                IndicatorCheckUI.Instance.CheckTriggerEnable = true;
                IndicatorCheckUI.Instance.VehicleReachesEndPoint = false;
                if (LeftIndicator)
                {
                    IndicatorCheckUI.Instance.checkIndicatorLeft = true;
                }
                if (RightIndicator)
                {
                    IndicatorCheckUI.Instance.checkIndicatorRight = true;
                }
                if (DoubleIndicator)
                {
                    IndicatorCheckUI.Instance.checkIndicatorDouble = true;
                }

            }
            if (ExitPoit)
            {
                GetComponent<BoxCollider>().enabled = false;
                IndicatorCheckUI.Instance.CheckTriggerEnable = false;
                IndicatorCheckUI.Instance.CheckRulesOnEndingTrigger();
            }

        }
    }
}
