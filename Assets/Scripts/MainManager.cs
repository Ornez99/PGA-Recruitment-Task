using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    [SerializeField]
    private GameObject StartGameObject;
    [Inject]
    private TimeManager timeManager;
    [SerializeField] private SaveManager saveManager;

    public bool GameStarted { get; set; }

    [SerializeField]
    private GameObject tryAgainGO;
    [SerializeField]
    private Text text_opinion;
    [SerializeField]
    private GameObject gratulationsGO;

    public void StartGame()
    {
        DisableStartUI();
        timeManager.RestartCurrentTime();
        timeManager.StartCountingTime();
        GameStarted = true;
    }

    public void WinGame()
    {
        timeManager.StopCountingTime();
        DisplayTryAgainWindow();
        timeManager.IfTimeIsBestSaveIt();
        timeManager.DisplayBestTime();
    }

    private void DisableStartUI()
    {
        StartGameObject.SetActive(false);
    }

    private void DisplayTryAgainWindow()
    {
        tryAgainGO.SetActive(true);
        string opinion = $"Twój czas to: {timeManager.CurrentTime}";
        opinion += $"\nNajpeszy czas to: {timeManager.BestTime}";
        if(timeManager.CurrentTime >= timeManager.BestTime)
        {
            opinion += "\nNiestety, nie udalo Ci sie osiagnac lepszego czasu :(";
            gratulationsGO.SetActive(false);
        }
        else
        {
            opinion += "\nSuper! Rekord nalezy do Ciebie!";
        }

        text_opinion.text = opinion;
    }

    public void RestartGame()
    {
        saveManager.Save();
        SceneManager.LoadScene("Game");
    }
}
