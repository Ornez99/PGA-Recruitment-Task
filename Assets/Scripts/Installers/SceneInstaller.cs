using UnityEngine;
using Zenject;

public class SceneInstaller : MonoInstaller<SceneInstaller>
{
    [SerializeField] private WindowFactory windowFactory;
    [SerializeField] private GameObject chestPrefab;
    [SerializeField] private GameObject keyPrefab;
    [SerializeField] private GameObject doorsPrefab;
    [SerializeField] private Map map;
    [SerializeField] private MainManager mainManager;
    [SerializeField] private TimeManager timeManager;

    public override void InstallBindings()
    {
        Container.Bind<MainManager>().FromInstance(mainManager);
        Container.Bind<TimeManager>().FromInstance(timeManager);
        Container.Bind<Map>().FromInstance(map);
        Container.Bind<WindowFactory>().FromInstance(windowFactory);

        Container.BindFactory<Key, Key.Factory>().FromComponentInNewPrefab(keyPrefab);
        Container.BindFactory<Doors, Doors.Factory>().FromComponentInNewPrefab(doorsPrefab);
        Container.BindFactory<Chest, Chest.Factory>().FromComponentInNewPrefab(chestPrefab);
    }
}
