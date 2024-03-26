using UnityEngine;
using DG.Tweening;

namespace DOTweenAnimation
{
    public class RestartScreenAnimation : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _restartBG;

        [SerializeField] private CanvasGroup _restartButton;

        private void OnEnable()
        {
            var sequance = DOTween.Sequence();

            sequance.Append(_restartBG.DOFade(1, 1));
            sequance.Append(_restartButton.DOFade(1, 1));
        }
    }
}
