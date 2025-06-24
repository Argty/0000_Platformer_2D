using UnityEngine;

namespace Player
{
    public class PlayerAnimator : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        public void SetSpeedX(float speedX)
        {
            _animator.SetFloat(ConstantData.PlayerAnimator.SpeedX, speedX);
        }

        public void SetSpeedY(float speedY)
        {
            _animator.SetFloat(ConstantData.PlayerAnimator.SpeedY, speedY);
        }
    }
}