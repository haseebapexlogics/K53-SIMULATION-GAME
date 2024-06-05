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
        if (Physics.Raycast(RayCastInitPoint.position, Vector3.forward, out hit))
        {
            // Debug.Log("Hit = " + hit.transform.gameObject.name);

            // Debug.DrawRay(RayCastInitPoint.position, transform.forward, Color.blue);


            if (hit.transform.gameObject.CompareTag("TrafficVehicle") && hit.distance <= 5 || !Movement)
            {
                this.gameObject.GetComponent<splineMove>().Pause();
            }
            else if (hit.transform.gameObject.CompareTag("TrafficVehicle") == false && hit.distance > 5 || Movement)
            {
                this.gameObject.GetComponent<splineMove>().Resume();
            }
        }

    }

    private void Update()
    {
        CheckNearbyVehicles();

    }
}
