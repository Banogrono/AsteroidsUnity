using UnityEngine;

namespace UI
{
    public class MenuAnimation : MonoBehaviour
    {
        public float difference = 12f;
    
        private float _originalY;
    
        // Start is called before the first frame update
        private void Start()
        {
            _originalY = gameObject.transform.position.y;
        }

        // Update is called once per frame
        private void FixedUpdate()
        {
            transform.position = new Vector2(transform.position.x, _originalY + (Mathf.Sin(Time.time) * difference));
        }
    }
}
