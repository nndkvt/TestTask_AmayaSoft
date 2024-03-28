using UnityEngine;
using DG.Tweening;

namespace DOTweenAnimation
{
    public class InitFadeInAnimation : MonoBehaviour
    {
        CanvasGroup _canvasGroup;

        private void Awake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();

            _canvasGroup.DOFade(1, 1.5f);
        }

        private void OnDestroy()
        {
            DOTween.Kill(_canvasGroup);
        }
    }
}
