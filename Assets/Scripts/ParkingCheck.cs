using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParkingCheck : MonoBehaviour
{
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
   
    // Start is called before the first frame update
    void Start()
    {
        PlayerInTrigger = false;
        FillImage.fillAmount = 0;
        
    }
    public void OnStyingTrigger()
    {
        GearDirection = GameManager.Instance.RCCCanvas.transform.GetComponent<RCC_MobileButtons>().gearButton.GetComponent<RCC_UIDashboardButton>().gearDirection;
       
        PlayerInTrigger = true;
    }
    public void OnExitingTrigger()
    {
        GearDirection = GameManager.Instance.RCCCanvas.transform.GetComponent<RCC_MobileButtons>().gearButton.GetComponent<RCC_UIDashboardButton>().gearDirection;
        PlayerInTrigger = false;
        fillAmount = 0;
        FillImage.fillAmount = fillAmount;
    }
    // Update is called once per frame
    void Update()
    {
        if(PlayerInTrigger&&GearDirection==1)
        {
            if (fillAmount < 1)
            {
                fillAmount += Time.timeScale * 0.01f;
                FillImage.fillAmount = fillAmount;
            }

            if (fillAmount >= 0.9999f && AllowedArea)
            {
                AlertHandler.Instance.OnShowPopUp("Follow Parking Rule",Color.green);
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
                GameManager.Instance.OnLevelComplete();
                gameObject.SetActive(false);
            }
            if (fillAmount >= 0.9999f && NotAllowedArea)
            {
                AlertHandler.Instance.OnShowPopUp("Not Follow Parking Rule", Color.red);
                //transform.GetComponentInChildren<ParkingTrigger>().gameObject.SetActive(false);
                gameObject.SetActive(false);
            }
        }
    }

    public void OnHittingExitPoint()
    {
      
        if (NotAllowedArea)
        {
            AlertHandler.Instance.OnShowPopUp("Follow Parking Rule", Color.green);
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
            AlertHandler.Instance.OnShowPopUp("Not Follow Parking Rule", Color.red);
            //transform.GetComponentInChildren<ParkingTrigger>().gameObject.SetActive(false);
            
        }
        gameObject.SetActive(false);
    }
}
