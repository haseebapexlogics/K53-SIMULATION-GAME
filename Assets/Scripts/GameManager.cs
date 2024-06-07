
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public GameObject GamePlayPanel;
    public GameObject ResultsPanel;
    public GameObject PausePanel;
    public GameObject TasksPanel;
    public GameObject[] BikeLevels;
    public GameObject[] LMVLevels;
    public GameObject[] HMVLevels;
    public Scrollbar GearSlider;
    public GameObject RCCCanvas;
    public GameObject RCCCamera;
    public GameObject BikePlayer;
    public GameObject CarPlayer;
    public GameObject TruckPlayer;
    public GameObject CurrentPlayer;
    int LevelNumber;
    string CurrentVehicle;
    public Camera MainCamera;
    public static GameManager Instance;
    public int NumberOfRulesFollowed;
    public int NumberOfSignsFollowed;
    public int NumberOfControlsFollowed;
    public GameObject NextBtn;
    public GameObject RestartBtn;
    public Text OverAllStatusText;
    public Text SignsObtainedText;
    public Text ControlsObtainedText;
    public Text RulesObtainedText;
    public HMVLevelsData[] LMVLevelData;
    public HMVLevelsData[] HMVLevelData;
    public BikeLevelsData[] BikeLevelData;
    int RequiredNumberOfSigns;
    int RequiredNumberOfRules;
    int RequiredNumberOfControls;
    // Start is called before the first frame update
    void Start()
    {
        if(Instance==null)
        {
            Instance = this;
        }
        LevelNumber = PlayerPrefs.GetInt("CurrentLevel");
        CurrentVehicle = PlayerPrefs.GetString("CurrentVehicle");
        //CurrentVehicle = "LMV";

    }

    public void ClickOnLevelStartBtn()
    {
        MainCamera.enabled = false;
        switch (CurrentVehicle)
        {
            //For Bike Mode
            case "Bike":
                BikeLevels[LevelNumber - 1].SetActive(true);
                CurrentPlayer = BikePlayer;
                CurrentPlayer.transform.position = BikeLevels[LevelNumber - 1].transform.GetChild(0).transform.position;
                CurrentPlayer.transform.rotation = BikeLevels[LevelNumber - 1].transform.GetChild(0).transform.rotation;
                RequiredNumberOfSigns = BikeLevelData[LevelNumber - 1].Signs;
                RequiredNumberOfControls = BikeLevelData[LevelNumber - 1].Controls;
                RequiredNumberOfRules = BikeLevelData[LevelNumber - 1].Rules;
                break;
            //For LMV Mode
            case "LMV":
                LMVLevels[LevelNumber - 1].SetActive(true);
                CurrentPlayer = CarPlayer;
                CurrentPlayer.transform.position = LMVLevels[LevelNumber - 1].transform.GetChild(0).transform.position;
                CurrentPlayer.transform.rotation = LMVLevels[LevelNumber - 1].transform.GetChild(0).transform.rotation;
                RequiredNumberOfSigns = LMVLevelData[LevelNumber - 1].Signs;
                RequiredNumberOfControls = LMVLevelData[LevelNumber - 1].Controls;
                RequiredNumberOfRules = LMVLevelData[LevelNumber - 1].Rules;
                SetRCCProperties();
                break;
            //For HMV Mode
            case "HMV":
                HMVLevels[LevelNumber - 1].SetActive(true);
                CurrentPlayer = TruckPlayer;
                CurrentPlayer.transform.position = HMVLevels[LevelNumber - 1].transform.GetChild(0).transform.position;
                CurrentPlayer.transform.rotation = HMVLevels[LevelNumber - 1].transform.GetChild(0).transform.rotation;
                RequiredNumberOfSigns = HMVLevelData[LevelNumber - 1].Signs;
                RequiredNumberOfControls = HMVLevelData[LevelNumber - 1].Controls;
                RequiredNumberOfRules = HMVLevelData[LevelNumber - 1].Rules;
                SetRCCProperties();
                break;
            //On Wrong Entry
            default:
                Debug.Log("wrong Selection");
                break;                    
        }
    }
    public void SetRCCProperties()
    {
        RCCCamera.SetActive(true);
        RCCCanvas.SetActive(true);
        CurrentPlayer.SetActive(true);
        RCCCamera.GetComponent<RCC_Camera>().playerCar = CurrentPlayer.GetComponent<RCC_CarControllerV3>();
        Invoke("ChangeGear", 1);

    }   
    public void ChangeGear()
    {
        GearSlider.value = 0.5f;
    }
    public void OnLevelComplete()
    {

        switch (CurrentVehicle)
        {
            case "Bike":
                BikeLevels[LevelNumber - 1].SetActive(false);          
                break;
            case "LMV":
                LMVLevels[LevelNumber - 1].SetActive(false);
                  
                break;
        
            case "HMV":
                HMVLevels[LevelNumber - 1].SetActive(false);
                CurrentPlayer = TruckPlayer;
                break;
            default:
                Debug.Log("wrong Selection");
                break;
        }



        ResultsPanel.SetActive(true);
        SignsObtainedText.text= (NumberOfSignsFollowed+"/"+RequiredNumberOfSigns).ToString();
        RulesObtainedText.text = (NumberOfRulesFollowed + "/" + RequiredNumberOfRules).ToString();
        ControlsObtainedText.text = (NumberOfControlsFollowed + "/" + RequiredNumberOfControls).ToString();
        if (NumberOfSignsFollowed >= RequiredNumberOfSigns && NumberOfRulesFollowed >= RequiredNumberOfRules && NumberOfControlsFollowed >= RequiredNumberOfControls)
        {
            if (PlayerPrefs.GetInt(CurrentVehicle + LevelNumber) < LevelNumber)
            {
                PlayerPrefs.SetInt(CurrentVehicle + LevelNumber, LevelNumber);
            }

            OverAllStatusText.text = "Test Passed";
            NextBtn.SetActive(true);
        }
        else
        {
            OverAllStatusText.text = "Test Failed";
            RestartBtn.SetActive(true);
        }
    }

}
[System.Serializable]
public class LMVLevelsData
{
    public int Signs;
    public int Rules;
    public int Controls;
}
[System.Serializable]
public class HMVLevelsData
{
    public int Signs;
    public int Rules;
    public int Controls;
}
[System.Serializable]
public class BikeLevelsData
{
    public int Signs;
    public int Rules;
    public int Controls;
   
}
