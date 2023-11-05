using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class TextReading : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
      StartCoroutine(LoadNextSceneAfterDelay(10));  
    }

    // Update is called once per frame
    void Update()
    {
        //si toco enter o hago click que pase de escena sin esperar
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }


    IEnumerator LoadNextSceneAfterDelay(int delay)
    {
        yield return new WaitForSeconds(delay);

        // Load the next scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
