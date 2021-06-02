using UnityEngine;
using Zenject;

public class OpenDoorsWinCondition : MonoBehaviour
{
    [Inject]
    private MainManager mainManager;

    void Start()
    {
        Doors doors = GetComponent<Doors>();
        doors.ChangeDoorStateEvent += mainManager.WinGame;
    }
}