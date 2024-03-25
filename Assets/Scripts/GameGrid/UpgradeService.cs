using Zenject;

namespace GameGrid
{
    public class UpgradeService
    {
        [Inject] private GridCreator _gridCreator;

        public void Upgrade() 
            => _gridCreator.Upgrade();
    }
}