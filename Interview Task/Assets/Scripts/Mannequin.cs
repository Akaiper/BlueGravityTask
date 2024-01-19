using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;


public class Mannequin : MonoBehaviour
{
	[SerializeField]
	private UnityEvent PriceTag;
	[SerializeField]
	private UnityEvent TriggerExit;
	[SerializeField]
	private TextMeshProUGUI _price;
	[SerializeField]
	private Outfit _outfitData;
	[SerializeField]
	private GameObject _outfit;
	[SerializeField]
	private bool _isInCart = false;

	private void Start()
	{
		_price.text = _outfitData.GetPrice().ToString();
	}

	public void PlayerBoughtIt()
	{
		_outfitData.SetPlayerOwnsIt(true);
		_outfit.gameObject.SetActive(false);
	}
	public void PlayerSoldIt()
	{
		_outfitData.SetPlayerOwnsIt(false);
		_outfit.gameObject.SetActive(true);
	}

	public void IsInCart(bool toCart)
	{
		_isInCart = toCart;
		_outfit.gameObject.SetActive(false);
	}

	public void IsNotInCart()
	{
		_isInCart = false;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (!_outfitData.GetPlayerOwnsIt() && !_isInCart)
		{
			PriceTag.Invoke();
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		TriggerExit.Invoke();
	}
}
