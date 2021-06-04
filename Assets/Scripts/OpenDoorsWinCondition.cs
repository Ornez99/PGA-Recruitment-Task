using UnityEngine;
using Zenject;

public class OpenDoorsWinCondition : MonoBehaviour
{
    private MainManager mainManager;

    [Inject]
    private void Construct(MainManager mainManager)
    {
        this.mainManager = mainManager;
    }

    private void Start()
    {
        GetComponent<Doors>().ChangeDoorStateEvent += WinGame;
    }

    public void WinGame()
    {
        mainManager.WinGame();
    }
}