using UnityEngine;
using DG.Tweening;

namespace DOTweenAnimation
{
    public class RightWrongChoicePanelElementAnimation : MonoBehaviour
    {
        public void RightAnswerAnimation()
        {
            var sequance = DOTween.Sequence();

            sequance.Append(transform.DOScale(1.2f, 1f));
            sequance.Append(transform.DOScale(1f, 1f));
            sequance.SetLoops(-1);
        }

        public void WrongAnswerAnimation()
        {
            transform.DOPunchPosition(Vector3.right * 10, 1.5f, 3, 5).SetEase(Ease.InBounce);
        }
    }
}
