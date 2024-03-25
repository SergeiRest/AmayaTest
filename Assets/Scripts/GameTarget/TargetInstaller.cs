using Zenject;

namespace GameTarget
{
    public class TargetInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<Target>().FromNew().AsSingle().NonLazy();
        }
    }
}