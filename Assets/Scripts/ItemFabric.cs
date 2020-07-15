using UnityEngine;

public class ItemFabric : MonoBehaviour {
	[SerializeField] private Transform itemsParent;

	[SerializeField] private GameObject quadPrefab;
	[SerializeField] private GameObject circlePrefab;
	[SerializeField] private GameObject capsulePrefab;

	public GameObject CreateItem(ItemType type)
	{
		switch (type)
		{
			case ItemType.Quad:
				return CreateObject(quadPrefab);
			case ItemType.Circle:
				return CreateObject(circlePrefab);
			case ItemType.Capsule:
				return CreateObject(capsulePrefab);
		}
		return null;
	}

	private GameObject CreateObject(GameObject prefab)
	{
		if (prefab != null)
		{
			return Instantiate(prefab, itemsParent);
		}
		return null;
	}
}
