using UnityEngine;

public class Wall : MonoBehaviour
{
	[SerializeField] private WallType wallType;

	public Vector3 Size { get; private set; }
	public Vector3 Position { get; private set; }
	public Quaternion Rotation { get; private set; }
	public Bounds Bounds { get; private set; }

	void Start()
	{
		Bounds = GetComponent<Collider>().bounds;
		Size = Bounds.size;
		Position = Bounds.center;
		Rotation = transform.rotation;
	}

	public Vector3 GetPositionOnTheWall(Vector3 targetPos, Bounds itemBounds)
	{
		Vector3 halfSize = itemBounds.size * 0.5f;
		Vector3 min = targetPos - halfSize;
		Vector3 max = targetPos + halfSize;

		Vector3 pos = targetPos;

		if (wallType == WallType.Front || wallType == WallType.Back)
		{
			pos.x = GetPositionInBounds(pos.x, min.x, max.x, Bounds.min.x, Bounds.max.x, halfSize.x);
		}
		pos.y = GetPositionInBounds(pos.y, min.y, max.y, Bounds.min.y, Bounds.max.y, halfSize.y);
		if (wallType == WallType.Left || wallType == WallType.Right)
		{
			pos.z = GetPositionInBounds(pos.z, min.z, max.z, Bounds.min.z, Bounds.max.z, halfSize.z);
		}
		return pos;
	}

	private float GetPositionInBounds(float pos, float min, float max, float boundsMin, float boundsMax, float halfSize)
	{
		if (min < boundsMin)
		{
			return boundsMin + halfSize;
		}
		if (max > boundsMax)
		{
			return boundsMax - halfSize;
		}
		return pos;
	}
}
