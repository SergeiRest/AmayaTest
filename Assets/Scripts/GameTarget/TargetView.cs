using DG.Tweening;
using TMPro;
using UnityEngine;
using Zenject;

namespace GameTarget
{
    public class TargetView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _targetDescription;
        
        private Target _target;

        [Inject]
        private void Construct(Target target)
        {
            Show();
            _target = target;
            _targetDescription.text = _target.Desciption;

            _target.OnTargetChanged += UpdateTarget;
            _target.TargetCleared += Clear;
            _target.OnTargetShown += Show;
        }
        
        private void OnDestroy()
        {
            _target.OnTargetChanged -= UpdateTarget;
        }

        private void Clear()
        {
            _targetDescription.text = "";
            _targetDescription.DOFade(0, 0f);
        }

        private void UpdateTarget(string value)
        {
            _targetDescription.text = value;
        }

        private void Show() 
            => _targetDescription.DOFade(1, 1f).SetEase(Ease.Linear);
    }
}