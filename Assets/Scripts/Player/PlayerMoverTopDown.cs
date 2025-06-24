using Level;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D), typeof(PlayerAnimator), typeof(CollisionHandler))]
    public class PlayerMoverTopDown : MonoBehaviour
    {
        private const float SPEED_COEFFICIENT = 50f;
        
        [Header("Player settings")] [SerializeField]
        private float speed = 1f;

        [SerializeField] private float dashForce = 15f;

        private Rigidbody2D _rigidbody2D;
        private PlayerAnimator _playerAnimator;
        
        
        private bool _isTurnRight = true;
        
        
        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _playerAnimator = GetComponent<PlayerAnimator>();
        }
        

        public void Move(Vector2 moveDirection)
        {
            _playerAnimator.SetSpeedX(Mathf.Abs(moveDirection.x));
            _playerAnimator.SetSpeedY(moveDirection.y);

            if (moveDirection.magnitude > 0)
            {
                moveDirection = moveDirection.normalized;
            }

            _rigidbody2D.linearVelocity = new Vector2(moveDirection.x * speed * SPEED_COEFFICIENT * Time.fixedDeltaTime,
                moveDirection.y * speed * SPEED_COEFFICIENT * Time.fixedDeltaTime);

            if ((moveDirection.x > 0 && !_isTurnRight) || (moveDirection.x < 0 && _isTurnRight))
            {
                Flip();
            }
        }

        public void Dash(Vector2 moveDirection)
        {
            _rigidbody2D.AddForce(moveDirection * dashForce, ForceMode2D.Impulse);
        }

        private void Flip()
        {
            _isTurnRight = !_isTurnRight;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }
}