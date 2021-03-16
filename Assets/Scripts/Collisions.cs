using UnityEngine;

public class Collisions : MonoBehaviour
{
    public int health = 3;

    private void OnCollisionEnter2D(Collision2D other)
    {
        var asteroidsColliding = other.gameObject.name.Contains("asteroid") && gameObject.name.Contains("asteroid");
        var enemiesColliding = other.gameObject.name.Contains("enemySpaceShip") &&
                                   gameObject.name.Contains("enemySpaceShip");
        
        if (asteroidsColliding || enemiesColliding) return;
        
        if (other.gameObject.name.Contains("Player") && gameObject.name.Contains("enemySpaceShip2"))
        {
            health -= 3;
            return;
        }
        health--;
    }
    
    // Update is called once per frame
    private void Update()
    {
        if (health <= 0)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        if (gameObject.name.Contains("asteroid") || gameObject.name.Contains("enemySpaceShip"))
        {
            SharedMethods.AsteroidNumber--;
        }
        Destroy(gameObject);
    }
}
