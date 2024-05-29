using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class AlertHandler : MonoBehaviour
{
    public GameObject AlertPopUp;
    public Text AlertText;
    public static AlertHandler Instance;
    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    public void OnShowPopUp(string text, Color clr)
    {
        AlertPopUp.SetActive(true);
        AlertText.text = text;
        AlertText.color = clr;
        StartCoroutine(DisablePopUp());
    }
    IEnumerator DisablePopUp()
    {
        yield return new WaitForSecondsRealtime(3);
        AlertPopUp.SetActive(false);
    }
    
}
