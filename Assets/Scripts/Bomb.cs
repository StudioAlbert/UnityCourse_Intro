using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class Bomb : MonoBehaviour
{

    [SerializeField] private float force = 0.5f;
    [SerializeField] private float radius = 3f;
    [SerializeField] private LayerMask explosionLayers;

    private Rigidbody rb;
    private DamageDealer dealer;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        dealer = GetComponent<DamageDealer>();

        rb.AddForce(transform.forward * force, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    void OnCollisionEnter(Collision collision)
    {
        Explode(collision.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        Explode(other.gameObject);
    }

    void Explode(GameObject collided)
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, radius, explosionLayers);

        foreach (Collider hit in hits)
        {
            dealer.DoDamages(hit.gameObject);
        }

        if (collided != dealer.thrower)
        {
            Destroy(gameObject);
        }
    }

}
