using System;
using UnityEngine;
using UnityEngine.U2D;

namespace GameData
{
    [CreateAssetMenu(fileName = "SpriteData", menuName = "Data/Sprites")]
    public class SpritesData : ScriptableObject
    {
        [field: SerializeField] public SpriteContainer[] Containers { get; private set; }
    }
    
    [Serializable]
    public struct SpriteContainer
    {
        public SpriteConfig[] Configs;
    }

    [Serializable]
    public struct SpriteConfig
    {
        public Sprite Sprite;
        public Vector3 rotation;
    }
}