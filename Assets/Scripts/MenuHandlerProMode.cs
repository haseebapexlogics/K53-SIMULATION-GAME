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
    public Image FillImage;
    // Start is called before the first frame update
    void Start()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
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
        FillImage.fillAmount = 0;
        StartCoroutine(DeleyLoadGamePlayScene());
    }
    IEnumerator DeleyLoadGamePlayScene()
    {
        float totalTime = 3f;
        float elapsedTime = 0f;

        while (elapsedTime < totalTime)
        {
            elapsedTime += Time.deltaTime;
            FillImage.fillAmount = Mathf.Clamp01(elapsedTime / totalTime);
            yield return null;
        }

        yield return new WaitForSecondsRealtime(0.1f); // Optional slight delay to ensure the bar is fully filled.

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("GamePlay");
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
