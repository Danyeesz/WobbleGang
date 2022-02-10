using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StopWinningScreen : MonoBehaviour
{
    public void StopWinnigScreen()
    {
       gameObject.SetActive(false);
        SceneManager.LoadScene("MainMenu");
    }
}
