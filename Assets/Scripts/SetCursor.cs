using UnityEngine;

public class SetCursor : MonoBehaviour
{

    public Texture2D crosshair; 
    
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;


    private void Start()
    {
        var cursorOffset = new Vector2(crosshair.width / 2, crosshair.height / 2);
        Cursor.SetCursor(crosshair, cursorOffset, CursorMode.Auto);
    }
    
}
