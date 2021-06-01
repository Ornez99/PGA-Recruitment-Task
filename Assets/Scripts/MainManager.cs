using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    [SerializeField]
    private GameObject StartGameObject;
    [SerializeField]
    private TimeManager timeManager;

    public bool GameStarted { get; set; }

    public void StartGame()
    {
        DisableStartUI();
        timeManager.RestartCurrentTime();
        timeManager.StartCountingTime();
    }

    private void DisableStartUI()
    {
        StartGameObject.SetActive(false);
    }

}
