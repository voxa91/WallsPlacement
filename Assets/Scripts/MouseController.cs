using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseController : MonoBehaviour
{
	[SerializeField] private Camera mainCamera;

	private readonly int _wallLayerId = 10;

	private GameObject _wallGameObject;
	public Wall SelectedWall { get; private set; }
	public bool IsMouseOverWall { get; private set; }
	public Vector3 MouseWallPoint { get; private set; }

	public event Action OnMouseClick;

	private void Update()
	{
		if (!EventSystem.current.IsPointerOverGameObject())
		{
			TrackMousePosition();

			if (Input.GetMouseButtonDown((int)MouseButton.Left))
			{
				if (OnMouseClick != null)
				{
					OnMouseClick();
				}
			}
		}
	}

	private void TrackMousePosition()
	{
		Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
		RaycastHit hitData;
		if (Physics.Raycast(ray, out hitData, 1000) && hitData.transform.gameObject.layer == _wallLayerId)
		{
			GameObject hitGameObject = hitData.transform.gameObject;
			if (hitGameObject.layer == _wallLayerId)
			{
				IsMouseOverWall = true;
				MouseWallPoint = hitData.point;
				if (!ReferenceEquals(_wallGameObject, hitGameObject))
				{
					_wallGameObject = hitGameObject;
					SelectedWall = _wallGameObject.GetComponent<Wall>();
				}
				return;
			}
		}
		IsMouseOverWall = false;
		_wallGameObject = null;
		SelectedWall = null;
	}
}
