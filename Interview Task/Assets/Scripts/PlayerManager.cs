using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    private ShoppingCart _cart;

    private List<Outfit> _playerInventory = new List<Outfit>();
    private int _playerMoney = 100;

    public int GetPlayerMoney()
	{
        return _playerMoney;
	}

    public void AddToInventory()
	{
		foreach (Outfit item in _cart.GetCart())
		{
            _playerInventory.Add(item);
        }
    }
}
