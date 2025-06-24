using UnityEngine;

namespace Player
{
    public class InputReader : MonoBehaviour
    {
        private const string HORIZONTAL_AXIS = "Horizontal";
        private const string VERTICAL_AXIS = "Vertical";

        private float _directionHorizontal;
        private float _directionVertical;

        private bool _isDashing = false;
        private bool _isInterect = false;

        private void Update()
        {
            _directionHorizontal = Input.GetAxisRaw(HORIZONTAL_AXIS);
            _directionVertical = Input.GetAxisRaw(VERTICAL_AXIS);

            if ((_directionHorizontal != 0 || _directionVertical != 0) && Input.GetKeyDown(KeyCode.Space))
            {
                _isDashing = true;
            }
            
            if (Input.GetKeyUp(KeyCode.E))
            {
                _isInterect = true;
            }
        }

        public Vector2 GetMovementDirection()
        {
            return new Vector2(_directionHorizontal, _directionVertical).normalized;
        }

        public bool IsDashing()
        {
            bool isDashing = _isDashing;
            _isDashing = false;
            return isDashing;
        }

        public bool IsInterect()
        {
            bool isInterect = _isInterect;
            _isInterect = false;
            return isInterect;
        }
    }
}