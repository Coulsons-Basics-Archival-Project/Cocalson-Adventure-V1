using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        IEnumerator end()
        {
            yield return new WaitForSeconds(25f);
            SceneManager.LoadSceneAsync("MainMenu");
        }

        StartCoroutine(end());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
