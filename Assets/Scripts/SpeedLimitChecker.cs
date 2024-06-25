using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedLimitChecker : MonoBehaviour
{
    [HideInInspector] public bool StartCheckingSpeed;
    public float MaxAllowedSpeed;
    GameObject CurrentPlayer;
    float CurrentVehicleSpeed;
    public bool Sign;
    public bool Rule;
    public string FollowString;
    public string UnFollowString;
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
        AlertHandler.Instance.OnShowPopUp(FollowString,Color.green);
        transform.gameObject.SetActive(false);
        if (Sign)
        {
            GameManager.Instance.NumberOfSignsFollowed++;
        }
        if (Rule)
        {
            GameManager.Instance.NumberOfRulesFollowed++;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (StartCheckingSpeed && CurrentPlayer)
        {
            
            if (CurrentPlayer.transform.GetComponent<RCC_CarControllerV3>())
            {
                CurrentVehicleSpeed = CurrentPlayer.transform.GetComponent<RCC_CarControllerV3>().speed;
                //GameManager.Instance.NumberOfRulesFollowed++;
               // Debug.Log(CurrentVehicleSpeed);
            }
            else if (CurrentPlayer.transform.GetComponent<BikeControl>())
            {
                CurrentVehicleSpeed = CurrentPlayer.transform.GetComponent<BikeControl>().speed;
            }
            //Bike ConditionWrite Here


           // Debug.Log(CurrentVehicleSpeed);
            if (CurrentVehicleSpeed > MaxAllowedSpeed)
            {
                StartCheckingSpeed = false;
                AlertHandler.Instance.OnShowPopUp(UnFollowString, Color.red);
                transform.gameObject.SetActive(false);
            }
        }
    }
}
