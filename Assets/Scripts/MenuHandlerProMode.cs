using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MenuHandlerProMode : MonoBehaviour
{
    string CurrentVehicleAndLevel;
    string CurrentVehicle;
    int CurrentLevel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ClickOnVehicleBtn(string str)
    {
        CurrentVehicle = str;
    }
    public void ClickOnLevelNumber(int number)
    {
        CurrentLevel = number;
    }
    public void SetCurrentVehicleAndLevel()
    {
        CurrentVehicleAndLevel = CurrentVehicle + CurrentLevel;
    }





}
