using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BikeEngineSetting : MonoBehaviour
{
    public static BikeEngineSetting Instance;

    public GameObject BikeEngineBtn;

    public GameObject[] EngineONItems;

    private void Awake()
    {
        Instance = this;
    }

    public void SetBikeEngineTrue()
    {
        BikeEngineBtn.SetActive(false);
        AlertHandler.Instance.OnShowPopUp("Control Rule Followed !", Color.green);
        GameManager.Instance.NumberOfControlsFollowed++;
        for (int i = 0; i < EngineONItems.Length; i++)
        {
            EngineONItems[i].SetActive(true);
        }


    }
}
