using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;

public class OutfitButton : MonoBehaviour
{
    private Outfit _outfit;

	private DressingRoom _dressingRoom;

    public void SetOutfit(Outfit NewOutfit)
	{
		_outfit = NewOutfit;
	}

	public void ChooseOutfit()
	{
		_dressingRoom.ChosenOutfit(_outfit.GetSpriteLibraryAsset());
	}

	public void SetDressingRoomReference(DressingRoom reference)
	{
		_dressingRoom = reference;
	}
}
