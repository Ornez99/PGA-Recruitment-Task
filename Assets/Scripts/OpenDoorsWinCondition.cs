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

    void Start()
    {
        Doors doors = GetComponent<Doors>();
        doors.ChangeDoorStateEvent += mainManager.WinGame;
    }
}