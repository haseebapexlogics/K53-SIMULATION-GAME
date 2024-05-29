using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SeatbeltChecker : MonoBehaviour
{
    public static SeatbeltChecker Instance;
    [HideInInspector] public bool isSeatBelt;



    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isSeatBelt)
        {
            Debug.Log("SeatBelt pehna hua");
            return;
        }
        else if (!isSeatBelt)
        {
            AlertHandler.Instance.AlertPopUp.SetActive(true);
            AlertHandler.Instance.AlertPopUp.GetComponent<Image>().color = Color.red;
            AlertHandler.Instance.AlertText.text = "SeatBelt error !!!";
        }
    }

    public void SetSeatbeltTrue()
    {
        isSeatBelt = true;
        AlertHandler.Instance.AlertPopUp.SetActive(true);
        AlertHandler.Instance.AlertPopUp.GetComponent<Image>().color = Color.green;
        AlertHandler.Instance.AlertText.text = "SeatBelt Done !!!";
    }

}
