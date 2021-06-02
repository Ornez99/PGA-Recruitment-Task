using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    [SerializeField]
    private FloatVariable bestTime;
    [SerializeField]
    private FloatVariable currentTime;
    [SerializeField]
    private Text bestTimeText;
    [SerializeField]
    private Text currentTimeText;
    private bool countTheTime;

    private void Awake()
    {
        bestTimeText.text = $"Najlepszy czas:{bestTime.Value}";
    }

    private void Update()
    {
        if (countTheTime)
        {
            currentTime.Value += Time.deltaTime;
            currentTimeText.text = $"Twój czas:{currentTime.Value}";
        }
    }

    public void RestartCurrentTime()
    {
        currentTime.Value = 0;
    }

    public void IfTimeIsBestSaveIt()
    {
        if (currentTime.Value < bestTime.Value)
        {
            bestTime.Value = currentTime.Value;
        }
    }

    public void DisplayBestTime()
    {
        bestTimeText.text = $"Najlepszy czas:{bestTime.Value}";
    }

    public void StartCountingTime()
    {
        countTheTime = true;
    }

    public void StopCountingTime()
    {
        countTheTime = false;
    }
}
