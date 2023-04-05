using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AIUnit : MonoBehaviour
{
    [SerializeField] UnitsManager _unitsManager;
    [SerializeField] private float _speed = 15f;
    [SerializeField] private Transform _target;

    private Vector3 _position;
    private Animator _animator;

    public UnitsManager UnitsManager => _unitsManager;
    public Coroutine Coroutine;
    public bool IsPositionSet => _position != Vector3.zero;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _unitsManager.Units.Add(this);
        _unitsManager.MakeUnitsCircleTarget();
    }

    public void AddUnitsByScale(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Instantiate(this,transform.parent);
        }
        _unitsManager.MakeUnitsCircleTarget();
        _unitsManager.SetAllUnitsDestination();
    }

    public void SetAnimation(int anim,bool isRun = true)
    {
        _animator.SetBool("animation_" + anim, isRun);
    }

    private void FixedUpdate()
    {
        if (_position != Vector3.zero)
            transform.position = Vector3.Lerp(transform.position,_position,_speed * Time.deltaTime);
    }

    public void SetDestination(Vector3 position)
    {
        _position = new Vector3(position.x, 0, position.z);
    }

    public IEnumerator MoveTarget(Vector3 position)
    {
        while (transform.position != position)
        {
            transform.position = Vector3.Lerp(transform.position,position,_speed * Time.deltaTime);
            yield return null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Trap trap))
        {
            _unitsManager.RemoveUnit(this);
            _unitsManager.MakeUnitsCircleTarget();
        }
    }
}