using System;
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
        
        private List<SpriteConfig> _selectedData;
        private List<string> _selectedSprites = new List<string>();

        public void SelectAtlas(int length)
        {
            var availableAtlases = _spritesData.Containers.Where(container => container.Configs.Length >= length).ToArray();
            SpriteContainer selected = availableAtlases.GetRandomValue();

            //Sprite[] sprites = new Sprite[selected.SpriteDatas.Length];

            SpriteConfig[] value = new SpriteConfig[selected.Configs.Length];
            Array.Copy(selected.Configs, value, selected.Configs.Length);
            
            _selectedData = value.ToList();
        }

        public SpriteConfig GetNecessarySprite()
        {
            SpriteConfig config = _selectedSprites.Count > 0
                ? _selectedData.Where(cur => !_selectedSprites.Contains(cur.Sprite.name)).ToList().GetRandomValue()
                : _selectedData.GetRandomValue();
            
            _selectedSprites.Add(config.Sprite.name);
            _selectedData.Remove(config);

            return config;
        }

        public SpriteConfig GetRandom()
        {
            SpriteConfig config = _selectedData.GetRandomValue();
            _selectedData.Remove(config);

            return config;
        }
    }
}