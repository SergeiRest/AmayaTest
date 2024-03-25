using GameGrid;
using UnityEngine;
using Zenject;

namespace DefaultNamespace
{
    public class GameStartup : MonoBehaviour
    {
        [Inject] private GridCreator _gridCreator;

        private void Start()
        {
            _gridCreator.StartGame();
        }
    }
}