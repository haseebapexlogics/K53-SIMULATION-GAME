using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeIndicators : MonoBehaviour
{
    public GameObject LeftIndicatorLight;

    public GameObject RightIndicatorLight;

    public GameObject HeadLight;

    bool HeadLightCheck = false;

    bool Left = false;

    bool Right = false;

    bool hazard = false;



    public void HeadLightSwitch()
    {
        if (!HeadLightCheck)
        {
            HeadLight.SetActive(true);
            HeadLightCheck = true;
        }
        else if (HeadLightCheck)
        {
            HeadLight.SetActive(false);
            HeadLightCheck = false;
        }
    }

    public void LeftIndicator()
    {
        if (!Left)
        {
            StartCoroutine(LeftIndi());
            Left = true;

            StopCoroutine(RightIndi());
            Right = false;

            StopCoroutine(HazardIndi());
            hazard = false;
        }
        else if (Left)
        {
            StopCoroutine(LeftIndi());
            Left = false;
        }


    }

    public void RightIndicator()
    {
        if (!Right)
        {
            StartCoroutine(RightIndi());
            Right = true;

            StopCoroutine(LeftIndi());
            Left = false;

            StopCoroutine(HazardIndi());
            hazard = false;
        }
        else if (Right)
        {
            StopCoroutine(RightIndi());
            Right = false;
        }
    }

    public void HazardIndicator()
    {
        if (!hazard)
        {
            StartCoroutine(HazardIndi());
            hazard = true;

            StopCoroutine(LeftIndi());
            Left = false;

            StopCoroutine(RightIndi());
            Right = false;
        }
        else if (hazard)
        {
            StopCoroutine(HazardIndi());
            hazard = false;
        }
    }

    IEnumerator LeftIndi()
    {
        LeftIndicatorLight.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        LeftIndicatorLight.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        if (Left)
        {
            StartCoroutine(LeftIndi());
        }
    }


    IEnumerator RightIndi()
    {
        RightIndicatorLight.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        RightIndicatorLight.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        if (Right)
        {
            StartCoroutine(RightIndi());
        }
    }

    IEnumerator HazardIndi()
    {
        RightIndicatorLight.SetActive(true);
        LeftIndicatorLight.SetActive(true);

        yield return new WaitForSeconds(0.5f);
        RightIndicatorLight.SetActive(false);
        LeftIndicatorLight.SetActive(false);

        yield return new WaitForSeconds(0.5f);
        if (hazard)
        {
            StartCoroutine(HazardIndi());
        }
    }

}
