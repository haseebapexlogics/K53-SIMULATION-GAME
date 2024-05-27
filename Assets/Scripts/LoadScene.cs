using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadMainMenu());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator LoadMainMenu()
    {
        yield return new WaitForSecondsRealtime(2);
        SceneManager.LoadSceneAsync("MainMenu");
    }
}
