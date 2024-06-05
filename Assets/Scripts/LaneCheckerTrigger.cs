using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneCheckerTrigger : MonoBehaviour
{
    public bool EntryPoint;
    public bool NotAllowedArea;
    public bool AllowedArea;
    public bool EndOfTrigger;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnTrigger()
    {
        if (EntryPoint)
        { 
        
        }
        if (EntryPoint && EndOfTrigger && NotAllowedArea == false)
        {
            AlertHandler.Instance.OnShowPopUp("Follow Road Line Rule",Color.green);
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
        }
        if (NotAllowedArea)
        {
            AlertHandler.Instance.OnShowPopUp("Not Follow Road Line Rule", Color.red);
            transform.gameObject.SetActive(false);
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
        }
       
    }

}
