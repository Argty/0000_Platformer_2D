using System;
using Level;
using UnityEngine;

namespace Player
{
    public class CollisionHandler : MonoBehaviour
    {
        public event Action<IInterectable> GateExitReached;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out IInterectable gateExit))
            {
                GateExitReached?.Invoke(gateExit);
            }
        }
        
        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.TryGetComponent(out IInterectable _))
            {
                GateExitReached?.Invoke(null);
            }
        }
    }
}