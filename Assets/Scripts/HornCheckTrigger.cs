
using UnityEngine;

public class HornCheckTrigger : MonoBehaviour
{
    public bool EntryPoint;
    public bool ExitPoit;
    // Start is called before the first frame update
    void Start()
    {
        HornCheckUI.Instance.HornBtn.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent.tag == "Player")
        {
            if (EntryPoint)
            {
                GetComponent<BoxCollider>().enabled = false;
                HornCheckUI.Instance.HornRuleCheck = true;
                

            }
            if (ExitPoit)
            {
                GetComponent<BoxCollider>().enabled = false;
                HornCheckUI.Instance.OnReachingEndPoint();


            }

        }
    }
}
