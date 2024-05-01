using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObtacleController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D _rb;

    [SerializeField]
    private Collider2D _collider;

    private float _duration = 3.0f;

    private void Start()
    {
        _rb.velocity = Vector2.down * _duration;
    }
}
