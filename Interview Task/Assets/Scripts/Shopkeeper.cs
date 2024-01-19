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
	private UnityEvent _startDialogue;

	[SerializeField]
	private ShoppingCart _manager;
	[SerializeField]
	private PlayerManager player;

	private List<Outfit> _playerCart = new List<Outfit>();

	private int _cartCost = 0;

	private GameObject _mannequin;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		CheckOutCart();
		StartDialogue();
	}

	private void CheckOutCart()
	{

	}

	private void StartDialogue()
	{
		_shopkeeperText.text = "Want to BUY or SELL?";
		_startDialogue.Invoke();
	}

	public void BuyDialogue()
	{
		foreach (Outfit item in _playerCart)
		{
			_cartCost += item.GetPrice();
		}

		if(player.GetPlayerMoney() >= _cartCost)
		{
			_shopkeeperText.text = "Your total is $" + _cartCost + " \n Want to buy your cart?";
		}
		else
		{
			_shopkeeperText.text = "Your total is $" + _cartCost + " \n Looks like you don't have enough money, want to edit your cart?";
		}
	}

	public void DidntBuyCart()
	{
		foreach (Outfit item in _manager.GetCart())
		{
			_mannequin = item.GetMannequin();
			_mannequin.GetComponent<Mannequin>().PlayerSoldIt();

			Debug.Log(_mannequin);
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
