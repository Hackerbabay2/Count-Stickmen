using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(BoxCollider))]
abstract public class Scaler : MonoBehaviour
{
    [SerializeField] protected char _simbol;
    [SerializeField] protected int _scale = 3;
    [SerializeField] protected Transform _pool;
    [SerializeField] protected UnitsManager _unitsManager;

    protected BoxCollider _boxCollider;
    protected TextMeshPro _textMeshPro;
    protected GroupActiveSwitcher _activeSwitcher;

    private void Start()
    {
        _activeSwitcher = GetComponentInParent<GroupActiveSwitcher>();
        _boxCollider = GetComponent<BoxCollider>();
        _textMeshPro = GetComponentInChildren<TextMeshPro>();
        _textMeshPro.text = $"{_simbol}{_scale}";
    }

    protected void CreateUnits(int count, GameObject unit)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject tempUnit = Instantiate(unit, _pool);
            _unitsManager.SetAllUnitsDestination();
            _unitsManager.Units.Add(tempUnit.GetComponent<AIUnit>());
        }
        gameObject.SetActive(false);
    }

    public void SetData(UnitsManager unitsManager, Transform pool)
    {
        _pool = pool;
        _unitsManager = unitsManager;
    }
}
