using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            //Do Nothing
        }
        else if (!isSeatBelt)
        {
            //Show Alert
        }
    }

    public void SetSeatbeltTrue()
    {
        isSeatBelt = true;
    }

}
