using UnityEngine;
using UnityEngine.UI;

namespace GameGrid
{
    public class GridTemplate : MonoBehaviour
    {
        [SerializeField] private GridLayoutGroup _gridLayoutGroup;

        public void SetSize(int width, int height)
        {
            _gridLayoutGroup.cellSize = new Vector2(width, height);
        }
    }
}