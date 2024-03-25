using System.Collections.Generic;
using GameData;
using GameGrid.Cells;
using GameTarget;
using UnityEngine;
using Zenject;

namespace GameGrid
{
    public class GridCreator
    {
        [Inject] private DifficultyData _difficultyData;
        [Inject] private DiContainer _diContainer;

        private GridTemplate _template;
        private CellInitializer _cellInitializer;
        
        private List<ICell> _cells = new List<ICell>();

        private int currentLevel = 0;

        [Inject]
        private void Construct()
        {
            _cellInitializer = new AppearenceCellInitializer();
            _diContainer.Inject(_cellInitializer);
        }

        public GridCreator(GridTemplate gridTemplate)
        {
            _template = gridTemplate;
            _template.SetSize(Screen.width / 8, Screen.width / 8);
        }

        public void StartGame()
        {
            Generate();
            _cellInitializer = new CellInitializer();
            _diContainer.Inject(_cellInitializer);
        }
        
        private void Generate()
        {
            var difficulty = _difficultyData.Difficulties[currentLevel];
            CreateCells(difficulty);
        }

        private void CreateCells(Difficulty difficulty)
        {
            _cellInitializer.Initialize(_cells, difficulty, _template.transform);
        }

        public void Upgrade()
        {
            currentLevel++;

            foreach (var cell in _cells)
            {
                cell.Dispose();
            }
            
            _cells.Clear();
            Generate();
        }
    }

    public class CellInitializer
    {
        [Inject] private SpriteSelector _spriteSelector;
        [Inject] private CellsFactory _cellsFactory;
        [Inject] private Target _target;
        [Inject] private DiContainer _diContainer;

        public virtual void Initialize(List<ICell> cells, Difficulty difficulty, Transform parent)
        {
            int correctPos = Random.Range(0, difficulty.CellsCount);
            _spriteSelector.SelectAtlas(difficulty.CellsCount);

            for (int i = 0; i < difficulty.CellsCount; i++)
            {
                ICell cell;
                CellTemplate cellModel = _cellsFactory.Get();
                cellModel.transform.SetParent(parent);
                
                Sprite sprite = null;

                if (i == correctPos)
                {
                    cell = new CorrectCell(cellModel);
                    sprite = _spriteSelector.GetNecessarySprite();
                    _target.Set(sprite.name);
                }
                else
                {
                    cell = new IncorrectCell(cellModel);
                    sprite = _spriteSelector.GetRandom();
                }
                
                _diContainer.Inject(cell);
                cellModel.Init(sprite, cell);
                cells.Add(cell);
            }
        }
    }

    public class AppearenceCellInitializer : CellInitializer
    {
        public override void Initialize(List<ICell> cells, Difficulty difficulty, Transform parent)
        {
            base.Initialize(cells, difficulty, parent);

            foreach (var cell in cells)
            {
                cell.CellTemplate.PlayAppear();
            }
        }
    }
}