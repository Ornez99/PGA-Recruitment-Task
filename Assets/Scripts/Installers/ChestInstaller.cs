using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ChestInstaller : MonoInstaller<ChestInstaller>
{
    public override void InstallBindings()
    {
        //Container.Bind<TwoOptionsWindowFactory>().FromInstance(controls).AsSingle();
    }
}
