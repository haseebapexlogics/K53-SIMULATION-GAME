using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MenuHandlerProMode : MonoBehaviour
{
    string CurrentVehicleAndLevel;
    string CurrentVehicle;
    int CurrentLevel;
    public GameObject LoadingPanel;
    // Start is called before the first frame update
    void Start()
    {
        Screen.orientation = ScreenOrientation.LandscapeRight;
    }

    public void ClickOnVehicleBtn(string str)
    {
        CurrentVehicle = str;
        PlayerPrefs.SetString("CurrentVehicle", CurrentVehicle);
    }
    public void ClickOnLevelNumber(int number)
    {
        CurrentLevel = number;
        PlayerPrefs.SetInt("CurrentLevel", CurrentLevel);
    }

    public void ClickOnBackBtn()
    {
        LoadingPanel.SetActive(true);
        SceneManager.LoadSceneAsync("MainMenu");
    }
    public void LoadGamePlayScene()
    {
        StartCoroutine(DeleyLoadGamePlayScene());
    }
    IEnumerator DeleyLoadGamePlayScene()
    {
        yield return new WaitForSecondsRealtime(2);
        SceneManager.LoadSceneAsync("GamePlay");
    }
}
