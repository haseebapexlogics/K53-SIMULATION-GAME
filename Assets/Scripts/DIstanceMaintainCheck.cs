using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DIstanceMaintainCheck : MonoBehaviour
{
    public float maxDistance = 10f; // Maximum distance to cast the ray
    public LayerMask aiCarLayer; // Layer mask for the AI car objects
    bool StopChecking;
    // Start is called before the first frame update
    void Start()
    {
        StopChecking = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!StopChecking)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistance, aiCarLayer))
            {
                // Check if the ray hit an AI car
                if (hit.collider.transform.GetComponent<TrafficAI>())
                {
                    // Calculate the distance from the player/object to the AI car
                    float distanceToAICar = hit.distance;
                    // Debug.Log("Distance to AI car: " + distanceToAICar);

                    // You can also get reference to the AI car object if needed
                    //  GameObject aiCar = hit.collider.gameObject;
                    // Do something with the AI car object if needed
                    if (distanceToAICar <= 5)
                    {
                        StopChecking = true;
                        AlertHandler.Instance.OnShowPopUp("You Don't Maintain Proper Distance",Color.red);
                        Destroy(GetComponent<DIstanceMaintainCheck>());
                    }
                }
            }
        }
        
    }
}
