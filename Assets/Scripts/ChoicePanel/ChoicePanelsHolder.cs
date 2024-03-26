using UnityEngine;

namespace ChoicePanel
{
    public class ChoicePanelsHolder : MonoBehaviour
    {
        [SerializeField] private ChoicePanel _choicePanelPrefab;

        [SerializeField] private Task.Task _task;

        private void OnEnable()
        {
            _task.TaskComplete += ClearChoicePanels;
        }

        private void OnDisable()
        {
            _task.TaskComplete -= ClearChoicePanels;
        }

        public void DisplayChoicePanels(ObjectToFind[] objectsArray)
        {
            foreach (ObjectToFind obj in objectsArray)
            {
                ChoicePanel choicePanel = Instantiate(_choicePanelPrefab, transform);

                choicePanel.SetObjectToFind(obj);

                choicePanel.OnClick += _task.CheckTaskCompleted;
            }
        }

        private void ClearChoicePanels()
        {
            foreach (Transform child in transform)
            {
                child.GetComponent<ChoicePanel>().OnClick -= _task.CheckTaskCompleted;

                Destroy(child.gameObject);
            }
        }
    }
}
