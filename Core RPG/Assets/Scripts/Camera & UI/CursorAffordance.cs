using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorAffordance : MonoBehaviour 
{
    [SerializeField]
    Texture2D walkCursor = null;

    [SerializeField]
    Texture2D targetCursor = null;

    [SerializeField]
    Texture2D unknownCursor = null;


    [SerializeField]
    CursorMode cursorMode = CursorMode.Auto;

    [SerializeField]
    Vector2 hotSpot = new Vector2(96, 96);

    CameraRaycaster cameraRaycaster;

    // Use this for initialization
	void Start () 
    {
        cameraRaycaster = GetComponent<CameraRaycaster>();
	}
	
	void Update () 
    {
        switch (cameraRaycaster.layerHit)
        {
            case Layer.Walkable:
                Cursor.SetCursor(walkCursor, hotSpot, cursorMode);
                break;

            case Layer.Enemy:
                Cursor.SetCursor(targetCursor, hotSpot, cursorMode);
                break;

            case Layer.RaycastEndStop:
                Cursor.SetCursor(unknownCursor, hotSpot, cursorMode);
                break;

            default:
                Debug.LogError("Don't know what cursor to show ");
                return;
        }

        
	}
}
