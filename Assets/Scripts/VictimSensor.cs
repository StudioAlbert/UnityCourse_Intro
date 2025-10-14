using System.Linq;
using UnityEngine;

public class VictimSensor : MonoBehaviour
{
    [SerializeField] private float radius = 10f;
    [SerializeField] private LayerMask victimMask;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] victims = Physics.OverlapSphere(transform.position, radius, victimMask);

        if (victims.Length > 0)
        {
            // Pick by distance
            //Collider nearestVictim = victims.OrderBy(v => Vector3.Distance(v.transform.position, transform.position)).FirstOrDefault();
            //if (nearestVictim != null) {
            //    Debug.Log("Nearest victim : " + nearestVictim.gameObject.name);
            //}

            // Pick by HP (foreach loop)
            //GameObject bestVictim;
            //float bestHP = 0;

            //foreach (Collider v in victims)
            //{
            //    if (v.TryGetComponent(out Damageable d))
            //    {
            //        if (d.Hp > bestHP)
            //        {
            //            bestHP = d.Hp;
            //            bestVictim = d.gameObject;
            //        }
            //    }
            //}

            // Pick random
            float aleatoireNumber = Random.value;
            Random.Range(0f, 6f);
            
            Collider nearestVictim = victims[Random.Range(0, victims.Length)];
            Debug.Log("Nearest victim : " + nearestVictim.gameObject.name);

        }

    }
}
