using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    public readonly int SpeedX = Animator.StringToHash(nameof(SpeedX));
    public readonly int SpeedY = Animator.StringToHash(nameof(SpeedY));

    public void SetSpeedX(float speedX)
    {
        _animator.SetFloat(SpeedX, speedX);
    }

    public void SetSpeedY(float speedY)
    {
        _animator.SetFloat(SpeedY, speedY);
    }
}