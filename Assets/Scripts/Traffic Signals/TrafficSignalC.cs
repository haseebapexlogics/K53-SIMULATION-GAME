using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficSignalC : MonoBehaviour
{
    public static TrafficSignalC Instance;

    public GameObject TrafficSignal1;
    public GameObject TrafficSignal2;
    public GameObject TrafficSignal3;


    public GameObject Red;
    public GameObject Yellow;
    public GameObject Green;

    public GameObject WalkRed;
    public GameObject WalkGreen;
    public GameObject WalkParent;


    public bool isZebraCrossingAvailable = false;

    [HideInInspector] public int Signalindex;


    private void Start()
    {
        Instance = this;
        if (!isZebraCrossingAvailable)
        {
            WalkRed.SetActive(false);
            WalkGreen.SetActive(false);
            WalkParent.SetActive(false);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent.CompareTag("Player"))
        {
            StartCoroutine(StartSignal());
        }
    }


    public IEnumerator StartSignal()
    {
        Red.SetActive(true);
        Yellow.SetActive(false);
        Green.SetActive(false);
        if (isZebraCrossingAvailable)
        {
            WalkGreen.SetActive(true);
            WalkRed.SetActive(false);
        }
        Signalindex = 1;


        yield return new WaitForSeconds(7f);

        Red.SetActive(false);
        Yellow.SetActive(true);
        Green.SetActive(false);
        Signalindex = 2;



        yield return new WaitForSeconds(2f);

        Red.SetActive(false);
        Yellow.SetActive(false);
        Green.SetActive(true);
        if (isZebraCrossingAvailable)
        {
            WalkGreen.SetActive(false);
            WalkRed.SetActive(true);
        }
        Signalindex = 3;
        
        StartCoroutine(TrafficSignal1.GetComponent<TrafficSignalC>().StartSignal());
        TrafficSignal1.GetComponent<BoxCollider>().enabled = false;
        TrafficSignal1.transform.Find("Signal Checker").gameObject.SetActive(false);
        TrafficSignal1.transform.Find("Zebra Checker").gameObject.SetActive(false);


        yield return new WaitForSeconds(7f);

        Red.SetActive(false);
        Yellow.SetActive(true);
        Green.SetActive(false);
        Signalindex = 2;

        yield return new WaitForSeconds(2f);

        Red.SetActive(true);
        Yellow.SetActive(false);
        Green.SetActive(false);
        if (isZebraCrossingAvailable)
        {
            WalkGreen.SetActive(true);
            WalkRed.SetActive(false);
        }
        Signalindex = 1;

        //yield return new WaitForSeconds(36f);

        //StartCoroutine(StartSignal());
    }
}
