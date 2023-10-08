using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    public float countTime;
    private float currentTime;

    public TextMeshProUGUI countText;

    private bool isCount;

    private void Start()
    {
        currentTime = countTime;
    }

    private void Update()
    {
        if (isCount)
        {
            currentTime -= 1 * Time.unscaledDeltaTime;
            countText.text = currentTime.ToString("F0");

            if(currentTime <= 0)
            {
                isCount = false;
                countText.gameObject.SetActive(false);
                Time.timeScale = 1;
                currentTime = countTime;
            }
        }
    }

    public void StartCount()
    {
        countText.gameObject.SetActive(true);
        Time.timeScale = 0;
        isCount = true;
    }
}
