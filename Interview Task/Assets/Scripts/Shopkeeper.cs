using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class Shopkeeper : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI _shopkeeperText;
	[SerializeField]
	private TextMeshProUGUI _2ndRedButton;
	[SerializeField]
	private GameObject _2ndGreenButton;

	[SerializeField]
	private UnityEvent _startDialogue;

	[SerializeField]
	private ShoppingCart _manager;

	[SerializeField]
	private PlayerManager player;
	
	[SerializeField]
	private GameObject[] _mannequins = new GameObject[17];

	private List<Outfit> _playerCart = new List<Outfit>();

	private int _cartCost = 0;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		StartDialogue();
	}

	private void StartDialogue()
	{
		_shopkeeperText.text = "Want to BUY or SELL?";
		_startDialogue.Invoke();
	}

	public void BuyDialogue()
	{
		_cartCost = 0;

		foreach (Outfit item in _playerCart)
		{
			_cartCost += item.GetPrice();
		}

		if(player.GetPlayerMoney() >= _cartCost)
		{
			_shopkeeperText.text = "Your total is $" + _cartCost + " \n Want to buy your cart?";
			_2ndRedButton.text = "No";
		}
		else
		{
			_shopkeeperText.text = "Your total is $" + _cartCost + " \n Looks like you don't have enough money,\n  I'll empty your cart for you to choose again!";
			_2ndRedButton.text = "OK";
			_2ndGreenButton.SetActive(false);

		}
	}

	public void BoughtCart()
	{
		foreach  (Outfit item in _playerCart)
		{
			item.GetComponent<Mannequin>().IsNotInCart();
		}

		player.SetMoney(player.GetPlayerMoney() - _cartCost);
	}

	public void DidntBuyCart()
	{

		foreach (Outfit item in _playerCart)
		{
			foreach (GameObject mannequin in _mannequins)
			{
				if (item.gameObject.name == mannequin.gameObject.name)
				{
					mannequin.GetComponent<Mannequin>().PlayerSoldIt();
					mannequin.GetComponent<Mannequin>().IsNotInCart();
				}
			}
		}
	}
	public void ReturnItems(List<Outfit> Returns)
	{
		foreach (Outfit item in Returns)
		{
			foreach (GameObject mannequin in _mannequins)
			{
				if (item.gameObject.name == mannequin.gameObject.name)
				{
					mannequin.GetComponent<Mannequin>().PlayerSoldIt();
					mannequin.GetComponent<Mannequin>().IsNotInCart();
				}
			}
		}
	}
	
	public void SellDialogue()
	{

	}

	public void SeeCart()
	{
		_playerCart = _manager.GetCart();
	}
}
