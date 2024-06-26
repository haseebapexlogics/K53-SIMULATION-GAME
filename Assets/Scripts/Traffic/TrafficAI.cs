using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SWS;

public class TrafficAI : MonoBehaviour
{
    public bool Movement = false;

    public Transform RayCastInitPoint;

    public bool isBike = false;


    RaycastHit hit;

    public GameObject[] BikeTires;

    void CheckNearbyVehicles()
    {
        //Debug.Log("Done");

        if (Physics.Raycast(RayCastInitPoint.position, RayCastInitPoint.transform.forward, out hit, 3000f))
        {

            Debug.DrawRay(RayCastInitPoint.position, RayCastInitPoint.forward, Color.blue);
            //Debug.Log("Hit = " + hit.transform.name);
            //Debug.Log("Hit dist = " + hit.distance);
            if (hit.transform.gameObject.CompareTag("TrafficVehicle") || hit.transform.root.CompareTag("Player"))
            {
               //Debug.Log("Hit = " + hit.transform.name);
               //Debug.Log("Hit dist = " + hit.distance);
                if (hit.distance <= 5)
                {
                    this.gameObject.GetComponent<splineMove>().Pause();
                    if (!isBike)
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            this.gameObject.transform.GetChild(i).gameObject.GetComponent<TyreRotation>().enabled = false;
                        }
                    }
                    else if (isBike)
                    {
                        BikeTires[0].GetComponent<TyreRotation>().enabled = false;
                        BikeTires[1].GetComponent<TyreRotation>().enabled = false;
                    }
                    
                }
                else
                {
                    this.gameObject.GetComponent<splineMove>().Resume();
                    if (!isBike)
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            this.gameObject.transform.GetChild(i).gameObject.GetComponent<TyreRotation>().enabled = true;
                        }
                    }
                    else if (isBike)
                    {
                        BikeTires[0].GetComponent<TyreRotation>().enabled = true;
                        BikeTires[1].GetComponent<TyreRotation>().enabled = true;
                    }

                }
            }
            else
            {
                if (!Movement)
                {

                    this.gameObject.GetComponent<splineMove>().Pause();
                    if (!isBike)
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            this.gameObject.transform.GetChild(i).gameObject.GetComponent<TyreRotation>().enabled = false;
                        }
                    }
                    else if (isBike)
                    {
                        BikeTires[0].GetComponent<TyreRotation>().enabled = false;
                        BikeTires[1].GetComponent<TyreRotation>().enabled = false;
                    }

                }
                else if (Movement)
                {
                    this.gameObject.GetComponent<splineMove>().Resume();
                    if (!isBike)
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            this.gameObject.transform.GetChild(i).gameObject.GetComponent<TyreRotation>().enabled = true;
                        }
                    }
                    else if (isBike)
                    {
                        BikeTires[0].GetComponent<TyreRotation>().enabled = true;
                        BikeTires[1].GetComponent<TyreRotation>().enabled = true;
                    }

                }
                //this.gameObject.GetComponent<splineMove>().Resume();

            }

            //if (!Movement)
            //{
            //    this.gameObject.GetComponent<splineMove>().Pause();
            //}
            //else if (Movement)
            //{
            //    this.gameObject.GetComponent<splineMove>().Resume();

            //}

        }

    }

    private void Update()
    {
        CheckNearbyVehicles();

    }

    

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.root.CompareTag("Player"))
        {
            
            if (AccidentalTraffic.Instance.isAccidentalTrafficOn)
            {
                if (AccidentalTraffic.Instance.Rule)
                {
                    AlertHandler.Instance.OnShowPopUp("Road Rule Not Followed", Color.red);
                    AccidentalTraffic.Instance.isAccidentalTrafficOn = false;
                }
                else if (AccidentalTraffic.Instance.Sign)
                {
                    AlertHandler.Instance.OnShowPopUp("Sign Rule Not Followed", Color.red);
                    AccidentalTraffic.Instance.isAccidentalTrafficOn = false;
                }
            }
            else
            {
                return;
            }
        }
        else
        {
            return;
        }
    }
}
