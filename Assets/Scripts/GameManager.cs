using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Variables for custom grid
    static int rows = 3;
    static int columns = 4;
    static float offset_X = 100f;
    static float offset_Y = 80f;

    // Face sprites
    public Sprite Face_Rocket;
    public Sprite Face_Planet;
    public Sprite Face_Sun;
    public Sprite Face_Alien;
    public Sprite Face_Bender;
    public Sprite Face_Dart;
    public int guessedCards = 0;

    // counters for each sprite
    int cnt_rocket = 0;
    int cnt_planet = 0;
    int cnt_sun = 0;
    int cnt_alien = 0;
    int cnt_bender = 0;
    int cnt_dart = 0;

    // field used for instantiation of the cards
    public Card Card;

    // Card choosen for comparison 
    public Card RevealedCard;

    private void Start()
    {
        Vector3 start_pos = Card.transform.position;
        RevealedCard = null;


        for (int i = 0; i < columns; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                Card newCard;
                if (0 == i && 0 == j)
                {
                    newCard = Card;
                }
                else
                {
                    newCard = Instantiate(Card) as Card;

                }
                
                newCard = ChooseFace(Random.Range(1, 7), newCard);

                float pos_X = (offset_X * i) + start_pos.x;
                float pos_Y = (offset_Y * j) + start_pos.y;

                newCard.transform.position = new Vector3(pos_X, pos_Y, 0f);

            }
        }


    }

    // Function randomly assigns face sprites to cards
    private Card ChooseFace(int i, Card card)
    {
        
        begin:

        switch (i)
        {
            case 1:
                if (cnt_rocket < 2)
                {
                    cnt_rocket++;
                    card.CardFace = Face_Rocket;
                    card.id = i;
                }
                else
                {
                    i = Random.Range(1, 7);
                    goto begin;
                }
                break;

            case 2:
                if (cnt_planet < 2)
                {
                    cnt_planet++;
                    card.CardFace = Face_Planet;
                    card.id = i;
                }
                else
                {
                    i = Random.Range(1, 7);
                    goto begin;
                }
                break;
            case 3:
                if (cnt_sun < 2)
                {
                    cnt_sun++;
                    card.CardFace =  Face_Sun;
                    card.id = i;
                }
                else
                {
                    i = Random.Range(1, 7);
                    goto begin;
                }
                break;
            case 4:
                if (cnt_alien < 2)
                {
                    cnt_alien++;
                    card.CardFace = Face_Alien;
                    card.id = i;
                }
                else
                {
                    i = Random.Range(1, 7);
                    goto begin;
                }
                break;
            case 5:
                if (cnt_bender < 2)
                {
                    cnt_bender++;
                    card.CardFace = Face_Bender;
                    card.id = i;
                }
                else
                {
                    i = Random.Range(1, 7);
                    goto begin;
                }
                break;
            case 6:
                if (cnt_dart < 2)
                {
                    cnt_dart++;
                    card.CardFace = Face_Dart;
                    card.id = i;
                }
                else
                {
                    i = Random.Range(1, 7);
                    goto begin;
                }
                break;

            default:
                break;

        }
        return card;
    }
}

