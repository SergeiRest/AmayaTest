using UnityEngine;
using UnityEngine.U2D;

namespace GameData
{
    [CreateAssetMenu(fileName = "SpriteData", menuName = "Data/Sprites")]
    public class SpritesData : ScriptableObject
    {
        [field: SerializeField] public SpriteAtlas[] Atlases { get; private set; }
    }
}