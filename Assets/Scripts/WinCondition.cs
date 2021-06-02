using UnityEngine;
using Zenject;

public class WinCondition : MonoBehaviour
{
    [Inject]
    private MainManager mainManager;
    private Doors doors;
    private bool informedAboutGameWon = false;

    private void Awake()
    {
        doors = GetComponent<Doors>();
    }

    private void Update()
    {
        if (informedAboutGameWon == false && doors.DoorsOpened) 
        {
            mainManager.WinGame();
            informedAboutGameWon = true;
        }
    }
}
