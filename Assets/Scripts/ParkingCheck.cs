using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParkingCheck : MonoBehaviour
{
    public static ParkingCheck Instance;

    public ParkingTrigger Parking_Trigger;
    public Image FillImage;
    public bool AllowedArea;
    public bool NotAllowedArea;
    bool PlayerInTrigger;
    float fillAmount;
    int GearDirection;
    public bool Rule;
    public bool Sign;
    public bool Control;


    public string RuleFollowedString;
    public string RuleNotFollowedString;

    public bool isBike = false;
    public GameObject BikeEngineOffButton;
    

    public bool IsLevelFinishedHere = false;


   

    // Start is called before the first frame update
    void Start()
    {
        PlayerInTrigger = false;
        FillImage.fillAmount = 0;

        Instance = this;
        
    }
    public void OnStyingTrigger()
    {
        if (!isBike)
        {
            GearDirection = GameManager.Instance.RCCCanvas.transform.GetComponent<RCC_MobileButtons>().gearButton.GetComponent<RCC_UIDashboardButton>().gearDirection;
        }
        else if (isBike)
        {
            BikeEngineOffButton.SetActive(true);
        }
       
        PlayerInTrigger = true;
    }
    public void OnExitingTrigger()
    {
        if (!isBike)
        {
            GearDirection = GameManager.Instance.RCCCanvas.transform.GetComponent<RCC_MobileButtons>().gearButton.GetComponent<RCC_UIDashboardButton>().gearDirection;
        }
        else if (isBike)
        {
            BikeEngineOffButton.SetActive(false);
        }

        PlayerInTrigger = false;
        fillAmount = 0;
        FillImage.fillAmount = fillAmount;
    }
    // Update is called once per frame
    void Update()
    {
        if (!isBike)
        {
            if (PlayerInTrigger && GearDirection == 1)
            {
                if (fillAmount < 1)
                {
                    fillAmount += Time.timeScale * 0.01f;
                    FillImage.fillAmount = fillAmount;
                }

                if (fillAmount >= 0.9999f && AllowedArea)
                {
                    AlertHandler.Instance.OnShowPopUp(RuleFollowedString, Color.green);
                    if (Rule)
                    {
                        GameManager.Instance.NumberOfRulesFollowed++;
                    }
                    if (Sign)
                    {
                        GameManager.Instance.NumberOfSignsFollowed++;
                    }
                    if (Control)
                    {
                        GameManager.Instance.NumberOfControlsFollowed++;
                    }
                    //transform.GetComponentInChildren<ParkingTrigger>().gameObject.SetActive(false);
                    if (IsLevelFinishedHere)
                    {
                        GameManager.Instance.OnLevelComplete();
                    }
                    gameObject.SetActive(false);
                }
                if (fillAmount >= 0.9999f && NotAllowedArea)
                {
                    AlertHandler.Instance.OnShowPopUp(RuleNotFollowedString, Color.red);
                    //transform.GetComponentInChildren<ParkingTrigger>().gameObject.SetActive(false);
                    if (IsLevelFinishedHere)
                    {
                        GameManager.Instance.OnLevelComplete();
                    }
                    gameObject.SetActive(false);
                }
            }
        }
        else if (isBike)
        {
            Debug.Log("Here1");
            if (PlayerInTrigger  && BikeParkScript.Instance.isParkDone)
            {
                Debug.Log("Here2");
                if (fillAmount < 1)
                {
                    fillAmount += Time.timeScale * 0.01f;
                    FillImage.fillAmount = fillAmount;
                }

                if (fillAmount >= 0.9999f && AllowedArea)
                {
                    AlertHandler.Instance.OnShowPopUp(RuleFollowedString, Color.green);
                    Debug.Log("Here3");
                    if (Rule)
                    {
                        GameManager.Instance.NumberOfRulesFollowed++;
                    }
                    if (Sign)
                    {
                        Debug.Log("Here4");
                        GameManager.Instance.NumberOfSignsFollowed++;
                    }
                    if (Control)
                    {
                        GameManager.Instance.NumberOfControlsFollowed++;
                    }
                    //transform.GetComponentInChildren<ParkingTrigger>().gameObject.SetActive(false);
                    if (IsLevelFinishedHere)
                    {
                        GameManager.Instance.OnLevelComplete();
                    }
                    gameObject.SetActive(false);
                }
                if (fillAmount >= 0.9999f && NotAllowedArea)
                {
                    AlertHandler.Instance.OnShowPopUp(RuleNotFollowedString, Color.red);
                    //transform.GetComponentInChildren<ParkingTrigger>().gameObject.SetActive(false);
                    Debug.Log("Here5");
                    if (IsLevelFinishedHere)
                    {
                        GameManager.Instance.OnLevelComplete();
                    }
                    gameObject.SetActive(false);
                }
                //BikeParkScript.Instance.isParkDone = false;
            }
        }
    }

    public void OnHittingExitPoint()
    {
      
        if (NotAllowedArea)
        {
            AlertHandler.Instance.OnShowPopUp(RuleFollowedString, Color.green);
            if (Rule)
            {
                GameManager.Instance.NumberOfRulesFollowed++;
            }
            if (Sign)
            {
                GameManager.Instance.NumberOfSignsFollowed++;
            }
            if (Control)
            {
                GameManager.Instance.NumberOfControlsFollowed++;
            }
        }
        if (AllowedArea)
        {
            AlertHandler.Instance.OnShowPopUp(RuleNotFollowedString, Color.red);
            //transform.GetComponentInChildren<ParkingTrigger>().gameObject.SetActive(false);
            if (IsLevelFinishedHere)
            {
                GameManager.Instance.OnLevelComplete();
            }
        }
        gameObject.SetActive(false);
    }


}
