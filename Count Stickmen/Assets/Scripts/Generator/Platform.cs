using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private List<GameObject> _traps;
    [SerializeField] private List<GameObject> _bounces;
    [SerializeField] private int _seed;
    [SerializeField] private Transform _objectsPool;
    [SerializeField] private Transform _unitsPool;
    [SerializeField] private UnitsManager _unitsManager;

    private Transform _startPoint;
    private List<Transform> _generatorPoints = new List<Transform>();

    public Transform StartPoint => _startPoint;
    public List<Transform> GeneratorPoint => _generatorPoints;

    private void Start()
    {
        //Random.InitState(_seed);
        _startPoint = transform.GetChild(0).transform.GetChild(0).transform;
        SetChildPoints(transform.GetChild(0).transform.GetChild(1),ref _generatorPoints);
        StartCoroutine(CreateInteractive());
    }

    private void SetChildPoints(Transform transform, ref List<Transform> _points)
    {
        for (int i = 0; i < transform.childCount; i++)
            _points.Add(transform.GetChild(i));
    }

    private IEnumerator CreateInteractive()
    {

        int generatorFactor = Random.Range(0,100);

        foreach (Transform point in _generatorPoints)
        {
            if (generatorFactor <= 50)
            {
                GameObject bonus = Instantiate(_bounces[Random.Range(0, _bounces.Count)], _objectsPool);
                bonus.transform.position = point.transform.position + bonus.transform.localPosition;

                if (bonus.TryGetComponent(out BonuseScaler bonuseScaler))
                    bonuseScaler.SetData(_unitsManager,_unitsPool);
                else if (bonus.TryGetComponent(out BonuseParametrSetter bonuseParametrSetter))
                    bonuseParametrSetter.SetChildParametr(_unitsManager,_unitsPool);
                else if (bonus.TryGetComponent(out BonuseMultiplication bonuseMultiplication))
                    bonuseMultiplication.SetData(_unitsManager,_unitsPool);
            }
            else
            {
                GameObject trap = Instantiate(_traps[Random.Range(0, _traps.Count)], _objectsPool);
                trap.transform.position = point.transform.position + trap.transform.localPosition;

                if (trap.TryGetComponent(out EnemyManager manager))
                    manager.SetManagerParametr(_unitsManager);
            }
            yield return null;
        }
    }
}