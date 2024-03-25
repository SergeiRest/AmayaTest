using UnityEngine;
using Zenject;

namespace GameData
{
    public class DataInstaller : MonoInstaller
    {
        [SerializeField] private DifficultyData _difficultyData;
        [SerializeField] private SpritesData _spritesData;
        
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<DifficultyData>().FromInstance(_difficultyData).AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<SpritesData>().FromInstance(_spritesData).AsSingle().NonLazy();
        }
    }
}