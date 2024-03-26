using UnityEngine;
using UnityEngine.UI;

public class TaskText : MonoBehaviour
{
    private Text _text;

    private void Awake()
    {
        _text = GetComponent<Text>();
    }

    public void SetText(ObjectToFind objectToFind)
    {
        _text.text = "Find " + objectToFind.Key;
    }
}
