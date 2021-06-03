using UnityEngine;
using Zenject;

public class QuitGame : MonoBehaviour
{
    [Inject]
    private TwoOptionsWindowFactory twoOptionsWindowFactory;

    private bool windowIsOpened = false;

    public void Quit()
    {
        if (windowIsOpened == false)
        {
            windowIsOpened = true;
            DisplayQuitGameWindow();
        }
    }

    private void DisplayQuitGameWindow()
    {
        WindowOption[] options = new WindowOption[2];
        options[0] = new WindowOption(QuitToWindows, "Tak");
        options[1] = new WindowOption(CloseWindow, "Nie");
        twoOptionsWindowFactory.CreateWindow("Wyjdz z gry", "Czy na pewno chcesz wyjsc z gry?", options);
    }

    private void CloseWindow()
    {
        windowIsOpened = false;
    }

    private void QuitToWindows()
    {
        Application.Quit();
    } 
}
