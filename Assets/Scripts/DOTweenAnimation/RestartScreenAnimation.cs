using UnityEngine;
using DG.Tweening;

namespace DOTweenAnimation
{
    public class RestartScreenAnimation : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _restartBG;

        [SerializeField] private CanvasGroup _restartButton;

        private Sequence _sequance;

        private void OnEnable()
        {
            _sequance = DOTween.Sequence();

            _sequance.Append(_restartBG.DOFade(1, 1));
            _sequance.Append(_restartButton.DOFade(1, 1));
        }

        private void OnDestroy()
        {
            DOTween.Kill(_sequance);
        }
    }
}
