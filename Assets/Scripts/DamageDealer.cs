using Unity.Burst.CompilerServices;
using UnityEditor.Build;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] int damages = 15;

    public GameObject thrower;

    public void DoDamages(GameObject victim)
    {
        if (victim.transform.gameObject != thrower && victim.TryGetComponent(out Damageable damaged))
        {
            damaged.TakeDamages(damages);
        }
    }
}
