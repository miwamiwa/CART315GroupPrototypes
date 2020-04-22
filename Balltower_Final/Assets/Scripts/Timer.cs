using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public Image loadingSprite;
    public Text countdownText;
    public Text countdownTextShadow;
    private float timeRemaining;
    const int timerTotal = 20;

    private void Start()
    {
        timeRemaining = timerTotal;
        SetFillAmount();
        StartCoroutine(StartTimer());
    }
    
    private void SetFillAmount()
    {
        loadingSprite.fillAmount = timeRemaining / (timerTotal + (CurrentLvl.currentLvl*fallingcam.bonus));
        countdownText.text = Mathf.Round(timeRemaining).ToString();
        countdownTextShadow.text = Mathf.Round(timeRemaining).ToString();
    }

    private IEnumerator StartTimer()
    {
        while (timeRemaining > 0)
        {
            yield return new WaitForFixedUpdate();
            timeRemaining -= Time.fixedDeltaTime;
            SetFillAmount();
        }
        SceneManager.LoadScene("Bad End");
    }

    public void AddTime(float additionalTime)
    {
        timeRemaining = timerTotal + additionalTime;
    }
}
