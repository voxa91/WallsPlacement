using UnityEngine;

public class SelectableItem : MonoBehaviour {
	[SerializeField] private ItemType itemType;
	[SerializeField] private ItemsController itemsController;
	
	public void OnToggleClick(bool isOn)
	{
		if (isOn)
		{
			itemsController.SelectItem(itemType);
		}
		else
		{
			itemsController.UnselectItem();
		}
	}
}
