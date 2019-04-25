using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string sceneToLoad;

    //private void OnTriggerEnter(Collider other)
    //{
    //    if(other.tag == "Player")
    //    {
    //        SceneManager.LoadScene(sceneToLoad, LoadSceneMode.Single);
    //    }
    //}

    public void LoadSceneOnTimer(float timer)
    {
        StartCoroutine(IELoadSceneOnTimer(timer));
    }

    IEnumerator IELoadSceneOnTimer(float timer)
    {
        yield return new WaitForSeconds(timer);
        SceneManager.LoadScene(sceneToLoad, LoadSceneMode.Single);
    }
}

