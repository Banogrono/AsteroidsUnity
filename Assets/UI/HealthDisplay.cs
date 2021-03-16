
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
   public class HealthDisplay : MonoBehaviour
   {
      public Text livesLeftLabel;

      private void Start()
      {
         livesLeftLabel.color = Color.white;
      }

      private void Update()
      {
         livesLeftLabel.text = "Lives: " + StaticVariables.PlayerLives;
         if (StaticVariables.PlayerLives <= 1)
         {
            livesLeftLabel.color = Color.red;
         }
         else
         {
            livesLeftLabel.color = Color.white;
         }
         
      }
   }
}
