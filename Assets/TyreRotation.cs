using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SWS;

public class TyreRotation : MonoBehaviour
{
    private void Start()
    {
        this.gameObject.GetComponent<Rigidbody>().MoveRotation(Quaternion.Euler(360, 0, 90));


    }



}
