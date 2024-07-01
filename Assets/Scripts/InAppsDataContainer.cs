using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InAppsDataContainer : MonoBehaviour
{
    [HideInInspector]public bool ProModeUnlocked;
    [HideInInspector] public bool HMVTest1Hint;
    [HideInInspector] public bool HMVTest2Hint;
    [HideInInspector] public bool HMVTest3Hint;
    [HideInInspector] public bool HMVTest4Hint;
    [HideInInspector] public bool HMVTest5Hint;
    [HideInInspector] public bool LMVTest1Hint;
    [HideInInspector] public bool LMVTest2Hint;
    [HideInInspector] public bool LMVTest3Hint;
    [HideInInspector] public bool LMVTest4Hint;
    [HideInInspector] public bool LMVTest5Hint;
    [HideInInspector] public bool BikeTest1Hint;
    [HideInInspector] public bool BikeTest2Hint;
    [HideInInspector] public bool BikeTest3Hint;
    [HideInInspector] public bool BikeTest4Hint;
    [HideInInspector] public bool BikeTest5Hint;

    public static InAppsDataContainer Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Invoke("SetProperties", 0.5f);
    }

    public void SetProperties()
    {
        if (PlayerPrefs.GetInt("ProModeUnlocked") == 1)
        {
            ProModeUnlocked = true;
        }
        if (PlayerPrefs.GetInt("LMVTestHint1") == 1)
        {
            LMVTest1Hint = true;
        }
        if (PlayerPrefs.GetInt("LMVTestHint2") == 1)
        {
            LMVTest2Hint = true;
        }
        if (PlayerPrefs.GetInt("LMVTestHint3") == 1)
        {
            LMVTest3Hint = true;
        }
        if (PlayerPrefs.GetInt("LMVTestHint4") == 1)
        {
            LMVTest4Hint = true;
        }
        if (PlayerPrefs.GetInt("LMVTestHint5") == 1)
        {
            LMVTest5Hint = true;
        }


        if (PlayerPrefs.GetInt("HMVTestHint1") == 1)
        {
            HMVTest1Hint = true;
        }
        if (PlayerPrefs.GetInt("HMVTestHint2") == 1)
        {
            HMVTest2Hint = true;
        }
        if (PlayerPrefs.GetInt("HMVTestHint3") == 1)
        {
            HMVTest3Hint = true;
        }
        if (PlayerPrefs.GetInt("HMVTestHint4") == 1)
        {
            HMVTest4Hint = true;
        }
        if (PlayerPrefs.GetInt("HMVTestHint5") == 1)
        {
            HMVTest5Hint = true;
        }

        if (PlayerPrefs.GetInt("BikeTestHint1") == 1)
        {
            BikeTest1Hint = true;
        }
        if (PlayerPrefs.GetInt("BikeTestHint2") == 1)
        {
            BikeTest2Hint = true;
        }
        if (PlayerPrefs.GetInt("BikeTestHint3") == 1)
        {
            BikeTest3Hint = true;
        }
        if (PlayerPrefs.GetInt("BikeTestHint4") == 1)
        {
            BikeTest4Hint = true;
        }
        if (PlayerPrefs.GetInt("BikeTestHint5") == 1)
        {
            BikeTest5Hint = true;
        }





    }
}
