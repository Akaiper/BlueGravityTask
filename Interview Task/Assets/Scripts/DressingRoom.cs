using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.U2D.Animation;

public class DressingRoom : MonoBehaviour
{

	[SerializeField]
	private PlayerManager _player;

	[SerializeField]
	private GameObject _buttonScrollView;
	
	[SerializeField]
	private GameObject _content;

	[SerializeField]
	private UnityEvent _IntoDressingRoom;

	private List<Outfit> _playerInventory = new List<Outfit>();

	private Vector3 _dressingRoomPosition;

	private GameObject _newButton;

	private Vector3 _playerOriginalPosition;

	private void Start()
	{
		_dressingRoomPosition = new Vector3(-7.69999981f, 2.67000008f, -0.0500000007f);
		_playerOriginalPosition = new Vector3(-8.22000027f, 0.0599999987f, -0.0500000007f);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		
		_player.gameObject.transform.position = _dressingRoomPosition;

		_IntoDressingRoom.Invoke();

		_playerInventory = _player.GetPlayerInventory();

		ListInventory();
	}

	private void ListInventory()
	{
		foreach  (Outfit item in _playerInventory)
		{

			_newButton = GameObject.Instantiate(_buttonScrollView, _content.transform);

			_newButton.GetComponent<OutfitButton>().SetOutfit(item);
			_newButton.GetComponent<OutfitButton>().SetDressingRoomReference(this.gameObject.GetComponent<DressingRoom>());

			_newButton.GetComponentInChildren<TextMeshProUGUI>().text = "Price: $" + item.GetPrice().ToString();
			_newButton.GetComponent<Image>().sprite = item.GetOutfitSprite();
		}
	}

	public void ChosenOutfit(SpriteLibraryAsset outfit)
	{
		_player.SetLibraryAsset(outfit);
	}

	public void ExitDressingRoom()
	{
		_player.gameObject.transform.position = _playerOriginalPosition;
	} 
}
