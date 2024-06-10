using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SWS;

public class TrafficAI : MonoBehaviour
{
    public bool Movement = false;

    public Transform RayCastInitPoint;


    RaycastHit hit;



    void CheckNearbyVehicles()
    {
        if (Physics.Raycast(RayCastInitPoint.position, RayCastInitPoint.transform.forward, out hit, 25f))
        {

            Debug.DrawRay(RayCastInitPoint.position, transform.forward, Color.blue);

            if (hit.transform.gameObject.CompareTag("TrafficVehicle") || hit.transform.root.CompareTag("Player"))
            {
            //    Debug.Log("Hit = " + hit.transform.name);
            //    Debug.Log("Hit dist = " + hit.distance);
                if (hit.distance <= 5)
                {
                    this.gameObject.GetComponent<splineMove>().Pause();
                    for (int i = 0; i < 4; i++)
                    {
                        this.gameObject.transform.GetChild(i).gameObject.GetComponent<TyreRotation>().enabled = false;
                    }
                }
                else
                {
                    this.gameObject.GetComponent<splineMove>().Resume();
                    for (int i = 0; i < 4; i++)
                    {
                        this.gameObject.transform.GetChild(i).gameObject.GetComponent<TyreRotation>().enabled = true;
                    }
                }
            }
            else
            {
                Debug.Log("Here");

                if (!Movement)
                {
                    Debug.Log("Here2");

                    this.gameObject.GetComponent<splineMove>().Pause();
                }
                else if (Movement)
                {
                    Debug.Log("Here3");

                    this.gameObject.GetComponent<splineMove>().Resume();

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
}
