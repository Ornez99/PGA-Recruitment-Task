using UnityEngine;
using Zenject;

public class SceneInstaller : MonoInstaller<SceneInstaller>
{
    [SerializeField]
    private GameObject chestPrefab;
    [SerializeField]
    private GameObject keyPrefab;
    [SerializeField]
    private GameObject doorsPrefab;
    [SerializeField]
    private Map map;

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
        Container.Bind<Map>().FromInstance(map);

        Container.BindFactory<Chest, Chest.Factory>().FromComponentInNewPrefab(chestPrefab);
        Container.BindFactory<Key, Key.Factory>().FromComponentInNewPrefab(keyPrefab);
        Container.BindFactory<Doors, Doors.Factory>().FromComponentInNewPrefab(doorsPrefab);
        
    }
}
