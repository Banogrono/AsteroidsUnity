using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ExterminationsDisplay : MonoBehaviour
    {
        public Text scoreLabel;
    
        
        // Update is called once per frame
        private void Update()
        {
            scoreLabel.text = "Exterminations: " + StaticVariables.GenocideShot;
            
        }
    }
}
