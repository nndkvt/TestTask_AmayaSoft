using DOTweenAnimation;
using UnityEngine;
using UnityEngine.UI;

namespace ChoicePanel
{
    [RequireComponent(typeof(RightWrongChoicePanelElementAnimation))]
    public class ChoicePanelElementSet : MonoBehaviour
    {
        private Image _elementImage;

        private void Awake()
        {
            _elementImage = GetComponent<Image>();
        }

        public void SetElement(ObjectToFind obj)
        {
            _elementImage.sprite = obj.Sprite;
        }
    }
}
