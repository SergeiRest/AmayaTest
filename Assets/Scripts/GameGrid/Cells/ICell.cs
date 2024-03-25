using System;

namespace GameGrid.Cells
{
    public interface ICell : IDisposable
    {
        public CellTemplate CellTemplate { get; }
        public void Select(Action callback);
    }
}