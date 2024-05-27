using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RestScrollView : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }


    private void OnEnable()
    {
        GetComponent<ScrollRect>().verticalNormalizedPosition = 1f;
    }
}
