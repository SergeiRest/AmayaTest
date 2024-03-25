using System.Collections.Generic;
using GameData;
using UnityEngine;
using Zenject;

namespace GameGrid
{
    public class Grid
    {
        [Inject] private CellsFactory _cellsFactory;
        [Inject] private DifficultyData _difficultyData;
        [Inject] private SpriteSelector _spriteSelector;

        private GridTemplate _template;
        
        private List<ICell> _cells = new List<ICell>();

        private int currentLevel = 0;

        public Grid(GridTemplate gridTemplate)
        {
            _template = gridTemplate;
            _template.SetSize(Screen.width / 8, Screen.width / 8);
        }
        
        public void Generate()
        {
            var difficulty = _difficultyData.Difficulties[currentLevel];
            CreateCells(difficulty);
        }

        private void CreateCells(Difficulty difficulty)
        {
            int correctPos = Random.Range(0, difficulty.CellsCount);
            _spriteSelector.SelectAtlas();

            for (int i = 0; i < difficulty.CellsCount; i++)
            {
                ICell cell;
                CellTemplate cellModel = _cellsFactory.Get();
                Sprite sprite = null;

                if (i == correctPos)
                {
                    cell = new CorrectCell();
                    sprite = _spriteSelector.GetNecessarySprite();
                }
                else
                {
                    cell = new IncorrectCell();
                    sprite = _spriteSelector.GetRandom();
                }
                
                cellModel.transform.SetParent(_template.transform);
                cellModel.Init(sprite);
                
                _cells.Add(cell);
            }
        }
    }
}