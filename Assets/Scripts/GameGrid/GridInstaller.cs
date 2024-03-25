using UnityEngine;
using Zenject;

namespace GameGrid
{
    public class GridInstaller : MonoInstaller
    {
        [SerializeField] private GridTemplate _gridTemplate;
        [SerializeField] private CellTemplate _cellTemplate;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<CellsFactory>().FromNew().AsSingle().WithArguments(_cellTemplate).NonLazy();
            Container.BindInterfacesAndSelfTo<Grid>().FromNew().AsSingle().WithArguments(_gridTemplate).NonLazy();
            Container.BindInterfacesAndSelfTo<SpriteSelector>().FromNew().AsSingle().NonLazy();
        }
    }
}