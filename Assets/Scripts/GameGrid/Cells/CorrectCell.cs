using System;
using Zenject;

namespace GameGrid.Cells
{
    public class CorrectCell : ICell
    {
        [Inject] private UpgradeService _upgradeService;
        
        private CellTemplate _cellTemplate;

        public CellTemplate CellTemplate => _cellTemplate;

        public CorrectCell(CellTemplate template)
        {
            _cellTemplate = template;
        }

        public void Dispose()
        {
            _cellTemplate.Clear();
        }


        public void Select(Action callback)
        {
            _cellTemplate.AnimateMovement(() =>
            {            
                callback?.Invoke();
                _upgradeService.Upgrade();
            });
        }
    }
}