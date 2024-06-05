using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsDisabler : MonoBehaviour
{
    public GameObject[] ObjectsToBeDisable;
    public GameObject[] ObjectsToBeEnable;
    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.parent.CompareTag("Player"))
        {
            transform.GetComponent<BoxCollider>().enabled = false;
            if (ObjectsToBeDisable.Length > 0)
            {
                for (int i = 0; i < ObjectsToBeDisable.Length; i++)
                {
                    ObjectsToBeDisable[i].SetActive(false);
                }
            }
            if (ObjectsToBeEnable.Length > 0)
            {
                for (int i = 0; i < ObjectsToBeEnable.Length; i++)
                {
                    ObjectsToBeEnable[i].SetActive(true);
                }
            }


        }
    }
}
