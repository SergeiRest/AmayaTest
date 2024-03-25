using Zenject;

namespace GameGrid
{
    public class CellsFactory
    {
        [Inject] private DiContainer _diContainer;
        
        private CellTemplate _template;
        
        public CellsFactory(CellTemplate template)
        {
            _template = template;
        }

        public CellTemplate Get() 
            => _diContainer.InstantiatePrefabForComponent<CellTemplate>(_template);
    }
}