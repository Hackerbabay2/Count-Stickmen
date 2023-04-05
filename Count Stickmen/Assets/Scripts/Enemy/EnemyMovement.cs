using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 10;

    private Vector3 _position;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (_position != Vector3.zero)
        {
            transform.position = Vector3.Lerp(transform.position, _position, _speed * Time.deltaTime);
        }
    }

    public void SetDestination(Vector3 position)
    {
        _position = new Vector3(position.x, transform.position.y, position.z);
    }

    public void SetAnimation(int anim, bool isRun = true)
    {
        _animator.SetBool("animation_" + anim, isRun);
    }
}
