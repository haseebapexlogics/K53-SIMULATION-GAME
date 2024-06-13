using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarEngineTurnOffTriger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.CompareTag("Player"))
        {
            CarEngineTurnOff.Instance.Triggered = true;
            CarEngineTurnOff.Instance.CarEngineTurnOffFunc();
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
