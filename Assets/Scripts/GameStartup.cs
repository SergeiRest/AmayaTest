using GameGrid;
using UnityEngine;
using Zenject;

public class GameStartup : MonoBehaviour
{
    [Inject] private GridCreator _gridCreator;

    private void Start()
    {
        _gridCreator.StartGame();
    }
}
