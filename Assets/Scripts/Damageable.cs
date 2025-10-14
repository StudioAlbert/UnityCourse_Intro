using UnityEngine;

public class Damageable : MonoBehaviour
{

    [SerializeField] private float hp = 50;
    public float Hp => hp;

    public void TakeDamages(float damages)
    {
        //Debug.Log("Damages !!!!!!!!! " +  damages);
        hp -= damages;
        if(hp < 0)
        {
            // Option 1 : objet decede rendu inactif, on peut le reactiver plus tard
            gameObject.SetActive(false);
            // Option 2 : l'objet est supprimé de la scene jusqu'au rechargement de la scene ou le respwan de l'objet
            //Destroy(gameObject);
        }
    }
}
