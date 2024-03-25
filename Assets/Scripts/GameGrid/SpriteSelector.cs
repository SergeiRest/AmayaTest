using System.Collections.Generic;
using System.Linq;
using GameData;
using UnityEngine;
using UnityEngine.U2D;
using Zenject;

namespace GameGrid
{
    public class SpriteSelector
    {
        [Inject] private SpritesData _spritesData;
        
        private List<Sprite> _availableSprites;
        private List<string> _selectedSprites = new List<string>();

        public void SelectAtlas(int length)
        {
            var availableAtlases = _spritesData.Atlases.Where(atlas => atlas.spriteCount >= length).ToArray();
            SpriteAtlas spriteAtlas = availableAtlases.GetRandomValue();

            Sprite[] sprites = new Sprite[spriteAtlas.spriteCount];
            spriteAtlas.GetSprites(sprites);

            _availableSprites = sprites.ToList();
        }

        public Sprite GetNecessarySprite()
        {
            Sprite sprite = _availableSprites.Count > 0
                ? _availableSprites.Where(cur => !_selectedSprites.Contains(cur.name)).ToList().GetRandomValue()
                : _availableSprites.GetRandomValue();
            
            _selectedSprites.Add(sprite.name);
            _availableSprites.Remove(sprite);
            
            return sprite;
        }

        public Sprite GetRandom()
        {
            Sprite sprite = _availableSprites.GetRandomValue();
            _availableSprites.Remove(sprite);

            return sprite;
        }
    }
}