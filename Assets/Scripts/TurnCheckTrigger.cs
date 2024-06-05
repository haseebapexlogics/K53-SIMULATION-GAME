using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnCheckTrigger : MonoBehaviour
{
    public bool EntryPoint;
    public bool RightDirection;
    public bool WrongDirection;
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
                AlertHandler.Instance.OnShowPopUp("You take turn on good direction",Color.green);
                GetComponent<BoxCollider>().enabled = false;
                transform.parent.gameObject.SetActive(false);

            }
            if (WrongDirection)
            {
                AlertHandler.Instance.OnShowPopUp("You take turn on wrong direction", Color.red);
                GetComponent<BoxCollider>().enabled = false;
                transform.parent.gameObject.SetActive(false);

            }
        }
    }


}
