using UnityEngine;

namespace ChoicePanel
{
    public class ChoicePanelsHolder : MonoBehaviour
    {
        [SerializeField] private ChoicePanel _choicePanelPrefab;

        public void DisplayChoicePanels(ObjectToFind[] objectsArray, Task.Task assignedTask)
        {
            foreach (ObjectToFind obj in objectsArray)
            {
                ChoicePanel choicePanel = Instantiate(_choicePanelPrefab, transform);

                choicePanel.Init(obj, assignedTask);
            }
        }

        public void ClearChoicePanels()
        {
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }
        }
    }
}
