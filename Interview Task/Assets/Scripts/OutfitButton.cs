using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;

public class OutfitButton : MonoBehaviour
{
    private Outfit _outfit;

	private DressingRoom _dressingRoom;
	private SellOutfits _sellOutfits;

    public void SetOutfit(Outfit NewOutfit)
	{
		_outfit = NewOutfit;
	}

	public void ChooseOutfit()
	{
		_dressingRoom.ChosenOutfit(_outfit.GetSpriteLibraryAsset(), _outfit);
	}

	public void SetDressingRoomReference(DressingRoom reference)
	{
		_dressingRoom = reference;
	}
	
	public void SetRegisterReference(SellOutfits reference)
	{
		_sellOutfits = reference;
	}

	public void ThisOutfitPrice()
	{
		_sellOutfits.SetTotalPrice(_outfit.GetPrice(), _outfit);
	}
}
