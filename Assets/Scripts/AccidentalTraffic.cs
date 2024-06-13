using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccidentalTraffic : MonoBehaviour
{
    public static AccidentalTraffic Instance;

    public bool isAccidentalTrafficOn = false;

    public bool Sign;
    public bool Rule;


    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
