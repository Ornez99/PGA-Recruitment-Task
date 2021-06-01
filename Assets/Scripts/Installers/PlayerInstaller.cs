using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class PlayerInstaller : MonoInstaller<PlayerInstaller>
{
    [SerializeField]
    private Transform playerTransform;
    [SerializeField]
    private InputActionAsset controls;
    

    public override void InstallBindings()
    {
        System.Type[] typesFrom = new System.Type[2] { typeof(IController) , typeof(IMoveable) };
        System.Type[] typesTo = new System.Type[2] { typeof(NewUnityInputSystemController), typeof(DefaultMovement) };
        Container.Bind(typesFrom).To(typesTo).AsSingle();
        Container.Bind<Rigidbody>().FromComponentInHierarchy().AsTransient();
        Container.Bind<Transform>().WithId("movementTransform").FromInstance(playerTransform);
        Container.Bind<InputActionAsset>().FromInstance(controls).AsSingle();
        
        //Container.Bind<IController>().WithId("Interactable detector controller").To<IController>();
    }
}
