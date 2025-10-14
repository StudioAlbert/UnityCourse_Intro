using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private float interval = 1;
    [SerializeField] private Transform laserPoint;
    [SerializeField] private int damages = 10;

    private float elapsedTime = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        Debug.DrawRay(laserPoint.position, laserPoint.forward * 1000, Color.cyan);

        // Cooldown
        //elapsedTime += Time.deltaTime;

        //if (elapsedTime >= interval)
        //{
        //    elapsedTime = 0f;

        //    if (Physics.Raycast(laserPoint.position, laserPoint.forward, out RaycastHit hitInfo))
        //    {
        //        Debug.Log("Touché laser, piou-piou : " + hitInfo.collider.gameObject.name);

        //        if (hitInfo.collider.gameObject.TryGetComponent(out Damageable victim))
        //        {
        //            victim.TakeDamages(damages);
        //        }
        //    }
        //}

        if (Physics.Raycast(laserPoint.position, laserPoint.forward, out RaycastHit hitInfo))
        {
            Debug.Log("Touché laser, piou-piou : " + hitInfo.collider.gameObject.name);
            if (hitInfo.collider.gameObject.TryGetComponent(out Damageable victim))
                {
                   victim.TakeDamages(damages * Time.deltaTime);
                }
        }


    }
}
