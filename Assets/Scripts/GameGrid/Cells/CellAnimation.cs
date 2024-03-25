using System;
using DG.Tweening;
using UnityEngine;

namespace GameGrid.Cells
{
    public class CellAnimation
    {
        public void PlayBounce(Transform body, Action callback)
        {
            Vector3 startPosition = body.transform.position;
            
            Sequence sequence = DOTween.Sequence();
            sequence.Append(body.DOMoveX
                (body.position.x - 5f, 0.1f).SetEase(Ease.InBounce));
            sequence.Append(body.DOMoveX
                (body.position.x + 5f, 0.1f).SetEase(Ease.InBounce));

            sequence.SetLoops(8);
            sequence.Play();

            sequence.OnComplete(() =>
            {
                body.DOMove(startPosition, 0.1f).OnComplete(() =>
                {
                    callback?.Invoke();
                });
            });
        }

        public void PlayAppear(Transform body)
        {
            Sequence sequence = DOTween.Sequence();
            body.localScale = Vector3.zero;

            sequence.Append(body.DOScale(new Vector3(1.2f, 1.2f, 1.2f), 0.5f));
            sequence.Append(body.DOScale(Vector3.one, 0.25f));

            sequence.Play();
        }
    }
}