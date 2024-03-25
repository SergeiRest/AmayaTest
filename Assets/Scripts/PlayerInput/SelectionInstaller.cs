using Zenject;

namespace PlayerInput
{
    public class SelectionInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<SelectionService>().FromNew().AsSingle().NonLazy();
        }
    }
}