
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public GameObject City;
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
    public GameObject BikeCAmera;
    public GameObject BikeCanvas;
    public GameObject BikeSkidMarks;
    int LevelNumber;
    string CurrentVehicle;
    public Camera MainCamera;
    public static GameManager Instance;
    public int NumberOfRulesFollowed;
    public int NumberOfSignsFollowed;
    public int NumberOfControlsFollowed;
    public GameObject NextBtn;
    public GameObject RestartBtn;
    public GameObject TestPassImage;
    public GameObject TestFailImage;
    public Text SignsObtainedText;
    public Text ControlsObtainedText;
    public Text RulesObtainedText;
    public HMVLevelsData[] LMVLevelData;
    public HMVLevelsData[] HMVLevelData;
    public BikeLevelsData[] BikeLevelData;
    int RequiredNumberOfSigns;
    int RequiredNumberOfRules;
    int RequiredNumberOfControls;
    public AudioSource HornSound;
    public Text TaskPanelRulesText;
    public Text TaskPanelSignsText;
    public Text TaskPanelControlText;
    public Transform EngineBtn;
    private void Awake()
    {
        City.SetActive(true);
    }
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        if(Instance==null)
        {
            Instance = this;
        }
        LevelNumber = PlayerPrefs.GetInt("CurrentLevel");
        CurrentVehicle = PlayerPrefs.GetString("CurrentVehicle");
        //CurrentVehicle = "LMV";
        ShowTasksPanelIntruction();

    }
    public void ShowTasksPanelIntruction()
    {
        TasksPanel.SetActive(true);
        switch (CurrentVehicle)
        {
            //For Bike Mode
            case "Bike":
 
                RequiredNumberOfSigns = BikeLevelData[LevelNumber - 1].Signs;
                RequiredNumberOfControls = BikeLevelData[LevelNumber - 1].Controls;
                RequiredNumberOfRules = BikeLevelData[LevelNumber - 1].Rules;
                break;
            //For LMV Mode
            case "LMV":          
                RequiredNumberOfSigns = LMVLevelData[LevelNumber - 1].Signs;
                RequiredNumberOfControls = LMVLevelData[LevelNumber - 1].Controls;
                RequiredNumberOfRules = LMVLevelData[LevelNumber - 1].Rules;            
                break;
            //For HMV Mode
            case "HMV":
               
                RequiredNumberOfSigns = HMVLevelData[LevelNumber - 1].Signs;
                RequiredNumberOfControls = HMVLevelData[LevelNumber - 1].Controls;
                RequiredNumberOfRules = HMVLevelData[LevelNumber - 1].Rules;   
                break;
            //On Wrong Entry
            default:
                Debug.Log("wrong Selection");
                break;
        }
        TaskPanelRulesText.text = RequiredNumberOfRules.ToString();
        TaskPanelSignsText.text = RequiredNumberOfSigns.ToString();
        TaskPanelControlText.text = RequiredNumberOfControls.ToString();

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
                SetBikeProperties();
                break;
            //For LMV Mode
            case "LMV":
                LMVLevels[LevelNumber - 1].SetActive(true);
                CurrentPlayer = CarPlayer;
                CurrentPlayer.transform.position = LMVLevels[LevelNumber - 1].transform.GetChild(0).transform.position;
                CurrentPlayer.transform.rotation = LMVLevels[LevelNumber - 1].transform.GetChild(0).transform.rotation;
              
                SetRCCProperties();
                break;
            //For HMV Mode
            case "HMV":
                HMVLevels[LevelNumber - 1].SetActive(true);
                CurrentPlayer = TruckPlayer;
                CurrentPlayer.transform.position = HMVLevels[LevelNumber - 1].transform.GetChild(0).transform.position;
                CurrentPlayer.transform.rotation = HMVLevels[LevelNumber - 1].transform.GetChild(0).transform.rotation;
              
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
    public void SetBikeProperties()
    {
        BikeCAmera.SetActive(true);
        BikeCanvas.SetActive(true);
        BikeSkidMarks.SetActive(true);
        CurrentPlayer.SetActive(true);
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
            if (PlayerPrefs.GetInt(CurrentVehicle + "Completed") < LevelNumber)
            {
                PlayerPrefs.SetInt(CurrentVehicle + "Completed", LevelNumber);
            }
            TestPassImage.SetActive(true);
            TestFailImage.SetActive(false);
            RestartBtn.SetActive(false);
            NextBtn.SetActive(true);
        }
        else
        {
            TestPassImage.SetActive(false);
            TestFailImage.SetActive(true);
            NextBtn.SetActive(false);
            RestartBtn.SetActive(true);
        }
    }
    public void PointerDownOnHornBtn()
    {
        HornSound.Play();
    }
    public void PointerUpHornBtn()
    {
        HornSound.Pause();
    }
    public void ClickOnPauseBtn()
    {
        Time.timeScale = 0;
    }
    public void ClickOnResumeBtn()
    {
        Time.timeScale = 1;
    }
    public void ClickOnHomeBtn()
    {
        SceneManager.LoadScene("ProModeMenu");
    }
    public void ClickOnNextBtn()
    {
        if (LevelNumber < 5)
        {
            LevelNumber++;
            PlayerPrefs.SetInt("CurrentLevel", LevelNumber);
        }
        else
        {
            PlayerPrefs.SetInt("CurrentLevel", 1);
        }
        SceneManager.LoadScene("GamePlay");
    }
    public void ClickOnRestartBtn()
    {
        SceneManager.LoadScene("GamePlay");
    }
    public void ClickOnEngineStartBtn()
    {
        if (EngineBtn.GetChild(0).gameObject.activeInHierarchy)
        {
            EngineBtn.GetChild(0).gameObject.SetActive(false);
        }
        else
        {
            EngineBtn.GetChild(0).gameObject.SetActive(true);
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
