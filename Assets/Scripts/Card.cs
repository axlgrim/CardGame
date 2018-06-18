using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{

    public SpriteRenderer SpriteRend;
    public GameManager Manager;
	public Card cardToCompare = null;
    public Sprite CardFace;
    public Sprite CardBack;

    public int id;

    public bool revealed = false; 

    public float ChangeTime = 2f;

    private float time;
    private float revealTime;

    private bool cardFlag;
    private bool revealFinished = false;
    private bool startFinished = false;

    // Showing faces if start time has not elapsed
    void Update()
    {
        if (!startFinished)
        {
            time += Time.deltaTime;
            if (time >= ChangeTime)
            {
                SpriteRend.sprite = CardBack;
                cardFlag = true;
                startFinished = true;
            }
            else
            {
                SpriteRend.sprite = CardFace;
                cardFlag = false;
            }
        }
    }

    // on click the instance will be assigned to appropriate field for future comparison
    public void OnMouseUp()
    {
		if (startFinished && !revealed) 
		{
			if (null == Manager.RevealedCard)
			{
				Manager.RevealedCard = this;
				SpriteChange(Manager.RevealedCard);
			}
			else if(Manager.RevealedCard != this)
			{
				cardToCompare = this;
				SpriteChange(cardToCompare);
				CheckCards();
			}
		}      
    }


    // Changes Back sprite to Face sprite
    public void SpriteChange(Card thisCard)
    {
		if (!thisCard.revealed) 
		{
			if (thisCard.cardFlag)
			{
				thisCard.SpriteRend.sprite = CardFace;
				thisCard.cardFlag = false;

			}
			else
			{
				thisCard.SpriteRend.sprite = CardBack;
				thisCard.cardFlag = true;
			}
		}
    }

    // Compares cards on id
    void CheckCards()
    {
		if (Manager.RevealedCard.id == cardToCompare.id) 
		{
			Manager.RevealedCard.revealed = true;
			cardToCompare.revealed = true;
			Manager.RevealedCard = null;
		}
		else 
		{
			waitAndClose(Manager.RevealedCard, cardToCompare);
			Manager.RevealedCard = null;
			cardToCompare = null;
			revealTime = 0f;
			revealFinished = false;

		}
    }
 
	void waitAndClose(Card firstCard, Card secondCard)
	{
		while(!revealFinished) 
		{
			revealTime += Time.deltaTime;
			if (revealTime >= ChangeTime ) 
			{
				SpriteChange(firstCard);
				SpriteChange(secondCard);
				revealFinished = true;
				
			}
		}		
	}
}
