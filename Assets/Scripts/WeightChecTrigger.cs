using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightChecTrigger : MonoBehaviour
{
    public bool EnteryPoint;
    public bool ExitPoint;
    public string Option1;
    public string Option2;
    public string Option3;
    public string CorrectOption;
    public string value1;
    public string value2;
    public string value3;
    public bool WeightImplementation;
    public bool HeightImplementation;
    public bool LenghtImplementation;
    public string OntriggerStartText;
    public string OntriggerEndText;
    WeightCheckUI WeightCheckUIInstance;
    public GameObject[] ItemsInVehicle;

    void Start()
    {
        WeightCheckUIInstance = WeightCheckUI.Instance;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.CompareTag("Player"))
        {
          
            GetComponent<BoxCollider>().enabled = false;
            if (EnteryPoint)
            {
                WeightCheckUIInstance.value1 = value1;
                WeightCheckUIInstance.value2 = value2;
                WeightCheckUIInstance.value3 = value3;

                for (int i = 0; i < ItemsInVehicle.Length; i++)
                {
                    WeightCheckUIInstance.ItemsInVehicle[i] = ItemsInVehicle[i];
                }

                if (WeightImplementation)
                {
                    WeightCheckUIInstance.LenghtCheck = false;
                    WeightCheckUIInstance.WeightCheck = true;
                    WeightCheckUIInstance.HeightCheck = false;
                }
                else if (HeightImplementation)
                {
                    WeightCheckUIInstance.LenghtCheck = false;
                    WeightCheckUIInstance.WeightCheck = false;
                    WeightCheckUIInstance.HeightCheck = true;
                }
                else if (LenghtImplementation)
                {
                    WeightCheckUIInstance.LenghtCheck = true;
                    WeightCheckUIInstance.WeightCheck = false;
                    WeightCheckUIInstance.HeightCheck = false;
                }

                WeightCheckUIInstance.Option1 = Option1;
                WeightCheckUIInstance.Option2 = Option2;
                WeightCheckUIInstance.Option3 = Option3;
                WeightCheckUIInstance.StartStatementString = OntriggerStartText;
                WeightCheckUIInstance.OnStartTrigger();
            }
            if (ExitPoint)
            {
                WeightCheckUIInstance.CorrectOption = CorrectOption;
                WeightCheckUIInstance.EndStatementString = OntriggerEndText;
                WeightCheckUIInstance.OnEndTrigger();
            }
           
           
        }
    }

}
