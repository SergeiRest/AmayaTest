using UnityEngine;
using Zenject;
using Grid = GameGrid.Grid;

namespace DefaultNamespace
{
    public class GameStartup : MonoBehaviour
    {
        [Inject] private Grid _grid;

        private void Start()
        {
            _grid.Generate();
        }
    }
}