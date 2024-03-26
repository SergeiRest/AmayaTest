using Finish;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI
{
    public class FinishScreenTemplate : MonoBehaviour
    {
        [SerializeField] private Button _restart;
        [SerializeField] private Image _background;

        private FinishBehavior _finishBehavior;
        
        [Inject]
        private void Construct(FinishBehavior finishBehavior)
        {
            _finishBehavior = finishBehavior;
            Sequence sequence = DOTween.Sequence();

            sequence.Append(_restart.image.DOFade(1f, 0.5f));
            sequence.Join(_background.DOFade(0.7f, 0.5f));

            sequence.OnComplete(() =>
            {
                _restart.interactable = true;
            });
            
            _restart.onClick.AddListener(Restart);
        }

        private async void Restart()
        {
            _restart.gameObject.SetActive(false);
            await _background.DOFade(1, 0.5f).AsyncWaitForCompletion();
            _finishBehavior.Clear();
            await _background.DOFade(0, 0.5f).AsyncWaitForCompletion();
            _finishBehavior.Restart();
            Destroy(gameObject);
        }
    }
}