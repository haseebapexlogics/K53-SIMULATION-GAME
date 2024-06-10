using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildrenCheck : MonoBehaviour
{
    public GameObject SaveChildBtn;

    public GameObject Child;

    bool once = false;

    public void SaveChildrenBtnClicked()
    {
        if (!once)
        {
            AlertHandler.Instance.OnShowPopUp("Road Rule Followed", Color.green);
            GameManager.Instance.NumberOfRulesFollowed++;
            SaveChildBtn.SetActive(false);
            Child.SetActive(false);

            once = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.CompareTag("Player"))
        {
            if (!once)
            {
                AlertHandler.Instance.OnShowPopUp("Road Rule Not Followed", Color.red);
            }
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
            SaveChildBtn.SetActive(false);
            Child.SetActive(false);

        }
    }
}
