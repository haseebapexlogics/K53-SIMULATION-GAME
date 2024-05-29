using System.Collections;
using System.Collections.Generic;
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
        if(other.transform.parent.tag=="Player")
        {
            if (EntryPoint)
            {
                GetComponent<BoxCollider>().enabled = false;
                if (LeftIndicator)
                {
                    IndicatorCheckUI.Instance.checkindicatorLeft = true;
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
                
            }

        }
    }
}
