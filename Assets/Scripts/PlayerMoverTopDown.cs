using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(PlayerAnimator))]
public class PlayerMoverTopDown : MonoBehaviour
{
    private const float SPEED_COEFFICIENT = 50f;
    private const string HORIZONTAL_AXIS = "Horizontal";
    private const string VERTICAL_AXIS = "Vertical";

    [Header("Player settings")] 
    [SerializeField] private float speed = 1f;
    [SerializeField] private float dashForce = 15f;
    
    private Rigidbody2D _rigidbody2D;
    private PlayerAnimator _playerAnimator;
    private float _directionHorizontal;
    private float _directionVertical;
    private bool _isTurnRight = true;
    private bool _isDashing = false;

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _playerAnimator = GetComponent<PlayerAnimator>();
    }

    private void Update()
    {
        _directionHorizontal = Input.GetAxisRaw(HORIZONTAL_AXIS);
        _directionVertical = Input.GetAxisRaw(VERTICAL_AXIS);

        if ((_directionHorizontal != 0 || _directionVertical != 0) && Input.GetKeyDown(KeyCode.Space))
        {
            _isDashing = true;
        }
    }

    void FixedUpdate()
    {
        _playerAnimator.SetSpeedX(Mathf.Abs(_directionHorizontal));
        _playerAnimator.SetSpeedY(_directionVertical);

        Vector2 moveDirection = new Vector2(_directionHorizontal, _directionVertical);
        if (moveDirection.magnitude > 0)
        {
            moveDirection = moveDirection.normalized;
        }

        if (_isDashing)
        {
            _rigidbody2D.AddForce(moveDirection * dashForce, ForceMode2D.Impulse);
            _isDashing = false;
        }
        else
        {
            _rigidbody2D.linearVelocity = new Vector2(moveDirection.x * speed * SPEED_COEFFICIENT * Time.fixedDeltaTime,
                moveDirection.y * speed * SPEED_COEFFICIENT * Time.fixedDeltaTime);
        }

        if (_directionHorizontal > 0 && !_isTurnRight)
        {
            Flip();
        }
        else if (_directionHorizontal < 0 && _isTurnRight)
        {
            Flip();
        }
    }

    private void Flip()
    {
        _isTurnRight = !_isTurnRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}