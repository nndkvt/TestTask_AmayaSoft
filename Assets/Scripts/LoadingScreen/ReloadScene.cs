using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ReloadScene : MonoBehaviour
{
    [SerializeField] private Text _loadingText;

    private void Awake()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;

        StartCoroutine(LoadSceneAsync(sceneIndex));
    }

    private IEnumerator LoadSceneAsync(int sceneIndex)
    {
        AsyncOperation loadAsync = SceneManager.LoadSceneAsync(sceneIndex);

        while (!loadAsync.isDone)
        {
            float percentage = (loadAsync.progress / 0.9f) * 100;

            _loadingText.text = "Loading " + (int)percentage;

            yield return null;
        }
    }
}
