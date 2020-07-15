using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemsController : MonoBehaviour
{
	[System.Serializable]
	public struct ItemGhost
	{
		public ItemType type;
		public Transform item;
	}

	[SerializeField] private List<ItemGhost> itemGhosts;
	[SerializeField] private MouseController mouseController;
	[SerializeField] private ItemFabric fabric;
	[SerializeField] private ToggleGroup toggleGroup;

	private List<GameObject> _items;
	private ItemType _selectedItemType;
	private bool _hasSelectedItem;
	private Transform _selectedItemGhost;

	private void Start()
	{
		_items = new List<GameObject>();
		mouseController.OnMouseClick += OnMouseClick;

		toggleGroup.SetAllTogglesOff();
		foreach (var ghost in itemGhosts)
		{
			ghost.item.gameObject.SetActive(false);
		}
	}

	private void Update()
	{
		if (_hasSelectedItem)
		{
			PutItemOnTheWall(_selectedItemGhost);
		}
	}

	private void PutItemOnTheWall(Transform item)
	{
		if (mouseController.IsMouseOverWall)
		{
			item.rotation = mouseController.SelectedWall.Rotation;

			var bounds = item.GetComponent<MeshRenderer>().bounds;
			item.position = mouseController.SelectedWall.GetPositionOnTheWall(mouseController.MouseWallPoint, bounds);
		}
	}

	private Transform GetGhostByType(ItemType type)
	{
		foreach (var ghost in itemGhosts)
		{
			if (ghost.type == type)
			{
				return ghost.item;
			}
		}
		return null;
	}

	private void CreateAndPutItem()
	{
		if (_hasSelectedItem)
		{
			toggleGroup.SetAllTogglesOff();
			UnselectItem();
			var item = fabric.CreateItem(_selectedItemType);
			PutItemOnTheWall(item.transform);
			_items.Add(item);
		}
	}

	public void UnselectItem()
	{
		_hasSelectedItem = false;
		if (_selectedItemGhost != null)
		{
			_selectedItemGhost.gameObject.SetActive(false);
		}
	}

	public void SelectItem(ItemType type)
	{
		_selectedItemType = type;
		_hasSelectedItem = true;
		_selectedItemGhost = GetGhostByType(type);
		_selectedItemGhost.gameObject.SetActive(true);
	}

	private void OnMouseClick()
	{
		if (mouseController.IsMouseOverWall)
		{
			CreateAndPutItem();
		}
	}
}
