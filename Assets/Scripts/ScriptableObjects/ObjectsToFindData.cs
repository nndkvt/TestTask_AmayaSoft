using UnityEngine;

[CreateAssetMenu(fileName = "ObjectsData", menuName = "ScriptableObjects/ObjectsData")]
public class ObjectsToFindData : ScriptableObject
{
    [SerializeField] private ObjectToFind[] objectsToFind;

    private System.Random rand = new System.Random();

    public ObjectToFind GetRandomObject()
    {        
        int index = rand.Next(0, objectsToFind.Length);

        return objectsToFind[index];
    }
}
