using UnityEngine;
using UnityEngine.UI;

namespace GameGrid
{
    public class CellTemplate : MonoBehaviour
    {
        [SerializeField] private Image _main;

        public void Init(Sprite sprite)
        {
            _main.sprite = sprite;
        }
    }
}