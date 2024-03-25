using GameGrid.Cells;

namespace PlayerInput
{
    public class SelectionService
    {
        private bool _canSelect = true;
        
        public void Select(ICell cell)
        {
            if(!_canSelect)
                return;

            _canSelect = false;
            cell.Select(() =>_canSelect = true);
        }
    }
}