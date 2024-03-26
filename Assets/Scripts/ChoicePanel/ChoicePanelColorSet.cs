using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace ChoicePanel
{
    public class ChoicePanelColorSet : MonoBehaviour
    {
        private Image _panel;

        private void Awake()
        {
            _panel = GetComponent<Image>();

            Color randomColor = Random.ColorHSV();

            _panel.color = randomColor;
        }
    }
}
