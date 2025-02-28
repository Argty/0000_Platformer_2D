using System;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    private const float SPEED_COFFICIENT = 50f;
    private const string HORIZONTAL_AXIS = "Horizontal";
    private const string GROUND_TAG = "Ground";

    [Header("Player speed")] [SerializeField]
    private float speed = 1f;
    [Header("Player jump")] [SerializeField]
    private float jumpForce = 10f;

    private Rigidbody2D _rigidbody2D;
    private float _direction;
    private bool _isJumping;
    private bool _isGrounded;

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _direction = Input.GetAxis(HORIZONTAL_AXIS);
        if (_isGrounded & Input.GetKeyDown(KeyCode.Space))
        {
            _isJumping = true;
        }
    }

    void FixedUpdate()
    {
        _rigidbody2D.linearVelocity = new Vector2(speed * _direction * SPEED_COFFICIENT * Time.fixedDeltaTime,
            _rigidbody2D.linearVelocity.y);
        if (_isJumping)
        {
            _rigidbody2D.AddForce(new Vector2(0f, jumpForce* SPEED_COFFICIENT * Time.fixedDeltaTime), ForceMode2D.Impulse);
            _isGrounded = false;
            _isJumping = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GROUND_TAG))
        {
            _isGrounded = true;
        }
    }
}