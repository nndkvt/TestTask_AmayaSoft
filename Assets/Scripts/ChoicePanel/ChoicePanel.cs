using DOTweenAnimation;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace ChoicePanel
{
    public class ChoicePanel : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private ChoicePanelElementSet _elementImage;

        [SerializeField] private RightWrongChoicePanelElementAnimation _elementAnimation;

        [SerializeField] private GameObject _completionStar;

        private ObjectToFind _objectToFind;

        public UnityAction<ChoicePanel> OnClick;

        public void SetObjectToFind(ObjectToFind obj)
        {
            _objectToFind = obj;

            _elementImage.SetElement(_objectToFind);
        }

        public ObjectToFind GetObjectToFind()
        {
            return _objectToFind;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            OnClick?.Invoke(this);
        }

        public void RightAnswer()
        {
            _elementAnimation.RightAnswerAnimation();
            _completionStar.SetActive(true);
        }

        public void WrongAnswer()
        {
            _elementAnimation.WrongAnswerAnimation();
        }
    }
}
