using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    private bool available = true;

    public bool IsAvailable()
    {
        return available;
    }

    public bool TryTake()
    {
        if (!available) { return false; }
        
        available = false;
        return true;
    }
}
