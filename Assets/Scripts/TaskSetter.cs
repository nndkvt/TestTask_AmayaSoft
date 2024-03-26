using ChoicePanel;
using System.Linq;
using UnityEngine;

public class TaskSetter : MonoBehaviour
{
    [SerializeField] private LevelsChoicePanelsNumber _levelCellsNumber;

    [SerializeField] private ObjectsToFindData[] _objectsToFindData;

    [SerializeField] private Task.Task _task;

    [SerializeField] private ChoicePanelsHolder _grid;

    [SerializeField] private GameObject _restartScreen;

    private int _levelIndex = 0;

    private ObjectToFind[] _previousTasks;

    private void Awake()
    {
        _task.TaskComplete += NewLevelAchieved;

        int levelCellsNumberLength = _levelCellsNumber.numberOfChoicePanels.Length;

        _previousTasks = new ObjectToFind[levelCellsNumberLength];

        SetObjectsArray();
    }

    private void OnDisable()
    {
        _task.TaskComplete -= NewLevelAchieved;
    }

    private void SetObjectsArray()
    {
        int cellsNumber = _levelCellsNumber.numberOfChoicePanels[_levelIndex];

        int dataIndex = ChooseObjectsDataset();

        ObjectToFind[] choicePanels = new ObjectToFind[cellsNumber];

        CompleteArray(choicePanels, cellsNumber, dataIndex);
        
        _task.SetTaskObject(choicePanels[0]);

        ArrayMethodsExtension.Shuffle(new System.Random(), choicePanels);

        _grid.DisplayChoicePanels(choicePanels);
    }

    private int ChooseObjectsDataset()
    {
        System.Random rand = new System.Random();

        return rand.Next(0, _objectsToFindData.Length);
    }

    private void CompleteArray(ObjectToFind[] array, int cellsNumber, int dataIndex)
    {
        array[0] = GenerateObject(dataIndex, _previousTasks);

        _previousTasks[_levelIndex] = array[0];

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

    private void NewLevelAchieved()
    {
        _levelIndex++;

        if (_levelIndex > _objectsToFindData.Length)
        {
            _restartScreen.SetActive(true);
        }
        else
        {
            SetObjectsArray();
        }
    }
}
