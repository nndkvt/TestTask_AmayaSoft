using UnityEngine;

namespace GameLogic
{
    [RequireComponent(typeof(TaskSetter))]
    public class LevelCounter : MonoBehaviour
    {
        [SerializeField] private LevelsChoicePanelsNumber _levelCellsNumber;

        [SerializeField] private GameObject _restartScreen;

        private TaskSetter _taskSetter;

        private int _levelIndex = 0;

        public void Init(out int levelCellsNumberLength, out int cellsNumber)
        {
            _taskSetter = GetComponent<TaskSetter>();

            levelCellsNumberLength = _levelCellsNumber.numberOfChoicePanels.Length;

            cellsNumber = _levelCellsNumber.numberOfChoicePanels[_levelIndex];
        }

        public void NewLevelAchieved()
        {
            _levelIndex++;

            if (_levelIndex >= _levelCellsNumber.numberOfChoicePanels.Length)
            {
                _restartScreen.SetActive(true);
            }
            else
            {
                int cellsNumber = _levelCellsNumber.numberOfChoicePanels[_levelIndex];
                _taskSetter.SetObjectsArray(cellsNumber, _levelIndex);
            }
        }
    }
}
