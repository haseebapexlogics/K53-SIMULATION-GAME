using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadioButtonDummyBehavior : MonoBehaviour
{
    public Button[] Buttons;
    // Start is called before the first frame update
    void Start()
    {
        foreach (Button radioButton in Buttons)
        {
            radioButton.onClick.AddListener(delegate { RadioButtonToggled(radioButton); });
        }
    }

    private void RadioButtonToggled(Button selectedRadioButton)
    {
      //  Debug.Log(selectedRadioButton);
        foreach (Button radioButton in Buttons)
        {
            radioButton.transform.GetChild(0).transform.GetChild(0).transform.GetComponent<Image>().enabled = false;
        }
        selectedRadioButton.transform.GetChild(0).transform.GetChild(0).transform.GetComponent<Image>().enabled = true;
    }
}
