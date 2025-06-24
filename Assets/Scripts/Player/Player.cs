using Level;
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
        
        private IInterectable _interectable;

        private void Awake()
        {
            _inputReader = GetComponent<InputReader>();
            _playerMover = GetComponent<PlayerMoverTopDown>();
            _collisionHandler = GetComponent<CollisionHandler>();
        }
        private void OnEnable()
        {
            _collisionHandler.GateExitReached += OnGateExitReached;
        }

        private void OnDisable()
        {
            _collisionHandler.GateExitReached -= OnGateExitReached;
        }

        private void FixedUpdate()
        {
            Vector2 moveDirection = _inputReader.GetMovementDirection();
            _playerMover.Move(moveDirection);

            if (_inputReader.IsDashing())
            {
                _playerMover.Dash(moveDirection);
            }

            if (_inputReader.IsInterect() && _interectable != null)
            {
                _interectable.Interact();
            }

        }
        
        private void OnGateExitReached(IInterectable interectable)
        {
            _interectable = interectable;
        }
    }
}