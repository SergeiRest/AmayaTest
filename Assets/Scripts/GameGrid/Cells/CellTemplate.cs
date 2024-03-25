﻿using System;
using GameGrid.Cells;
using PlayerInput;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

namespace GameGrid
{
    public class CellTemplate : MonoBehaviour, IPointerDownHandler
    {
        [Inject] private SelectionService _selectionService;

        [field: SerializeField] private Image _main;

        private ICell current;
        
        private CellAnimation _animation = new CellAnimation();

        public void OnPointerDown(PointerEventData eventData)
        {
            _selectionService.Select(current);
        }
        
        public void Init(Sprite sprite, ICell cell)
        {
            _main.sprite = sprite;
            current = cell;
        }

        public void Clear()
        {
            Destroy(gameObject);
        }

        public void AnimateMovement(Action callback)
            => _animation.PlayBounce(_main.transform, callback);

        public void PlayAppear() => _animation.PlayAppear(_main.transform);
    }
}