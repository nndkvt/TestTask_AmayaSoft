using ChoicePanel;
using System.Linq;
using UnityEngine;

namespace GameLogic
{
    [RequireComponent(typeof(LevelCounter))]
    public class TaskSetter : MonoBehaviour
    {
        [SerializeField] private ObjectsToFindData[] _objectsToFindData;

        [SerializeField] private Task.Task _task;

        [SerializeField] private ChoicePanelsHolder _grid;

        private LevelCounter _levelCounter;

        private ObjectToFind[] _previousTasks;

        private void Awake()
        {
            _levelCounter = GetComponent<LevelCounter>();

            _levelCounter.Init(out int levelCellsNumberLength, out int cellsNumber);

            _task.TaskComplete += _levelCounter.NewLevelAchieved;

            _previousTasks = new ObjectToFind[levelCellsNumberLength];

            SetObjectsArray(cellsNumber);
        }

        private void OnDisable()
        {
            _task.TaskComplete -= _levelCounter.NewLevelAchieved;
        }

        public void SetObjectsArray(int cellsNumber, int levelIndex = 0)
        {
            _grid.ClearChoicePanels();

            int dataIndex = ChooseObjectsDataset();

            ObjectToFind[] choicePanels = new ObjectToFind[cellsNumber];

            CompleteArray(choicePanels, levelIndex, cellsNumber, dataIndex);

            _task.SetTaskObject(choicePanels[0]);

            ArrayMethodsExtension.Shuffle(new System.Random(), choicePanels);

            _grid.DisplayChoicePanels(choicePanels, _task);
        }

        private int ChooseObjectsDataset()
        {
            System.Random rand = new System.Random();

            return rand.Next(0, _objectsToFindData.Length);
        }

        private void CompleteArray(ObjectToFind[] array, int levelIndex, int cellsNumber, int dataIndex)
        {
            array[0] = GenerateObject(dataIndex, _previousTasks);

            _previousTasks[levelIndex] = array[0];

            for (int i = 1; i < cellsNumber; i++)
            {
                array[i] = GenerateObject(dataIndex, array);
            }
        }

        private ObjectToFind GenerateObject(int dataIndex, ObjectToFind[] arrayToCheck)
        {
            ObjectToFind newObject = _objectsToFindData[dataIndex].GetRandomObject();

            while (arrayToCheck.Contains(newObject))
            {
                newObject = _objectsToFindData[dataIndex].GetRandomObject();
            }

            return newObject;
        }
    }
}
