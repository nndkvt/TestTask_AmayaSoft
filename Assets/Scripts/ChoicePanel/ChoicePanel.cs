using DOTweenAnimation;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ChoicePanel
{
    public class ChoicePanel : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private ChoicePanelElementSet _elementImage;

        private RightWrongChoicePanelElementAnimation _elementAnimation;

        private ObjectToFind _panelObject;

        private Task.Task _assignedTask;

        public void Init(ObjectToFind obj, Task.Task assignedTask)
        {
            SetObjectToFind(obj);

            _assignedTask = assignedTask;

            _elementAnimation = _elementImage.gameObject.GetComponent<RightWrongChoicePanelElementAnimation>();
        }

        private void SetObjectToFind(ObjectToFind obj)
        {
            _panelObject = obj;

            _elementImage.SetElement(_panelObject);
        }

        public ObjectToFind GetObjectToFind()
        {
            return _panelObject;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            _assignedTask.CheckTaskCompleted(this);
        }

        public void RightAnswer()
        {
            _elementAnimation.RightAnswerAnimation();
        }

        public void WrongAnswer()
        {
            _elementAnimation.WrongAnswerAnimation();
        }
    }
}
