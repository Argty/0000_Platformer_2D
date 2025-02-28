using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMoverTopDown : MonoBehaviour
{
    private const float SPEED_COEFFICIENT = 50f;
    private const string HORIZONTAL_AXIS = "Horizontal";
    private const string VERTICAL_AXIS = "Vertical";

    [Header("Player settings")] [SerializeField]
    private float speed = 1f;

    [SerializeField] private float dashForce = 15f;

    private Rigidbody2D _rigidbody2D;
    private float _directionHorizontal;
    private float _directionVertical;

    private bool _isDashing = false;

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
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
    }
}