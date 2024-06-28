using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GearControlCheck : MonoBehaviour
{
    public Scrollbar Gear;
    bool CheckGearControl;
    float currentVal;
    bool once;
    private void Start()
    {
        if ((PlayerPrefs.GetInt("CurrentLevel") == 5 && PlayerPrefs.GetString("CurrentVehicle") == "LMV")|| (PlayerPrefs.GetInt("CurrentLevel") == 2 && PlayerPrefs.GetString("CurrentVehicle") == "HMV"))
        {
            CheckGearControl = true;
        }
    }
    // Start is called before the first frame update
    public void OnGearChange()
    {
        
       
        if (CheckGearControl)
        {
            if (!once)
            {
                once = true;
                currentVal = Gear.value;
            }
            
            Debug.Log(currentVal);
            if (currentVal == 0.5f && Gear.value == 0)
            {
                CheckGearControl = false;
                GameManager.Instance.NumberOfControlsFollowed++;
                AlertHandler.Instance.OnShowPopUp("Gear Shift Control Followed",Color.green);
            }
        }
    }
}
