using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;

public class Outfit : MonoBehaviour
{
    [SerializeField]
    private GameObject Mannequin;
    [SerializeField]
    protected SpriteLibraryAsset thisSpriteLibraryAsset;
    [SerializeField]
    protected Sprite thisOutfitSprite;
    [SerializeField]
    private int Price;
    [SerializeField]
    protected bool isInitialOutfit;
    [SerializeField]
    private bool playerOwnsIt;
    [SerializeField]
    private bool playerIsWearing;

    public GameObject GetMannequin()
	{
        return Mannequin;
	}

    public SpriteLibraryAsset GetSpriteLibraryAsset()
    {
        return thisSpriteLibraryAsset;
    }

    public Sprite GetOutfitSprite()
    {
        return thisOutfitSprite;
    }

    public int GetPrice()
    {
        return Price;
    }

    public bool GetIsInitialOutfit()
    {
        return isInitialOutfit;
    }

    public bool GetPlayerOwnsIt()
    {
        return playerOwnsIt;
    }

    public void SetPlayerOwnsIt(bool PlayerIsTheOwner)
	{
        playerOwnsIt = PlayerIsTheOwner;
	}
    
    public void SetPlayerIsWearing(bool PlayerChoseIt)
	{
        playerIsWearing = PlayerChoseIt;
	}

    public bool GetPlayerIsWearing()
	{
        return playerIsWearing;
	}
}
