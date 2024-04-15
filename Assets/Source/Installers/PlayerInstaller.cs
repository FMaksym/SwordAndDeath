using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField] private PlayerData _playerData;

    public override void InstallBindings()
    {
        Container.Bind<PlayerData>().FromInstance(_playerData).AsSingle();
    }
}