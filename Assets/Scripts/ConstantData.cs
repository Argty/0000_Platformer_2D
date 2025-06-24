using UnityEngine;

public static class ConstantData
{
    public static class PlayerAnimator
    {
        public static readonly int SpeedX = Animator.StringToHash(nameof(SpeedX));
        public static readonly int SpeedY = Animator.StringToHash(nameof(SpeedY));
    }

    public static class SwitchAnimator
    {
        public static readonly int IsOn = Animator.StringToHash("IsOn");
        public static readonly int IsOff = Animator.StringToHash("IsOff");
    }
}
