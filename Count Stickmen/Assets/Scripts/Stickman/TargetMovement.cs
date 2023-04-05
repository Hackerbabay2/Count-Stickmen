using UnityEngine;

public class TargetMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private UnitsManager _unitsManager;
    private Vector3 _target;
    private EnemyManager _enemyManager;

    private void FixedUpdate()
    {
        if (_target != Vector3.zero)
        {
            transform.position = Vector3.MoveTowards(transform.position,_target,_speed * Time.deltaTime);
            _unitsManager.SetAllUnitsMoveTarget(_enemyManager.Points);
        } 
    }

    public void SetTargetPosition(Transform target)
    {
        _target = target.position;
        _enemyManager = target.GetComponent<EnemyManager>();
    }
}
