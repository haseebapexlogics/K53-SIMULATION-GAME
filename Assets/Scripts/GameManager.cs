
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

    // Start is called before the first frame update
    void Start()
    {
        if(Instance==null)
        {
            Instance = this;
        }
        LevelNumber = PlayerPrefs.GetInt("CurrentLevel");
        CurrentVehicle = PlayerPrefs.GetString("CurrentVehicle");

        CurrentVehicle = "LMV";
        Debug.Log(CurrentVehicle);
       
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
    
    public void ChangeGear()
    {
        GearSlider.value = 0.5f;
    }

}
