using UnityEngine;

[RequireComponent(typeof(EnemyMovement))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private UnitsManager _unitsManager;

    private EnemyManager _enemyManager;
    private EnemyMovement _enemyMovement;

    private void Start()
    {
        _enemyMovement = GetComponent<EnemyMovement>();
        _enemyManager = transform.GetComponentInParent<EnemyManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out AIUnit aIUnit))
        {
            _unitsManager.RemoveUnit(aIUnit);
            _enemyManager.RemoveUnit(_enemyMovement);
        }
    }

    public void SetEnemyParametr(UnitsManager unitsManager)
    {
        _unitsManager = unitsManager;
    }
}
