using UI;
using UnityEngine;
using Zenject;

namespace Finish
{
    public class FinishInstaller : MonoInstaller
    {
        [SerializeField] private FinishScreenTemplate _finishScreenTemplate;
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<FinishBehavior>().FromNew().AsSingle().WithArguments(_finishScreenTemplate).NonLazy();
        }
    }
}