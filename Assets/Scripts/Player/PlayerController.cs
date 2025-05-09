using UnityEngine;

namespace Player
{
public class PlayerController : MonoBehaviour
{
    [SerializeField] private bool hasCoin;
    
    public void SetHasCoin(bool hasCoinArg) => hasCoin = hasCoinArg;
}
}
