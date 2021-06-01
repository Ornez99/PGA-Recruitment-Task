using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller<PlayerInstaller>
{
    [SerializeField]
    private Transform player;

    public override void InstallBindings()
    {
        System.Type[] typesFrom = new System.Type[2] { typeof(IController) , typeof(IMoveable) };
        System.Type[] typesTo = new System.Type[2] { typeof(NewUnityInputSystemController), typeof(DefaultMovement) };
        Container.Bind(typesFrom).To(typesTo).AsTransient();
        Container.Bind<Rigidbody>().FromComponentInHierarchy().AsTransient();
        Container.Bind<Transform>().FromComponentInHierarchy().AsTransient();
    }
}
