using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class RadioButtonsManager : MonoBehaviour
{
    public Toggle[] radioButtons;
    private Toggle lastSelected;

    private void Start()
    {
        // Initialize radio buttons
        foreach (Toggle radioButton in radioButtons)
        {
            radioButton.onValueChanged.AddListener(delegate { RadioButtonToggled(radioButton); });
        }
        RadioButtonToggled(radioButtons[0]);
    }

    private void RadioButtonToggled(Toggle selectedRadioButton)
    {
        if (selectedRadioButton.isOn)
        {
            // Deselect other radio buttons
            foreach (Toggle radioButton in radioButtons)
            {
                if (radioButton != selectedRadioButton)
                {
                    radioButton.isOn = false;
                }
            }
            lastSelected = selectedRadioButton;
        }
        else if (lastSelected == selectedRadioButton)
        {
            // Ensure one option is always selected
            StartCoroutine(Debounce(selectedRadioButton));
        }
    }

    private IEnumerator Debounce(Toggle toggle)
    {
        yield return new WaitForEndOfFrame(); // Wait for the current frame to end

        if (!toggle.isOn && lastSelected == toggle)
        {
            toggle.isOn = true;
        }
    }
}
