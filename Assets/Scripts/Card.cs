using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{

    public SpriteRenderer SpriteRend;
    public GameManager Manager;
	public Card CardToCompare = null;
    public Sprite CardFace;
    public Sprite CardBack;


    public int Id;

    public bool Revealed = false; 

    public float ChangeTime = 2f;

    private float _time;
    private float _revealTime;

    private bool _cardFlag;
    private bool _revealFinished = false;
    private bool _startFinished = false;

    // Showing faces if start time has not elapsed
    void Update()
    {
        if (!_startFinished)
        {
            _time += Time.deltaTime;
            if (_time >= ChangeTime)
            {
                SpriteRend.sprite = CardBack;
                _cardFlag = true;
                _startFinished = true;
            }
            else
            {
                SpriteRend.sprite = CardFace;
                _cardFlag = false;
            }
        }
    }

    // on click the instance will be assigned to appropriate field for future comparison
    public void OnMouseUp()
    {
		if (_startFinished && !Revealed && !Manager.isPaused) 
		{
			if (null == Manager.RevealedCard)
			{
				Manager.RevealedCard = this;
				SpriteChange(Manager.RevealedCard);
			}
			else if(Manager.RevealedCard != this)
			{
				CardToCompare = this;
				SpriteChange(CardToCompare);
				CheckCards();
			}
		}      
    }


    // Changes Back sprite to Face sprite
    public void SpriteChange(Card thisCard)
    {
		if (!thisCard.Revealed) 
		{
			if (thisCard._cardFlag)
			{
				thisCard.SpriteRend.sprite = CardFace;
				thisCard._cardFlag = false;

			}
			else
			{
				thisCard.SpriteRend.sprite = CardBack;
				thisCard._cardFlag = true;
			}
		}
    }

    // Compares cards on id
    void CheckCards()
    {
		if (Manager.RevealedCard.Id == CardToCompare.Id) 
		{
			Manager.RevealedCard.Revealed = true;
			CardToCompare.Revealed = true;
			Manager.RevealedCard = null;
            Manager.guessedCards++;
		}
		else 
		{
			WaitAndClose(Manager.RevealedCard, CardToCompare);
			Manager.RevealedCard = null;
			CardToCompare = null;
			_revealTime = 0f;
			_revealFinished = false;

		}
    }
 
	void WaitAndClose(Card firstCard, Card secondCard)
	{
		while(!_revealFinished) 
		{
			_revealTime += Time.deltaTime;
			if (_revealTime >= ChangeTime ) 
			{
				SpriteChange(firstCard);
				SpriteChange(secondCard);
				_revealFinished = true;
				
			}
		}		
	}
}
