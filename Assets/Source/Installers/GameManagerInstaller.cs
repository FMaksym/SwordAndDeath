using UnityEngine;
using Zenject;

public class GameManagerInstaller : MonoInstaller
{
    [SerializeField] private GameManager _gameManger;

    public override void InstallBindings()
    {
        Container.Bind<GameManager>().FromInstance(_gameManger).AsSingle();
    }
}