using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WindowFactory : MonoBehaviour
{
    public abstract GameObject CreateWindow(string title, string contents, WindowOption[] windowOptions);
}
