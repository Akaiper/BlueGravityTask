using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    
    [SerializeField]
    private SpriteRenderer[] _mannequins = new SpriteRenderer[17];

    // Start is called before the first frame update
    void Start()
    {
        DressMannequins();
    }

    private void DressMannequins()
	{

		foreach  (SpriteRenderer mannequin in _mannequins)
		{
            mannequin.sprite = mannequin.GetComponentInParent<Outfit>().GetOutfitSprite();

        }
	}
}
