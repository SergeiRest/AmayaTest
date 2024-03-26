using UI;
using GameGrid;
using GameTarget;
using Zenject;

namespace Finish
{
    public class FinishBehavior
    {
        [Inject] private DiContainer _diContainer;
        [Inject] private GridCreator _gridCreator;
        [Inject] private Target _target;
        
        private FinishScreenTemplate _finishScreen;

        public FinishBehavior(FinishScreenTemplate finishScreen)
        {
            _finishScreen = finishScreen;
        }
        
        public void Show()
        {
            _diContainer.InstantiatePrefabForComponent<FinishScreenTemplate>(_finishScreen);
        }

        public void Clear()
        {
            _target.Clear();
            _gridCreator.Dispose();
        }

        public void Restart()
        {
            _gridCreator.StartGame();
            _target.Show();
        }
    }
}