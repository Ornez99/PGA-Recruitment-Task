using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardController : IController
{
    public Vector3 MovementVector3
    {
        get => new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
    }

    public float RotationStrength
    {
        get
        {
            if (Input.GetKey(KeyCode.Q))
                return -1;
            else if (Input.GetKey(KeyCode.E))
                return 1;
            else
                return 0;
        }
    }

    public GameObject HoveredGameObject => throw new NotImplementedException();

    public bool MouseClicked => throw new NotImplementedException();

    public void Tick()
    {
        throw new NotImplementedException();
    }
}
