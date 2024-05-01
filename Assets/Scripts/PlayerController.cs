using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rb;

    private MoveDirection _moveDirection = MoveDirection.None;

    [SerializeField] private float _speed = 100f;

    [SerializeField]
    private ScoreCounter _scoreCounter;

    private AudioController _audioController;

    private bool _isCanMove = true;

    [HideInInspector]
    public UnityEvent<GameObject> IsBallHit;

    private void Awake()
    {
        IsBallHit = new UnityEvent<GameObject>();

        if (TryGetComponent(out Rigidbody2D rb))
        {
            _rb = rb;
        }
        else
        {
            new NullReferenceException("Check Player RigidBody!");
        }

        _audioController = FindObjectOfType<AudioController>();
    }

    private void FixedUpdate()
    {
        if (_moveDirection != MoveDirection.None && _isCanMove)
        {
            switch (_moveDirection)
            {
                case MoveDirection.Left:
                    MovePlayer(-1);
                    break;

                case MoveDirection.Right:
                    MovePlayer(1);
                    break;

                default:
                    break;
            }
        }
    }

    private void MovePlayer(int moveDir)
    {
        _rb.velocity = new Vector2(moveDir * Time.deltaTime * _speed, 0f);
    }

    public void ChangeMoveSide(int moveDirection)
    {
        _moveDirection = (MoveDirection)moveDirection;
        _rb.velocity = Vector2.zero;

        if (_audioController != null)
            _audioController.PlayBoatSound();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (collision.gameObject.CompareTag("Obtacle"))
            {
                if (_audioController != null)
                    _audioController.PlayLogSound();

                _scoreCounter.DecreaseScore();
                Destroy(collision.gameObject);
            }
        }
    }
}
