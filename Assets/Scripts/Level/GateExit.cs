using System.Linq;
using Level;
using UnityEngine;

public class GateExit : MonoBehaviour, IInterectable
{
    [SerializeField] private Switch[] _switches;

    public void Interact()
    {
        if (_switches.All(s => s.IsActive))
        {
            gameObject.SetActive(false);
        }
    }
}