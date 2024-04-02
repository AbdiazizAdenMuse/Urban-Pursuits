using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnClick : MonoBehaviour
{
    // Start is called before the first frame update
    public void quitGame()
    {
        Application.Quit();
    }

    // Update is called once per frame
    public void startGame()
    {
       SceneManager.LoadScene(1);
    }
}
