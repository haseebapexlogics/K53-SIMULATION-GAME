using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SeatbeltChecker : MonoBehaviour
{
    public static SeatbeltChecker Instance;
    [HideInInspector] public bool isSeatBelt = false;


    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        SeatBeltSetting.Instance.SeatBeltBtn.SetActive(true);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.CompareTag("Player"))
        {
            //if (isSeatBelt)
            //{
            //    AlertHandler.Instance.OnShowPopUp("SeatBelt Test Complete !!!", Color.green);
            //}
            if (!isSeatBelt)
            {
                AlertHandler.Instance.OnShowPopUp("SeatBelt error !!!", Color.red);
                SeatBeltSetting.Instance.StopChecking = true;
            }
            GetComponent<BoxCollider>().enabled = false;
        }

    }



}
