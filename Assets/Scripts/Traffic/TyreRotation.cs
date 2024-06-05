using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SWS;

public class TyreRotation : MonoBehaviour
{
    public float speed = 0f;

    private void Update()
    {
        if (this.gameObject.GetComponentInParent<TrafficAI>().Movement)
        {
            this.gameObject.transform.Rotate(0, Time.deltaTime * speed, 0, Space.Self);
        }
    }
}
