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
    public GameObject[] LMVLevels;
    public GameObject[] HMVLevels;
    public GameObject[] BikeLevels;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        LevelLockedUnlockedFun();
    }


    public void LevelLockedUnlockedFun()
    {
        for (int i = 0; i < 5; i++)
        {
            if (PlayerPrefs.GetInt("LMVCompleted") >= i)
            {
                LMVLevels[i].transform.GetChild(0).gameObject.SetActive(false);
                LMVLevels[i].transform.GetComponent<Button>().interactable = true;
            }

        }
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

        yield return new WaitForSecondsRealtime(0.1f);

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("GamePlay");
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
