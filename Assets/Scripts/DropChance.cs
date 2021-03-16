using UnityEngine;
using Random = System.Random;

public class DropChance : MonoBehaviour
{
    public GameObject[] drops;
    public int chances = 15;
    public bool randomizeDropChance;


    private void OnDestroy()
    {
        var dropOrNot = new Random().Next(1, 100);
        
        if (randomizeDropChance)
        {
            chances = new Random().Next(1, 100);    
        }

        if (dropOrNot > chances) return;
        var prizeIndex = new Random().Next(0, drops.Length);
        Instantiate(drops[prizeIndex], gameObject.transform.position, Quaternion.identity);
    }
}
