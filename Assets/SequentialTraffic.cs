using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequentialTraffic : MonoBehaviour
{

    
    public GameObject[] AiCars;

    public bool Sign;
    public bool Rule;


     
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.CompareTag("Player"))
        {
            AccidentalTraffic.Instance.isAccidentalTrafficOn = true;
            AccidentalTraffic.Instance.Sign = Sign;
            AccidentalTraffic.Instance.Rule = Rule;


            StartCoroutine(TurnOnSequentialTraffic());
        }
    }


    IEnumerator TurnOnSequentialTraffic()
    {
        yield return new WaitForSeconds(1f);

        for (int i = 0; i < AiCars.Length; i++)
        {
            AiCars[i].SetActive(true);
            yield return new WaitForSeconds(2f);
        }



    }






}
