using UnityEngine;

// An affordance is the possibillity of an action on an object or enviroment
public class CursorAffordance : MonoBehaviour {

	[SerializeField] Texture2D walkCursor = null;
	[SerializeField] Texture2D attackCursor = null;
	[SerializeField] Texture2D unknownCursor = null;
	[SerializeField] Vector2 hotSpot = new Vector2(96, 96);

	CameraRaycaster CR;

	// Use this for initialization
	void Start () {

		CR = GetComponent<CameraRaycaster> ();	
	}
	
	// Update is called once per frame
	void Update () {

		switch (CR.layerHit) {

			case Layer.Walkable:
				Cursor.SetCursor (walkCursor, hotSpot, CursorMode.Auto);
				break;
			case Layer.RaycastEndStop:
				Cursor.SetCursor (unknownCursor, hotSpot, CursorMode.Auto);
				break;
			case Layer.Enemy:
				Cursor.SetCursor (attackCursor, hotSpot, CursorMode.Auto);
				break;
			default:
				Debug.Log ("Unknown Layer tag");
				return;
		}
		//print (CR.layerHit);
	}
}
