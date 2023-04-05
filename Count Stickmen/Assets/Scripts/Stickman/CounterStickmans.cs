using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CounterStickmans : MonoBehaviour
{
    [SerializeField] private GameObject _pool;

    private TextMeshPro CountUnits;

    public void Start()
    { 
        CountUnits = GetComponent<TextMeshPro>();
        CountUnits.text = _pool.transform.childCount.ToString();
    }

    public void FixedUpdate()
    {
        CountUnits.text = _pool.transform.childCount.ToString();
    }
}
