using UnityEngine;

public class CameraRotation : MonoBehaviour
{
	private readonly Vector3 _rotationVector = Vector3.up;
	private Vector3 _prevMousePosition;

	private void Update()
	{
		if (Input.GetMouseButtonDown((int)MouseButton.Right))
		{
			_prevMousePosition = Input.mousePosition;
		}

		if (Input.GetMouseButton((int)MouseButton.Right))
		{
			var mousePosition = Input.mousePosition;
			var mouseDelta = mousePosition - _prevMousePosition;
			transform.Rotate(_rotationVector, mouseDelta.x * 0.3f);
			_prevMousePosition = mousePosition;
		}
	}
}
