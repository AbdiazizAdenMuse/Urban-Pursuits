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
        // Placeholder for any scene loading logic you might need outside the time-based loading
    }

    IEnumerator loadAsynchronously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            int progressPercentage = Mathf.RoundToInt(progress * 100f); // Convert progress to whole number
            progressText.text = progressPercentage + "%"; // Display progress as whole number
            yield return null;
        }
    }
}
