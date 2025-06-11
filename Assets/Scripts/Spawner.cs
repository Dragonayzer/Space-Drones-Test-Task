using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab;

    public GameObject Spawn() {
        return Spawn(Vector2.zero, Vector2.zero);
    }
    public GameObject Spawn(Vector2 offsetMin, Vector2 offsetMax)
    {
        GameObject newObject = Instantiate(prefab);
        newObject.transform.position = transform.position + new Vector3(Random.Range(offsetMin.x, offsetMax.x), .5f, Random.Range(offsetMin.y, offsetMax.y));
        return newObject;
    }
}
