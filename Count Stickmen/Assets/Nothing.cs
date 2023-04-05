using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nothing : MonoBehaviour
{
    [SerializeField] private Transform _parent;
    [SerializeField] private GameObject _pref;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            GameObject person = Instantiate(_pref, _parent);
            person.transform.position = new Vector3(_parent.position.x, _parent.position.y + 1.5f, _parent.position.z);
        }
    }
}
