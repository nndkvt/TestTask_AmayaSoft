using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Task
{
    public class Task : MonoBehaviour
    {
        private TaskText _taskText;

        private ObjectToFind _taskObject;

        public UnityAction TaskComplete;

        private void Awake()
        {
            _taskText = GetComponent<TaskText>();
        }

        public void SetTaskObject(ObjectToFind objectToFind)
        {
            _taskObject = objectToFind;

            _taskText.SetText(_taskObject);
        }

        public void CheckTaskCompleted(ChoicePanel.ChoicePanel selectedPanel)
        {
            ObjectToFind selectedObjectToFind = selectedPanel.GetObjectToFind();

            if (selectedObjectToFind.Key == _taskObject.Key)
            {
                StartCoroutine(TaskCompleted(selectedPanel));
            }
            else
            {
                selectedPanel.WrongAnswer();
            }
        }

        private IEnumerator TaskCompleted(ChoicePanel.ChoicePanel selectedPanel)
        {
            selectedPanel.RightAnswer();

            yield return new WaitForSeconds(5);

            TaskComplete?.Invoke();
        }
    }
}
