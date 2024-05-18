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

    [SerializeField] private float _speed = 1f;

    private ScoreCounter _scoreCounter;

    private AudioController _audioController;

    private EventTrigger _eventTriggerLeft;

    private EventTrigger _eventTriggerRight;

    private bool _isCanMove = true;

    public float Speed { get { return _speed; } set { _speed = value; } }

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

        _scoreCounter = FindObjectOfType<ScoreCounter>();

        _eventTriggerLeft = GameObject.FindGameObjectWithTag("TriggerLeft").GetComponent<EventTrigger>();

        _eventTriggerRight = GameObject.FindGameObjectWithTag("TriggerRight").GetComponent<EventTrigger>();
    }

    private void Start()
    {
        EventTrigger.Entry moveLeft = new EventTrigger.Entry();
        moveLeft.eventID = EventTriggerType.PointerDown;
        moveLeft.callback.AddListener((data) => { ChangeMoveSide(0); });
        _eventTriggerLeft.triggers.Add(moveLeft);

        EventTrigger.Entry moveRight = new EventTrigger.Entry();
        moveRight.eventID = EventTriggerType.PointerDown;
        moveRight.callback.AddListener((data) => { ChangeMoveSide(2); });
        _eventTriggerRight.triggers.Add(moveRight);

        EventTrigger.Entry moveStop = new EventTrigger.Entry();
        moveStop.eventID = EventTriggerType.PointerUp;
        moveStop.callback.AddListener((data) => { ChangeMoveSide(4); });
        _eventTriggerLeft.triggers.Add(moveStop);
        _eventTriggerRight.triggers.Add(moveStop);
    }

    private void Update()
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
        _rb.velocity = new Vector2(moveDir * _speed, 0f);
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
