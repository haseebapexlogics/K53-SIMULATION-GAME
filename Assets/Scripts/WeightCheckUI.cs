using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeightCheckUI : MonoBehaviour
{
    public Text[] WeightButtonTexts;
    [HideInInspector]public string Option1;
    [HideInInspector] public string Option2;
    [HideInInspector] public string Option3;
    [HideInInspector] public string CurrentOption;
    [HideInInspector] public string CorrectOption;
    [HideInInspector] public string StartStatementString;
    [HideInInspector] public string EndStatementString;
    [HideInInspector] public bool WeightCheck;
    [HideInInspector] public bool HeightCheck;
    [HideInInspector] public bool LenghtCheck;
    public GameObject WeightPanel;
    public GameObject CheckingPanel;
    public Button ApplyBtn;
    public static WeightCheckUI Instance;
    public Text QuestionStatementText;
    public Text CheckingStatementText;
    public GameObject [] ItemsInVehicle;
    
    
    public GameObject Carriage;
    [HideInInspector] public string value1;
    [HideInInspector] public string value2;
    [HideInInspector] public string value3;
    [HideInInspector] public string ValueChosen;
    public Image FillImage;
    public Text ResultText;
    // Start is called before the first frame update
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        ApplyBtn.interactable = false;
    }
    public void ClickOnWeightBtn1()
    {
        CurrentOption = Option1;
        ValueChosen = value1;
        ApplyBtn.interactable = true;
        ShowPhysicalAppearance(0);
    }

    public void ClickOnWeightBtn2()
    {
        CurrentOption = Option2;
        ValueChosen = value2;
        ApplyBtn.interactable = true;
        ShowPhysicalAppearance(1);
    }
    public void ClickOnWeightBtn3()
    {
        CurrentOption = Option3;
        ValueChosen = value3;
        ApplyBtn.interactable = true;
        ShowPhysicalAppearance(2);
    }


    public void ShowPhysicalAppearance(int n)
    {
        for (int i = 0; i < 3; i++)
        {
            ItemsInVehicle[i].SetActive(false);
        }
        ItemsInVehicle[n].SetActive(true);
        if (LenghtCheck)
        {
            Carriage.SetActive(false);
        }
    }




    public void ClickOnApplyButton()
    {
        WeightPanel.SetActive(false);
        GameManager.Instance.CurrentPlayer.transform.GetComponent<Rigidbody>().isKinematic = false;
    }

    public void OnStartTrigger()
    {
        WeightButtonTexts[0].text = Option1.ToString();
        WeightButtonTexts[1].text = Option2.ToString();
        WeightButtonTexts[2].text = Option3.ToString();
        ApplyBtn.interactable = false;
        WeightPanel.SetActive(true);
        QuestionStatementText.text = StartStatementString;
        GameManager.Instance.CurrentPlayer.transform.GetComponent<Rigidbody>().isKinematic = true;
    }

    public void OnEndTrigger()
    {
        GameManager.Instance.CurrentPlayer.transform.GetComponent<Rigidbody>().isKinematic = true;
        CheckingStatementText.text = EndStatementString;
        CheckingPanel.SetActive(true);
        StartCoroutine(WieghtChecking());
    }
    IEnumerator WieghtChecking()
    {
        float duration = 2f; // Duration over which the image will fill
        float elapsedTime = 0f; // Time that has passed since the coroutine started

        // Ensure the fill amount is reset before starting the animation
        FillImage.fillAmount = 0f;

        // Gradually increase the fill amount over the duration
        while (elapsedTime < duration)
        {
            FillImage.fillAmount = Mathf.Lerp(0f, 1f, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null; // Wait for the next frame
        }

        // Ensure the fill amount is set to 1 after the loop
        FillImage.fillAmount = 1f;

        yield return new WaitForSeconds(2);
        ResultText.gameObject.SetActive(true);
        ResultText.text =  ValueChosen;
      
        yield return new WaitForSeconds(2);
        CheckingPanel.SetActive(false);
        GameManager.Instance.CurrentPlayer.transform.GetComponent<Rigidbody>().isKinematic = false;
        ResultText.gameObject.SetActive(false);
        for (int i = 0; i < 3; i++)
        {
            ItemsInVehicle[i].SetActive(false);
        }
        Carriage.SetActive(true);
       
        if (CurrentOption == CorrectOption)
        {
            GameManager.Instance.NumberOfRulesFollowed++;
            AlertHandler.Instance.OnShowPopUp("Rule Followed", Color.green);
        }
        else
        {
            AlertHandler.Instance.OnShowPopUp("Rule Not Followed", Color.red);
        }
    }
   
}


