using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class loader : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] Text progressText;

    private float timeDelay = 8f;
    private float timeElapsed;
    private void Update()
    {
        timeElapsed += Time.deltaTime;
        

        if (timeElapsed > timeDelay)
        {

            StartCoroutine(loadAsynchronously(2));
        }
    }
    public void loadScene(int sceneIndex)
    {


    }

    IEnumerator loadAsynchronously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            progressText.text = progress * 100f + "%";
            yield return null;
        }
    }
}

