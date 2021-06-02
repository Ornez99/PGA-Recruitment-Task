using UnityEngine;
using Zenject;

public class SceneInstaller : MonoInstaller<SceneInstaller>
{
    [SerializeField]
    private TwoOptionsWindowFactory twoOptionsWindowFactory;
    [SerializeField]
    private OneOptionWindowFactory oneOptionWindowFactory;
    [SerializeField]
    private MainManager mainManager;
    [SerializeField]
    private TimeManager timeManager;

    public override void InstallBindings()
    {
        Container.Bind<TwoOptionsWindowFactory>().FromInstance(twoOptionsWindowFactory);
        Container.Bind<OneOptionWindowFactory>().FromInstance(oneOptionWindowFactory);
        Container.Bind<MainManager>().FromInstance(mainManager);
        Container.Bind<TimeManager>().FromInstance(timeManager);
    }
}
