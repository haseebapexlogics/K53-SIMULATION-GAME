using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandChecker : MonoBehaviour
{
    public static StandChecker Instance;
    [HideInInspector] public bool isStand = false;


    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        BikeStandSetting.Instance.BikeStandBtn.SetActive(true);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.CompareTag("Player"))
        {
            if (!isStand)
            {
                AlertHandler.Instance.OnShowPopUp("Not Follow Road Rule", Color.red);
                BikeStandSetting.Instance.StopChecking = true;
            }
            GetComponent<BoxCollider>().enabled = false;
        }

    }

}
