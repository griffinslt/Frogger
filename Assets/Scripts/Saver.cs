using UnityEngine;


public class Saver : MonoBehaviour
{
    private GameObject[] _gameObjects;

    private void Start()
    {
        _gameObjects = (GameObject[]) FindObjectsOfType(typeof(MonoBehaviour));
    }

    public void Save()
    {
        foreach (var gameObjectFromArray in _gameObjects)
        {
            print(gameObjectFromArray.ToString());
        }
    }
}
