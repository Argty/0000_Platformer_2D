using Level;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Switch : MonoBehaviour, IInterectable
{
    private Animator _animator;
    public bool IsActive { get; private set; }
    
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    
    public void Interact()
    {
        IsActive = !IsActive;
        if (IsActive)
        {
            _animator.SetTrigger(ConstantData.SwitchAnimator.IsOn);
        }
        else
        {
            _animator.SetTrigger(ConstantData.SwitchAnimator.IsOff);
        }
    }
}
