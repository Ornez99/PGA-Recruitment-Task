using System;
using UnityEngine;
using Zenject;

public class QuitGame : MonoBehaviour
{
    public event Action QuitEvent;

    public void QuitToWindows()
    {
        if (QuitEvent != null)
            QuitEvent();
        Application.Quit();
    } 
}
