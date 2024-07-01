using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MenuHandler : MonoBehaviour
{
    public enum Type {Learner,Driver };
    [SerializeField] public Type CurrentType;

    public enum VehicleCatagory { Motorcycle, LMV, HMV};
    [SerializeField] public VehicleCatagory CurrentVehicleCatagory;

    public Toggle[] TestsToggles;
    string CurrentTest;
    public string CurrentFileName;
    public static MenuHandler Instance;
    public float timeRemaining = 3600f; // One hour in seconds
    public Text timerText;
    private Coroutine timerCoroutine;
    public GameObject TimesAlertPanel;
    public MCQPicker MCQpicker;
    public Text SignText;
    public Slider SignSlider;
    public Text RulesText;
    public Slider RulerSlider;
    public Text ControlText;
    public Slider ControlSlider;
    public GameObject ProModeBtn;
    public GameObject ProModeLockedBtn;
    // Start is called before the first frame update
    void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;
        if (Instance == null)
        {
            Instance = this;
        }
        
        foreach (Toggle toggle in TestsToggles)
        {
            toggle.onValueChanged.AddListener(delegate { RadioButtonToggled(toggle); });
        }
        RadioButtonToggled(TestsToggles[0]);
        CheckProMode();
    }

    public void CheckProMode()
    {
        if (InAppsDataContainer.Instance.ProModeUnlocked)
        {
            ProModeBtn.SetActive(true);
            ProModeLockedBtn.SetActive(false);
        }
        else
        {
            ProModeBtn.SetActive(false);
            ProModeLockedBtn.SetActive(true);
        }
    }
    private void RadioButtonToggled(Toggle selectedRadioButton)
    {
        foreach (Toggle toggle in TestsToggles)
        {
            toggle.transform.GetChild(3).gameObject.SetActive(false);
        }
        selectedRadioButton.transform.GetChild(3).gameObject.SetActive(true);
        ClickOnTest(selectedRadioButton.name);
    }

    public void ClickOnTest(string str)
    {
        CurrentTest = str;
    }

    public void SelectType(string str)
    {
        if (str == "Learner")
        {
            CurrentType = Type.Learner;
        }
        else if (str == "Driver")
        {
            CurrentType = Type.Driver;
        }
        else
        {
            Debug.LogError("Wrong String");
        }
    }
    public void SelectVehicleCatagory(string str)
    {
        if (str == "Bike")
        {
            CurrentVehicleCatagory = VehicleCatagory.Motorcycle;
        }
        else if (str == "LMV")
        {
            CurrentVehicleCatagory = VehicleCatagory.LMV;
        }
        else if (str == "HMV")
        {
            CurrentVehicleCatagory = VehicleCatagory.HMV;
        }
        else
        {
            Debug.LogError("Wrong String");
        }

    }
    public void ClickOnContinueBtn()
    {
        CurrentFileName = CurrentVehicleCatagory + CurrentTest;
        MCQpicker.StartTest();
        timeRemaining = 3600;
        timerCoroutine = StartCoroutine(CountdownTimer());
    }
    IEnumerator CountdownTimer()
    {
        while (timeRemaining > 0)
        {
            int minutes = Mathf.FloorToInt(timeRemaining / 60);
            int seconds = Mathf.FloorToInt(timeRemaining % 60);

            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

            yield return new WaitForSeconds(1f);

            timeRemaining--;

            // You can also update your UI with the remaining time
        }

        // When time's up, show a popup
        ShowTimeUpPopup();
    }
    void ShowTimeUpPopup()
    {
        // Show your popup here
        TimesAlertPanel.SetActive(true);
        Debug.Log("Time's up!");
    }
    public void ClickOnTestRestartBtn()
    {
        timeRemaining = 3600;
        timerCoroutine = StartCoroutine(CountdownTimer());
    }
    public void StopTimer()
    {
        if (timerCoroutine != null)
        StopCoroutine(timerCoroutine);
    }
    public void ClickOnProgressBtn()
    {
        SignText.text = PlayerPrefs.GetInt("SignsMarks").ToString();
        SignSlider.value = PlayerPrefs.GetInt("SignsMarks");
        RulesText.text = PlayerPrefs.GetInt("RulesMarks").ToString();
        RulerSlider.value = PlayerPrefs.GetInt("RulesMarks");
        ControlText.text = PlayerPrefs.GetInt("ControlMarks").ToString();
        ControlSlider.value = PlayerPrefs.GetInt("ControlMarks");


    }

    public void ClickOnExit()
    {
        Application.Quit();
    }
    public void ClickOnTestBtn()
    {
        RadioButtonToggled(TestsToggles[0]);
    }
    public void ClickOnProModeBtn()
    {
        


        StartCoroutine(LoadProModeMenu());

    }
    IEnumerator LoadProModeMenu()
    {
        yield return new WaitForSecondsRealtime(2);
        SceneManager.LoadSceneAsync("ProModeMenu");
    }


    public void ShowBanner()
    {
        AdsManager.Instance.ShowBanner();
    }
    public void ShowInterstitial()
    {
        AdsManager.Instance.ShowInterstitial();
    }
}
