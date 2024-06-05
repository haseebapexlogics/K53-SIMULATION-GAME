using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficSignal : MonoBehaviour
{
    public static TrafficSignal Instance;

    public GameObject Red;
    public GameObject Yellow;
    public GameObject Green;

    public GameObject WalkRed;
    public GameObject WalkGreen;
    public GameObject WalkParent;


    public bool isZebraCrossingAvailable = false;

    [HideInInspector] public int Signalindex;

    // Start is called before the first frame update
    void Start()
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
            StartCoroutine(SignalStart());
        }
    }



    IEnumerator SignalStart()
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

        yield return new WaitForSeconds(10f);

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



        yield return new WaitForSeconds(10f);

        Red.SetActive(false);
        Yellow.SetActive(true);
        Green.SetActive(false);
        Signalindex = 2;

        yield return new WaitForSeconds(2f);


        StartCoroutine(SignalStart());

    }


}
