using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupActiveSwitcher : MonoBehaviour
{
    private List<BoxCollider> _bounces = new List<BoxCollider>();

    private void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
            _bounces.Add(transform.GetChild(i).GetComponent<BoxCollider>());
    }

    public void DisableGroupBounce()
    {
        foreach (BoxCollider bounce in _bounces)
            bounce.enabled = false;
    }
}
