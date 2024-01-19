using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoppingCart : MonoBehaviour
{
    private List<Outfit> _cartItems = new List<Outfit>();

	private bool _isInCart;

    public void AddToCart(Outfit outfit)
	{
		_isInCart = false;

		foreach (Outfit item in _cartItems)
		{
			if (_cartItems.Contains(outfit))
			{
				_isInCart = true;
			}
		}

		if (!_isInCart)
		{
			_cartItems.Add(outfit);
		}

		foreach (Outfit item in _cartItems)
		{
			Debug.Log(item);
		}
	}

	public List<Outfit> GetCart()
	{
		return _cartItems;
	}

	public void SetCartEmpty()
	{
		_cartItems.Clear();
	}
}
