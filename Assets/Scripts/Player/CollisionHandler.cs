using System;
using UnityEngine;

namespace Player
{
    public class CollisionHandler : MonoBehaviour
    {
        public event Action<GateExit> GateExitReached;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out GateExit gateExit))
            {
                GateExitReached?.Invoke(gateExit);
            }
        }
    }
}