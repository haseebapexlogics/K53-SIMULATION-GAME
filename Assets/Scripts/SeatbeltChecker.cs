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
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (isSeatBelt)
            {
                AlertHandler.Instance.OnShowPopUp("SeatBelt Test Complete !!!", Color.green);
            }
            else if (!isSeatBelt)
            {
                AlertHandler.Instance.OnShowPopUp("SeatBelt error !!!", Color.red);
            }
        }

    }



    public void SetSeatbeltTrue()
    {
        isSeatBelt = true;
        AlertHandler.Instance.OnShowPopUp("SeatBelt Done !!!", Color.green);
    }

}
