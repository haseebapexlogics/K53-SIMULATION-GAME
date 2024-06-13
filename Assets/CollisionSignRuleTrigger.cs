using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSignRuleTrigger : MonoBehaviour
{

    public bool Sign = false;
    public bool Rule = false;

    public string CollisionText;

    public GameObject GameobjectTurnOff;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.CompareTag("Player"))
        {
            GameobjectTurnOff.SetActive(false);

            AlertHandler.Instance.OnShowPopUp(CollisionText ,Color.green);

            if (Sign)
            {
                GameManager.Instance.NumberOfSignsFollowed++;
            }
            else if (Rule)
            {
                GameManager.Instance.NumberOfRulesFollowed++;
            }
        }
    }



}
