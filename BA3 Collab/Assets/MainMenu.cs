using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        StartCoroutine(delayForLoadingScene());
    }

    IEnumerator delayForLoadingScene() 
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("CharSelection 1");

    }
}
