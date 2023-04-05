using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private float _radiusAroundParent = 1;
    [SerializeField] private float _density = 1;
    [SerializeField] private int _circleLayers = 1;
    [SerializeField] private List<EnemyMovement> _enemyMovementList = new List<EnemyMovement>();

    private GameObject _enemy;
    private List<Vector3> _points = new List<Vector3>();
    private float _countEnemy;
    private UnitsManager _unitsManager;

    public List<EnemyMovement> EnemyMovements => _enemyMovementList;
    public List<Vector3> Points => _points;

    private void Start()
    {
        _countEnemy = Random.Range(1,10);
        _enemy = transform.GetChild(0).gameObject;
        _enemyMovementList.Add(_enemy.GetComponent<EnemyMovement>());
        float goldenAngle = Mathf.PI * (3 - Mathf.Sqrt(5));

        for (int z = 0; z < _circleLayers; z++)
        {
            for (int i = 0; i < _countEnemy; i++)
            {
                float theta = i * goldenAngle;
                float r = Mathf.Sqrt(i) / Mathf.Sqrt(_density - _radiusAroundParent);
                GameObject tempEnemy = Instantiate(_enemy, transform);
                tempEnemy.TryGetComponent(out Enemy enemy);
                enemy.SetEnemyParametr(_unitsManager);
                tempEnemy.transform.position = new Vector3(
                        Mathf.Clamp(transform.position.x - r * Mathf.Cos(theta), -4, 4),
                        0.5f,
                        transform.position.z - r * Mathf.Sin(theta)
                        );
                _enemyMovementList.Add(tempEnemy.GetComponent<EnemyMovement>());
            }
        }
    }

    public void SetManagerParametr(UnitsManager unitsManager)
    {
        _unitsManager = unitsManager;
    }

    public void SetAnimationAllUnits(int anim, bool isRun = true)
    {
        foreach (EnemyMovement enemy in _enemyMovementList)
        {
            enemy.SetAnimation(anim, isRun);
        }
    }

    public void RemoveEndUnit()
    {
        if (_enemyMovementList.Count > 0)
        {
            Destroy(_enemyMovementList[_enemyMovementList.Count - 1].gameObject);
            _enemyMovementList.Remove(_enemyMovementList[_enemyMovementList.Count - 1]);
        }
    }

    public void RemoveUnit(EnemyMovement enemyMovement)
    {
        _enemyMovementList.Remove(enemyMovement);
        Destroy(enemyMovement.gameObject);
    }
    public void MakeEnemiesCircleTarget()
    {
        _points = new List<Vector3>();
        int _countPoint = (int)Mathf.Round(_circleLayers * Mathf.PI);

        for (int z = 1; z < _circleLayers; z++)
        {
            for (int i = 0; i < _countPoint; i++)
            {
                _points.Add(new Vector3(
                    transform.position.x + _radiusAroundParent * Mathf.Cos(2 * Mathf.PI * i / _countPoint) * z,
                    1,
                    transform.position.z + _radiusAroundParent * Mathf.Sin(2 * Mathf.PI * i / _countPoint) * z
                    ));
            }
        }
    }

    private void Move()
    {
        for (int i = 0; i < _enemyMovementList.Count; i++)
        {
            _enemyMovementList[i].SetDestination(_points[i]);
        }
    }
}