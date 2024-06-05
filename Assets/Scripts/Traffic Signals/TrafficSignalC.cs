using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SWS;

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
    public bool isPedestriansAvailable = false;
    public bool isTrafficAvailable = false;


    public GameObject[] Pedestrians;
    public GameObject[] TrafficCars;









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
        if (other.transform.root.CompareTag("Player"))
        {
            StartCoroutine(StartSignal());
            GetComponent<BoxCollider>().enabled = false;
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
        if (isPedestriansAvailable)
        {
            for (int i = 0; i < Pedestrians.Length; i++)
            {
                Pedestrians[i].GetComponent<splineMove>().StartMove();
            }
        }
        //if (isTrafficAvailable)
        //{
        //    for (int i = 0; i < TrafficCars.Length; i++)
        //    {
        //        TrafficCars[i].GetComponent<splineMove>().Pause();
        //    }
        //}

        Signalindex = 1;


        yield return new WaitForSeconds(13f);

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
        //if (isTrafficAvailable)
        //{
        //    for (int i = 0; i < TrafficCars.Length; i++)
        //    {
        //        TrafficCars[i].GetComponent<splineMove>().Resume();
        //    }
        //}
        Signalindex = 3;
        
        StartCoroutine(TrafficSignal1.GetComponent<TrafficSignalC>().StartSignal());
        TrafficSignal1.GetComponent<BoxCollider>().enabled = false;
        TrafficSignal1.transform.Find("Signal Checker").gameObject.SetActive(false);
        TrafficSignal1.transform.Find("Zebra Checker").gameObject.SetActive(false);


        yield return new WaitForSeconds(10f);

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
        //if (isTrafficAvailable)
        //{
        //    for (int i = 0; i < TrafficCars.Length; i++)
        //    {
        //        TrafficCars[i].GetComponent<splineMove>().Pause();
        //    }
        //}
        Signalindex = 1;

        //yield return new WaitForSeconds(36f);

        //StartCoroutine(StartSignal());
    }
}
