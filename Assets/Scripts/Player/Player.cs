using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(InputReader)), RequireComponent(typeof(PlayerMoverTopDown)),
     RequireComponent(typeof(CollisionHandler))]
    public class Player : MonoBehaviour
    {
        private InputReader _inputReader;
        private PlayerMoverTopDown _playerMover;
        private CollisionHandler _collisionHandler;

        private void Awake()
        {
            _inputReader = GetComponent<InputReader>();
            _playerMover = GetComponent<PlayerMoverTopDown>();
            _collisionHandler = GetComponent<CollisionHandler>();
        }

        private void FixedUpdate()
        {
            Vector2 moveDirection = _inputReader.GetMovementDirection();
            _playerMover.Move(moveDirection);

            if (_inputReader.IsDashing())
            {
                _playerMover.Dash(moveDirection);
            }
        }
    }
}