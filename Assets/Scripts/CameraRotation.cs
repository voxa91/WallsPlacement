using UnityEngine;

public class CameraRotation : MonoBehaviour
{
	private readonly Vector3 _rotationVector = Vector3.up;
	private readonly float _speed = 0.3f;
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
			transform.Rotate(_rotationVector, mouseDelta.x * _speed);
			_prevMousePosition = mousePosition;
		}
	}
}
