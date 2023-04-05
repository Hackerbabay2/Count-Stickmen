using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetFollower : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _speed;
    [SerializeField] private float _indent;

    private void Update()
    {
        Vector3 currentTarget = new Vector3(transform.position.x,transform.position.y, _target.position.z - _indent);
        transform.position = Vector3.Lerp(transform.position,currentTarget,_speed * Time.deltaTime);
    }
}
