using System;
using UnityEngine;
using Object = UnityEngine.Object;


// God object. Please Forgive me...
public static class SharedMethods 
{
   public static int AsteroidNumber;
   public static bool NewHighScore = false;
   private static readonly int[] TopTenScores = new int[10];
  
  /* checking for player escaping the screen boundaries */
  public static void EscapeScreen(Transform transform, Vector3 position)
  {
    if (!(Camera.main is null) && position.y > Camera.main.orthographicSize + 0.5f)
    {
      position.y = -Camera.main.orthographicSize - 0.5f;
    }

    if (!(Camera.main is null) && position.y < -Camera.main.orthographicSize - 0.5f)
    {
      position.y = Camera.main.orthographicSize + 0.5f;
    }

    var screenRatio = Screen.width / (float)Screen.height;
    if (!(Camera.main is null))
    {
      var edgesSize = screenRatio * Camera.main.orthographicSize;

      if (position.x > edgesSize + 1f)
      {
        position.x = -edgesSize - 1f;
      }

      if (position.x < -edgesSize - 1f)
      {
        position.x = edgesSize + 1f;
      }
    }
    transform.position = position;
  }
  
  /* same as above, but with ability to change tolerance (how far object can go before teleporting to opposite side of screen) */
  public static void EscapeScreen(Transform transform, Vector3 position, float tolerance)
  {
    if (!(Camera.main is null) && position.y > Camera.main.orthographicSize + tolerance)
    {
      position.y = -Camera.main.orthographicSize - tolerance;
    }

    if (!(Camera.main is null) && position.y < -Camera.main.orthographicSize - tolerance)
    {
      position.y = Camera.main.orthographicSize + tolerance;
    }

    var screenRatio = Screen.width / (float)Screen.height;
    if (!(Camera.main is null))
    {
      var edgesSize = screenRatio * Camera.main.orthographicSize;

      if (position.x > edgesSize + tolerance)
      {
        position.x = -edgesSize - tolerance;
      }

      if (position.x < -edgesSize - tolerance)
      {
        position.x = edgesSize + tolerance;
      }
    }
    transform.position = position;
  }
  
  /// <summary>
  /// Limit max velocity for an object
  /// </summary>
  /// <param name="rigidbody2D"></param> rigidbody2D of game object.
  /// <param name="minSpeed"></param> minimal speed. If not need set this param to equal -maxSpeed
  /// <param name="maxSpeed"></param> maximal speed.
  public static void ClampVelocity(Rigidbody2D rigidbody2D, float minSpeed, float maxSpeed)
  {
    var x = Mathf.Clamp(rigidbody2D.velocity.x, minSpeed, maxSpeed); // clamps speed so it never is more or less than playerMaxSpeed
    var y = Mathf.Clamp(rigidbody2D.velocity.y, minSpeed, maxSpeed); // does the same but for y

    rigidbody2D.velocity = new Vector2(x, y);
  }
  
  /// <summary>
  /// Pushes object forward.
  /// </summary>
  /// <param name="gameObject"> The game object to push forward.</param>
  /// <param name="rigidbody2D"> The rigidbody2D of game object. </param>
  /// <param name="amount"> Amount of force with which object will be pushed.</param>
  public static void ThrustForward(GameObject gameObject, Rigidbody2D rigidbody2D, float amount)
  {
    rigidbody2D.AddForce(gameObject.transform.up * amount); // apply force
  }

  /// <summary>
  /// Makes sure that objectB (eg. enemy) stays within specified range with target (eg. player). 
  /// </summary>
  /// <param name="target"></param> An object to keep distance with (eg. player). 
  /// <param name="objectB"></param> An object that keeps distance (eg. shy enemy).
  /// <param name="minDistance"></param> Minimal distance between two objects.
  /// <param name="maxDistance"></param> Maximal distance between two objects.
  /// <param name="objectBSpeed"></param> Maximal runaway speed for objectB.
  public static void KeepWithinDistance(Transform target, GameObject objectB, float minDistance, float maxDistance, float objectBSpeed)
  {
    var objectBRigidbody2D = objectB.GetComponent<Rigidbody2D>();

    var distance = target.position - objectB.transform.position;
    var absoluteDistance = new Vector3(Mathf.Abs(distance.x), Mathf.Abs(distance.y), 0);

    if (absoluteDistance.x <= minDistance || absoluteDistance.y <= minDistance)
    {
      // if too close to the target, move away target from target
      ThrustForward(objectB, objectBRigidbody2D, -objectBSpeed * 0.3f);
      ClampVelocity(objectBRigidbody2D, -objectBSpeed, objectBSpeed);
    }
    else if (absoluteDistance.x <= maxDistance || absoluteDistance.y <= maxDistance)
    {
      // if within range, do nothing
    }
    else
    {
      // if too far from the target, move towards the target 
      ThrustForward(objectB, objectBRigidbody2D, objectBSpeed);
      ClampVelocity(objectBRigidbody2D, -objectBSpeed, objectBSpeed);
    }
  }

  /// <summary>
  /// Replaces the next lowest score and returns sorted and reversed array.
  /// </summary>
  /// <param name="score"></param>
  public static void FindLowestScoreAndReplace(int score)
  {
    Array.Sort(TopTenScores); 
    Array.Reverse(TopTenScores);
    int temp = 0;
    bool push = false;
    for (var i = 0; i < TopTenScores.Length; i++)
    {
      if (push)
      {
        var t = TopTenScores[i];
        TopTenScores[i] = temp;
        temp = t;
      }
      
      if (TopTenScores[i] <= score && !push)
      {
        push = true;
        temp = TopTenScores[i];
        TopTenScores[i] = score;
      }
    }
  }

  /// <summary>
  /// Destroys every enemy object on the screen. (Does not hurt player.) 
  /// </summary>
  public static void KillEverythingExceptPlayer()
  {
    var enemies = GameObject.FindGameObjectsWithTag("Enemy");
    foreach (var enemy in enemies)
    {
      Object.Destroy(enemy);
    }
  }
  
  
}
