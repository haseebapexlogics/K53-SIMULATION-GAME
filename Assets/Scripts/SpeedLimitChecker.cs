using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedLimitChecker : MonoBehaviour
{
    [HideInInspector] public bool StartCheckingSpeed;
    public float MaxAllowedSpeed;
    GameObject CurrentPlayer;
    float CurrentVehicleSpeed;
    // Start is called before the first frame update
    void Start()
    {

    }
    
    public void OnTriggerStart(GameObject Player)
    {
        StartCheckingSpeed = true;
        CurrentPlayer = Player;
    }
    public void OnTriggerEnd()
    {
        StartCheckingSpeed = false;
        AlertHandler.Instance.OnShowPopUp("You Follow Speed Limit",Color.green);
        transform.gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (StartCheckingSpeed && CurrentPlayer)
        {
            if (CurrentPlayer.transform.GetComponent<RCC_CarControllerV3>())
            {
                CurrentVehicleSpeed = CurrentPlayer.transform.GetComponent<RCC_CarControllerV3>().speed;
               // Debug.Log(CurrentVehicleSpeed);
            }
            //Bike ConditionWrite Here


           // Debug.Log(CurrentVehicleSpeed);
            if (CurrentVehicleSpeed > MaxAllowedSpeed)
            {
                StartCheckingSpeed = false;
                AlertHandler.Instance.OnShowPopUp("You Not Follow Speed Limit", Color.red);
                transform.gameObject.SetActive(false);
            }
        }
    }
}
