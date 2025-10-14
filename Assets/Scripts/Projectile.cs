using UnityEngine;

public class Projectile : MonoBehaviour
{

    [SerializeField] private float speed = 0.5f;
    [SerializeField] private LayerMask obstacles;

    private Rigidbody rb;
    private DamageDealer dealer;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Debug.Log("Projectile has started");
        rb = GetComponent<Rigidbody>();
        dealer = GetComponent<DamageDealer>();

        // 3 Add force at startup
        rb.AddForce(transform.forward * speed, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        // 1 Déplacement sans physique
        //transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // 2 Déplacement avec un peu de physique
        //rb.linearVelocity = transform.forward * speed;

        // 3 Add Continous force
        rb.AddForce(transform.forward * speed);

    }

    void OnCollisionEnter(Collision collision)
    {

        if (LayerMask.NameToLayer("Obstacles") == collision.gameObject.layer)
        {
            Destroy(gameObject);
        }

    }

    void OnTriggerEnter(Collider other)
    {
       dealer.DoDamages(other.gameObject);
        //if (other.transform.gameObject != thrower && other.gameObject.TryGetComponent(out Damageable damaged)) {
        //    damaged.TakeDamages(10);
        //}
    }



}
