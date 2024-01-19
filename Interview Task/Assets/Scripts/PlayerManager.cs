using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    private ShoppingCart _cart;

    private List<Outfit> _playerInventory = new List<Outfit>();
    private int _playerMoney = 100;



	private void Start()
	{
		_playerInventory.Add(gameObject.GetComponent<Outfit>());
	}

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

    public List<Outfit> GetPlayerInventory()
	{
        return _playerInventory;
	}

	public void SetLibraryAsset(SpriteLibraryAsset newOutfit)
	{
		gameObject.GetComponentInChildren<SpriteLibrary>().spriteLibraryAsset = newOutfit;
	}
}
