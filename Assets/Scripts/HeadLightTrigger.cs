using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadLightTrigger : MonoBehaviour
{
    public bool EntryPoint;
    public bool ExitPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.CompareTag("Player"))
        {
            if (EntryPoint)
            {
                GetComponent<BoxCollider>().enabled = false;
                //RenderSettings.ambientLight = new Color32(0,0,0,0);
                HeadLightUI.Instance.OnTrigger();
            }
            if (ExitPoint)
            {
                GetComponent<BoxCollider>().enabled = false;
                //RenderSettings.ambientLight = new Color32(150, 150, 150, 255);
                HeadLightUI.Instance.OnExit();
            }
        }
    }
}
