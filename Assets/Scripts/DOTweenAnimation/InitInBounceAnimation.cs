using UnityEngine;
using DG.Tweening;

namespace DOTweenAnimation
{
    public class InitInBounceAnimation : MonoBehaviour
    {
        private void Awake()
        {
            transform.localScale = Vector3.zero;
        }

        private void Start()
        {
            transform.DOScale(1, 1).SetEase(Ease.OutBounce);
        }
    }
}
