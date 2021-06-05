using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

public class WindowDisplayer : MonoBehaviour
{
    private WindowFactory windowFactory;
    private bool isOpened;
    private GameObject currentWindow;

    public List<Window> Windows;

    [Inject]
    private void Construct(WindowFactory windowFactory)
    {
        this.windowFactory = windowFactory;
    }

    public void ShowWindow(int windowId)
    {
        if (windowId < 0 || windowId >= Windows.Count)
            return;

        if(isOpened == false)
        {
            currentWindow = windowFactory.CreateWindow(Windows[windowId]);
            isOpened = true;
        }
    }

    public void CloseWindow()
    {
        if(isOpened == true && currentWindow != null)
        {
            Destroy(currentWindow);
            isOpened = false;
        }
    }
}
