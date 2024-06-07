using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SWS;

public class TyreRotation : MonoBehaviour
{
    public float speed = 0f;
    [HideInInspector] public bool Stop;
    private void Update()
    {
        if(!Stop)
        {

            if (this.gameObject.GetComponentInParent<TrafficAI>().Movement)//(this.gameObject.GetComponentInParent<splineMove>().IsMoving())
            {
                this.gameObject.transform.Rotate(0, Time.deltaTime * speed, 0, Space.Self);
            }
            else if (!this.gameObject.GetComponentInParent<TrafficAI>().Movement)
            {
                return;
            }
            else if (this.gameObject.GetComponentInParent<splineMove>().IsPaused())
            {
                return;
            }

            else
            {
                return;
            }
        }
       
    }
    public void StopKaro()
    {
        Stop = true;
    }
}
