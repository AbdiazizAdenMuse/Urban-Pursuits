using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timeText;
   
    // [SerializeField] string difficulty;
    public float elapsedTime = 0.0f;
    float easyLevel = 30f;
    float mediumLevel = 10f;
    float hardLevel = 15f;
   
    // Update is called once per frame
   void Update()
    {
        elapsedTime += Time.deltaTime;
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);
        timeText.text = string.Format("{0:00}:{1:00}",minutes,seconds);

        if (elapsedTime > easyLevel)
        {
            timeText.color = Color.red;
            timeText.color = Color.clear;
        }
        /**
        if (elapsedTime > mediumLevel)
        {
            timeText.color = Color.red;
            timeText.color = Color.clear;
        }

        if (elapsedTime > hardLevel)
        {
            timeText.color = Color.red;
            timeText.color = Color.clear;
        }
       */
    }

    public void easyDifficulty ()
    {
        
        
    }
    public void mediumDifficulty()
    {
      

    }
}
