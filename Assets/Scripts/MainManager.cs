using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class MainManager : MonoBehaviour
{
    [SerializeField]
    private GameObject StartGameObject;
    [Inject]
    private TimeManager timeManager;

    public bool GameStarted { get; set; }

    [SerializeField]
    private GameObject tryAgainGO;

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
        timeManager.IfTimeIsBestSaveIt();
        timeManager.DisplayBestTime();
        DisplayTryAgainWindow();
    }

    private void DisableStartUI()
    {
        StartGameObject.SetActive(false);
    }

    private void DisplayTryAgainWindow()
    {
        tryAgainGO.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Game");
    }

}
