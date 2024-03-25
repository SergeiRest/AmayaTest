using System;
using DG.Tweening;
using UnityEngine;

namespace GameGrid.Cells
{
    public class IncorrectCell : ICell
    {
        private CellTemplate _cellTemplate;
        private CellAnimation _animation = new CellAnimation();

        public CellTemplate CellTemplate => _cellTemplate;

        public IncorrectCell(CellTemplate template)
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
            });
        }
    }
}