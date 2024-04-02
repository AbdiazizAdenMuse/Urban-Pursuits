using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitions : MonoBehaviour
{
    public Animator transitionAnum;
    public string SceneName;

    private Timer timer; // Reference to the Timer script

    void Start()
    {
        // Find the Timer script attached to any GameObject in the scene
        timer = FindObjectOfType<Timer>();
    }

    void Update()
    {
        // Check if the Timer script is found and the elapsed time is greater than 10f
        if (timer != null && timer.elapsedTime > 1000f)
        {
            StartCoroutine(LoadSceneCoroutine());
        }
    }

    IEnumerator LoadSceneCoroutine()
    {
        transitionAnum.SetTrigger("end");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneName);
    }
}
