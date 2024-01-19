using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEngine.UI;

public class SellOutfits : MonoBehaviour
{
	[SerializeField]
	private PlayerManager _player;

	[SerializeField]
	private GameObject _buttonScrollView;

	[SerializeField]
	private GameObject _content;
	
	[SerializeField]
	private TextMeshProUGUI _totalText;
	private int _total;

	private List<Outfit> _playerInventory = new List<Outfit>();

	private GameObject _newButton;

	private List<GameObject> _contentButtons = new List<GameObject>();

	private List<Outfit> _itemsForSale = new List<Outfit>();
	


	public void WantToSell()
	{
		_totalText.text = "Total: 0";
		_total = 0;
		_playerInventory = _player.GetPlayerInventory();

		ListInventory();
	}

	private void ListInventory()
	{
		foreach (GameObject item in _contentButtons)
		{
			Destroy(item);
		}
		_contentButtons.Clear();
		_itemsForSale.Clear();
		foreach (Outfit item in _playerInventory)
		{
			if (!item.GetIsInitialOutfit() && !item.GetPlayerIsWearing())
			{
				_newButton = GameObject.Instantiate(_buttonScrollView, _content.transform);

				_contentButtons.Add(_newButton);

				_newButton.GetComponent<OutfitButton>().SetOutfit(item);
				_newButton.GetComponent<OutfitButton>().SetRegisterReference(this.gameObject.GetComponent<SellOutfits>());

				_newButton.GetComponentInChildren<TextMeshProUGUI>().text = "Price: $" + item.GetPrice().ToString();
				_newButton.GetComponent<Image>().sprite = item.GetOutfitSprite();
			}
		}
	}

	public void SetTotalPrice(int ItemPrice, Outfit Button)
	{

		if (!_itemsForSale.Contains(Button))
		{
			_itemsForSale.Add(Button);
			_total += ItemPrice;
			_totalText.text = "Total: " + _total;
		}

	}

	public void SoldItems()
	{
		_player.SetMoney(_player.GetPlayerMoney() + _total);
		_player.RemoveFromInventory(_itemsForSale);
		gameObject.GetComponent<Shopkeeper>().ReturnItems(_itemsForSale);
	}
}
