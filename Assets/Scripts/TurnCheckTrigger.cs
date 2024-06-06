using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnCheckTrigger : MonoBehaviour
{
    public bool EntryPoint;
    public bool RightDirection;
    public bool WrongDirection;
    public string FollowString;
    public string UnfollowString;
    public bool Sign;
    public bool Rule;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.CompareTag("Player"))
        {
            if (EntryPoint)
            {
                GetComponent<BoxCollider>().enabled = false;
                //Can Be Use For Hint
            }
            if (RightDirection)
            {
                AlertHandler.Instance.OnShowPopUp(FollowString,Color.green);
                GetComponent<BoxCollider>().enabled = false;
                transform.parent.gameObject.SetActive(false);
                if (Sign)
                {
                    GameManager.Instance.NumberOfSignsFollowed++;
                }
                if (Rule)
                {
                    GameManager.Instance.NumberOfRulesFollowed++;
                }
                

            }
            if (WrongDirection)
            {
                AlertHandler.Instance.OnShowPopUp(UnfollowString, Color.red);
                GetComponent<BoxCollider>().enabled = false;
                transform.parent.gameObject.SetActive(false);

            }
        }
    }


}
