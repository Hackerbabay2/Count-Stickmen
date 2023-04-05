using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private int _lengthLevel;
    [SerializeField] private Transform _pool;
    [SerializeField] private UnitsManager _unitsManager;
    [SerializeField] private GameObject _prefPlatoform;

    private List<Platform> _platforms = new List<Platform>();

    private void Start()
    {
        for (int i = 0; i < _lengthLevel; i++)
            _platforms.Add(_prefPlatoform.GetComponent<Platform>());
        CreateLevel();
    }

    private void CreateLevel()
    {
        for (int i = 0; i < _platforms.Count - 1; i++)
        {
            Instantiate(_platforms[i].gameObject,transform);
            _platforms[i].transform.position = _platforms[i + 1].StartPoint.position;
            _platforms[i].transform.position = new Vector3(
                _platforms[i].transform.position.x,
                _platforms[i].transform.position.y,
                _platforms[i].transform.position.z + _platforms[i].transform.localScale.z / 2);
        }
    }
}
