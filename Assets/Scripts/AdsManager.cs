using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using GoogleMobileAds.Api;
//[RequireComponent(typeof(UnityAds))]

public class AdsManager : MonoBehaviour
{



    //private AppOpenAd adAppOpen;
    public static AdsManager Instance;
    ////Live
   
    private string bannerIDR = "ca-app-pub-1270794040007434/8647341580";
    private string interstitialID = "ca-app-pub-1270794040007434/1291595749";
    private AdPosition Small_Top_Right_Pos = AdPosition.Top;
   
    [SerializeField]
    private bool enableTestMode;
    //Banner Views
    private BannerView Small_Banner_View_Right_Top;
    public InterstitialAd interstitial;

    //Check Internet and Intitalization
    public bool iConnected = false;
    private bool isAdInitialized = false;
    bool AdmobRewardedLoaded;

    public static bool isLowEndDevice = false;
    bool CanShowRewarded;
    bool AdmobLoaded;
  
    private void Awake()
    {

        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        if (Instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        isLowEndDevice = IsLowDevice();

        checkintervaltimeInternet = 20;
        StartCoroutine(CheckInternet(checkintervaltimeInternet));
    }
    bool IsLowDevice()
    {
        bool isLow = false;
        int mem;
        mem = SystemInfo.systemMemorySize;
        if (mem <= 2000)
        {
            isLow = true;
        }
        return isLow;
    }

    private bool CheckInitialization()
    {
        if (isAdInitialized)
        {
            isAdInitialized = true;
            return isAdInitialized;
        }
        else
        {
            isAdInitialized = false;
            InitializeAds();
            return false;
        }

    }
    float CheckintervalInternet;
    public float checkintervaltimeInternet
    {
        get { return CheckintervalInternet; }
        set { CheckintervalInternet = value; }
    }
    public bool internetUrgentCheck;

    public bool iConnectedConnection()
    {
        if (Application.internetReachability != NetworkReachability.NotReachable)
        {
            iConnected = true;
        }
        else
            iConnected = false;

        return iConnected;
    }
    IEnumerator CheckInternet(float checktime)
    {
        yield return new WaitForSeconds(checktime);
        if (Application.internetReachability != NetworkReachability.NotReachable)
        {
            iConnected = true;

            if (internetUrgentCheck)
            {
                // We are back online


              
            }
        }
        else
        {
            iConnected = false;

        }
        if (!internetUrgentCheck)
        {
            checkintervaltimeInternet = 20;
        }
        else
        {
            checkintervaltimeInternet = 2;
        }
        StartCoroutine(CheckInternet(checkintervaltimeInternet));
    }
    private void Start()
    {
        try
        {



           
            if (enableTestMode)
            {       
                bannerIDR = "ca-app-pub-3940256099942544/6300978111";   
                interstitialID = "ca-app-pub-3940256099942544/1033173712";       
            }

            if (iConnectedConnection())
            {
                InitializeAds();
            }
            else
                isAdInitialized = false;
        }
        catch
        {
            // Debug.Log(exe);

        }
    }
    void InitializeAds()
    {
        MobileAds.Initialize(initStatus => { });
        isAdInitialized = true;
        AdmobLoaded = true;

        //temp
        if (!InAppsDataContainer.Instance.ProModeUnlocked)
        {
            try
            {
                Small_Banner_Req_Right_Top();

            }
            catch
            {
                // Debug.Log(exe);

            }  
           try
            {
                RequestInterstitial();

            }
            catch
            {
                // Debug.Log(exe);

            }
        }
       
       

    }
    private AdRequest CreateAdRequest()
    {
        return new AdRequest.Builder().Build();
    }
  

    public void Small_Banner_Req_Right_Top()
    {


        if (Small_Banner_View_Right_Top != null)
        {
            Small_Banner_View_Right_Top.Destroy();
        }
        Small_Banner_View_Right_Top = new BannerView(bannerIDR, AdSize.Banner, Small_Top_Right_Pos);
        Small_Banner_View_Right_Top.OnBannerAdLoaded += HandleOnBannerAdLoaded;
        Small_Banner_View_Right_Top.OnBannerAdLoadFailed += HandleOnBannerAdFailedToLoad;
        AdRequest request = new AdRequest();
        Small_Banner_View_Right_Top.LoadAd(request);
        Small_Banner_View_Right_Top.Hide();
    }

    public void HandleOnBannerAdLoaded()
    {
    }
    public void HandleOnBannerAdFailedToLoad(LoadAdError obj)
    {
       
    }

    public void ShowBanner()
    {
        //temp
        if (!InAppsDataContainer.Instance.ProModeUnlocked)


        {
            if (iConnectedConnection())
            {
                if (CheckInitialization())
                {
                    try
                    {
                       // Banner_Setting("STL");
                        Small_Banner_View_Right_Top.Show();
                    }
                    catch
                    {
                        // Debug.Log(exe);
                    }
                }
            }
        }
    }



    public void HideBanner()
    {
       
        
            try
            {
                if (CheckInitialization())
                    Small_Banner_View_Right_Top.Hide();
            }
            catch
            {
                // Debug.Log(exe);

            }
        
    }

    //Request Interstitial and Show
    private void RequestInterstitial()
    {
        if (interstitial != null)
        {
            interstitial.Destroy();
        }
        AdRequest request = new AdRequest();
        InterstitialAd.Load(interstitialID, request, (ad, error) =>
        {
            interstitial = ad;
            interstitial.OnAdFullScreenContentClosed += HandleOnInterstitialAdClosed;
            interstitial.OnAdFullScreenContentFailed += InterstitialAdOnOnAdFullScreenContentFailed;
        });

    }
    private void InterstitialAdOnOnAdFullScreenContentFailed(AdError obj)
    {
      
    }

    public virtual void HandleOnInterstitialAdClosed()
    {    
        RequestInterstitial();
    }

    public void ShowInterstitial()
    {

        //temp
        if (!InAppsDataContainer.Instance.ProModeUnlocked)


        {
            if (iConnectedConnection())
            {
                if (CheckInitialization())
                {
                    try
                    {
                        if (interstitial.CanShowAd())
                        {
                            interstitial.Show();
                        }
                    }
                    catch
                    {
                        // Debug.Log(exe);

                    }
                }
            }
        }
    }


    public void HandleInterstitialLoaded(object sender, EventArgs args)
    {

    }
    public void HandleInterstitialClosed(object sender, EventArgs args)
    {
        try
        {
            RequestInterstitial();
           
        }
        catch
        {
            // Debug.Log(exe);
        }
    }



}

