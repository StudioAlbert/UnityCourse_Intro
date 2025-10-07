using UnityEngine;

public class Damageable : MonoBehaviour
{

    [SerializeField] private int hp = 50;

    public void DoDamages(int damages)
    {
        Debug.Log("Damages !!!!!!!!! " +  damages);
        hp -= damages;
        if(hp < 0)
        {
            Debug.Log("je suis mort");
        }
    }
}
