using UnityEngine;

public class ShieldHandler : MonoBehaviour
{
  
    // Update is called once per frame
    private void Update()
    {
        var player = GameObject.FindWithTag("Player");

        if (player == null)
        {
            Destroy(gameObject);
        }
        else
        {
            gameObject.transform.position = player.transform.position;
        }
    }
}
