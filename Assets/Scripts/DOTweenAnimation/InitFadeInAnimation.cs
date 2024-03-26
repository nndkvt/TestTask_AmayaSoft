using UnityEngine;
using DG.Tweening;

namespace DOTweenAnimation
{
    public class InitFadeInAnimation : MonoBehaviour
    {
        private void Awake()
        {
            CanvasGroup canvasGroup = GetComponent<CanvasGroup>();

            canvasGroup.DOFade(1, 1.5f);
        }
    }
}
