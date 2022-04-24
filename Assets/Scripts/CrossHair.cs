using UnityEngine;

public class CrossHair : MonoBehaviour
{
    [SerializeField]
    Texture2D crossHair;

    private void Start()
    {
        Cursor.SetCursor(crossHair, Vector2.zero, CursorMode.ForceSoftware);
    }
}
