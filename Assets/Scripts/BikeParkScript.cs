using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeParkScript : MonoBehaviour
{
    public static BikeParkScript Instance;

    public bool isParkDone = false;

    private void Start()
    {
        Instance = this;
    }

    public void BikeParkBtnClicked()
    {
        isParkDone = true;
    }

}
