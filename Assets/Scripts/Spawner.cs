using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab;

    public void Spawn() {
        Spawn(Vector2.zero, Vector2.zero);
    }
    public void Spawn(Vector2 offsetMin, Vector2 offsetMax) {
        GameObject newResource = Instantiate(prefab);
        newResource.transform.position = new Vector3(Random.Range(offsetMin.x, offsetMax.x), 1f, Random.Range(offsetMin.y, offsetMax.y));
    }
}
