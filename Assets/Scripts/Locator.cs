using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Locator : MonoBehaviour
{
    public GameObject Locate(string tagToLocate) {
        GameObject closest = null;
        float closestDistance = Mathf.Infinity;
        GameObject.FindGameObjectsWithTag(tagToLocate).ToList().ForEach(obj => {
            float distance = Vector2.Distance(transform.position, obj.transform.position);
            if (distance < closestDistance) {
                closest = obj;
                closestDistance = distance;
            }
        });
        return closest;
    }
}
