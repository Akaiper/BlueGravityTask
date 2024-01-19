using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    private ShoppingCart _cart;

	[SerializeField]
	private TextMeshProUGUI _moneyText;

    private List<Outfit> _playerInventory = new List<Outfit>();
    private int _playerMoney = 100;


	private void Start()
	{
		_playerInventory.Add(gameObject.GetComponent<Outfit>());

		_moneyText.text = _playerMoney.ToString();
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
	
	public void RemoveFromInventory(List<Outfit> OutfitsSold)
	{
		foreach (Outfit item in OutfitsSold)
		{
            _playerInventory.Remove(item);
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

	public void SetMoney(int NewMoney)
	{
		_playerMoney = NewMoney;

		UpdateMoneyUI();
	}

	private void UpdateMoneyUI()
	{
		_moneyText.text = _playerMoney.ToString();
	}

	public void PlayerIsWearingOutfit(Outfit NewOutfit)
	{
		foreach (Outfit item in _playerInventory)
		{
			if(item.name == NewOutfit.name)
			{
				item.SetPlayerIsWearing(true);
			}
			else
			{
				item.SetPlayerIsWearing(false);
			}
		}

	}
}
