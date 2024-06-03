using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadLightUI : MonoBehaviour
{
    public static HeadLightUI Instance;
    public Light DirectionalLight;
    public Color LightColor;
    public Color DardColor;
    [HideInInspector]public bool HeadLightCheck;
    bool HeadLightRuleFollowed;
    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    public void DoDark(float transitionDuration)
    {
        StartCoroutine(TransitionColor(DirectionalLight.color, DardColor, transitionDuration));
    }
    public void DoLight(float transitionDuration)
    {
        StartCoroutine(TransitionColor(DirectionalLight.color, LightColor, transitionDuration));
    }

    private IEnumerator TransitionColor(Color startColor, Color targetColor, float duration)
    {
        float elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            DirectionalLight.color = Color.Lerp(startColor, targetColor, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        DirectionalLight.color = targetColor; 
    }
    public void OnTrigger()
    {
        DoDark(2);
        HeadLightCheck = true;
    }
    public void OnExit()
    {
        if (HeadLightRuleFollowed)
        {
            AlertHandler.Instance.OnShowPopUp("Light lamp Rule Follow", Color.green);
        }
        else
        {
            AlertHandler.Instance.OnShowPopUp("Light lamp Rule Not Follow", Color.red);
        }
    }
    public void ClickOnHeadLight()
    {
        if (HeadLightCheck)
        {
            HeadLightCheck = false;
            HeadLightRuleFollowed = true;
            //AlertHandler.Instance.OnShowPopUp("Light lamp Sign Follow",Color.green);
        }
    }
}
