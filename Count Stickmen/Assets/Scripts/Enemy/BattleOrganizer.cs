using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyManager))]
public class BattleOrganizer : MonoBehaviour
{
    private TargetMovement _stickmenTargetMovement;
    private StickmenMovement _movement;
    private bool _isFight = false;
    private UnitsManager _unitsManager;
    private EnemyManager _enemyManager;

    private void Start()
    {
        _enemyManager= GetComponent<EnemyManager>();
    }

    private void FixedUpdate()
    {
        if (_enemyManager != null)
        {
            if (_enemyManager.EnemyMovements.Count == 0)
            {
                _stickmenTargetMovement.enabled = false;
                _movement.enabled = true;
                StartCoroutine(_unitsManager.SetAnimationAllUnits(12));
                StartCoroutine(_unitsManager.StopAllUnitsCoroutine());
                _unitsManager.MakeUnitsCircleTarget();
                _unitsManager.SetAllUnitsDestination();
                _enemyManager = null;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out AIUnit aIUnit) && _isFight == false)
        {
            _unitsManager = aIUnit.UnitsManager;
            _stickmenTargetMovement = _unitsManager.Target.GetComponent<TargetMovement>();
            _movement = _unitsManager.Target.GetComponent<StickmenMovement>();
            _stickmenTargetMovement.enabled = true;
            _stickmenTargetMovement.SetTargetPosition(transform);
            _isFight = true;
            _enemyManager.SetAnimationAllUnits(18);
            StartCoroutine(_unitsManager.SetAnimationAllUnits(18));
            _movement.enabled = false;
        }
    }
}
