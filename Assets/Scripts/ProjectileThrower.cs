using UnityEngine;

public class ProjectileThrower : MonoBehaviour
{

    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float throwingInterval = 1.0f;
    [SerializeField] private Transform throwingPoint;

    private float elapsedTime = 0.0f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime >= throwingInterval) {
            elapsedTime = 0.0f;
            
            GameObject copy = Instantiate(projectilePrefab, throwingPoint.position, throwingPoint.rotation, this.transform);

            if(copy.TryGetComponent(out DamageDealer dealer))
            {
                dealer.thrower = gameObject;
            }

        }
        
    }
}
