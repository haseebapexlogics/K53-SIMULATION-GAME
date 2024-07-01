using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PurchaseHandler : MonoBehaviour
{
  
    void Awake()
    {
        CheckProductExpiry();
    }
    

    public void OnUnlockProMode()
    {
        PlayerPrefs.SetString("purchaseDateProMode", DateTime.Now.ToString());
        PlayerPrefs.SetInt("ProModeUnlocked", 1);
        InAppsDataContainer.Instance.SetProperties();
        MenuHandler.Instance.CheckProMode();
    }
    public void OnLMVTest1Unlock()
    {
        PlayerPrefs.SetString("purchaseDateLMVTestHint1", DateTime.Now.ToString());
        PlayerPrefs.SetInt("LMVTestHint1", 1);
    }
    public void OnLMVTest2Unlock()
    {
        PlayerPrefs.SetString("purchaseDateLMVTestHint2", DateTime.Now.ToString());
        PlayerPrefs.SetInt("LMVTestHint2", 1);
    }
    public void OnLMVTest3Unlock()
    {
        PlayerPrefs.SetString("purchaseDateLMVTestHint3", DateTime.Now.ToString());
        PlayerPrefs.SetInt("LMVTestHint3", 1);
    }
    public void OnLMVTest4Unlock()
    {
        PlayerPrefs.SetString("purchaseDateLMVTestHint4", DateTime.Now.ToString());
        PlayerPrefs.SetInt("LMVTestHint4", 1);
    }
    public void OnLMVTest5Unlock()
    {
        PlayerPrefs.SetString("purchaseDateLMVTestHint5", DateTime.Now.ToString());
        PlayerPrefs.SetInt("LMVTestHint5", 1);
    }
    public void OnHMVTest1Unlock()
    {
        PlayerPrefs.SetString("purchaseDateHMVTestHint1", DateTime.Now.ToString());
        PlayerPrefs.SetInt("HMVTestHint1", 1);
    }
    public void OnHMVTest2Unlock()
    {
        PlayerPrefs.SetString("purchaseDateHMVTestHint2", DateTime.Now.ToString());
        PlayerPrefs.SetInt("HMVTestHint2", 1);
    }
    public void OnHMVTest3Unlock()
    {
        PlayerPrefs.SetString("purchaseDateHMVTestHint3", DateTime.Now.ToString());
        PlayerPrefs.SetInt("HMVTestHint3", 1);
    }
    public void OnHMVTest4Unlock()
    {
        PlayerPrefs.SetString("purchaseDateHMVTestHint4", DateTime.Now.ToString());
        PlayerPrefs.SetInt("HMVTestHint4", 1);
    }
    public void OnHMVTest5Unlock()
    {
        PlayerPrefs.SetString("purchaseDateHMVTestHint5", DateTime.Now.ToString());
        PlayerPrefs.SetInt("HMVTestHint5", 1);
    }
    public void OnBikeTest1Unlock()
    {
        PlayerPrefs.SetString("purchaseDateBikeTestHint1", DateTime.Now.ToString());
        PlayerPrefs.SetInt("BikeTestHint1", 1);
    }
    public void OnBikeTest2Unlock()
    {
        PlayerPrefs.SetString("purchaseDateBikeTestHint2", DateTime.Now.ToString());
        PlayerPrefs.SetInt("BikeTestHint2", 1);
    }
    public void OnBikeTest3Unlock()
    {
        PlayerPrefs.SetString("purchaseDateBikeTestHint3", DateTime.Now.ToString());
        PlayerPrefs.SetInt("BikeTestHint3", 1);
    }
    public void OnBikeTest4Unlock()
    {
        PlayerPrefs.SetString("purchaseDateBikeTestHint4", DateTime.Now.ToString());
        PlayerPrefs.SetInt("BikeTestHint4", 1);
    }
    public void OnBikeTest5Unlock()
    {
        PlayerPrefs.SetString("purchaseDateBikeTestHint5", DateTime.Now.ToString());
        PlayerPrefs.SetInt("BikeTestHint5", 1);
    }
    public void CheckProductExpiry()
    {
        for (int i = 1; i <= 5; i++)
        {
            if (PlayerPrefs.HasKey("purchaseDateLMVTestHint"+i))
            {
                DateTime purchaseDate = DateTime.Parse(PlayerPrefs.GetString("purchaseDateLMVTestHint" + i));
                if (DateTime.Now > purchaseDate.AddDays(30))
                {
                    Debug.Log("Product has expired");
                    PlayerPrefs.DeleteKey("purchaseDateLMVTestHint"+i);
                    PlayerPrefs.SetInt("LMVTestHint"+i, 0);
                }
            }
        }
        for (int i = 1; i <= 5; i++)
        {
            if (PlayerPrefs.HasKey("purchaseDateHMVTestHint" + i))
            {
                DateTime purchaseDate = DateTime.Parse(PlayerPrefs.GetString("purchaseDateHMVTestHint" + i));
                if (DateTime.Now > purchaseDate.AddDays(30))
                {
                    Debug.Log("Product has expired");
                    PlayerPrefs.DeleteKey("purchaseDateLMVTestHint"+i);
                    PlayerPrefs.SetInt("LMVTestHint" + i, 0);
                }
            }
        }
        for (int i = 1; i <= 5; i++)
        {
            if (PlayerPrefs.HasKey("purchaseDateBikeTestHint" + i))
            {
                DateTime purchaseDate = DateTime.Parse(PlayerPrefs.GetString("purchaseDateBikeTestHint" + i));
                if (DateTime.Now > purchaseDate.AddDays(30))
                {
                    Debug.Log("Product has expired");
                    PlayerPrefs.DeleteKey("purchaseDateBikeTestHint" + i);
                    PlayerPrefs.SetInt("BikeTestHint" + i, 0);
                }
            }
        }





    }

}
