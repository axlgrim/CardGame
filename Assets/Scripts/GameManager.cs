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
    public bool isPaused = false;

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

    private Card[,] _cardArray = new Card[rows+1, columns+1];

    private void Start()
    {
        Vector3 start_pos = Card.transform.position;
        RevealedCard = null;


        for (int i = 0; i < columns; i++)
        {
            for (int j = 0; j < rows; j++)
            {

                if (0 == i && 0 == j)
                {
                    _cardArray[i, j] = Card;
                }
                else
                {
                    _cardArray[i, j] = Instantiate(Card) as Card;

                }

                if (cnt_rocket < 2)
                {
                    AddFace(Face_Rocket, _cardArray[i, j], 1);
                    cnt_rocket++;
                }
                else if (cnt_planet < 2)
                {
                    AddFace(Face_Planet, _cardArray[i, j], 2);
                    cnt_planet++;
                }
                else if (cnt_sun < 2)
                {
                    AddFace(Face_Sun, _cardArray[i, j], 3);
                    cnt_sun++;
                }
                else if (cnt_alien < 2)
                {
                    AddFace(Face_Alien, _cardArray[i, j], 4);
                    cnt_alien++;
                }
                else if (cnt_bender < 2)
                {
                    AddFace(Face_Bender, _cardArray[i, j], 5);
                    cnt_bender++;
                }
                else if (cnt_dart < 2)
                {
                    AddFace(Face_Dart, _cardArray[i, j], 6);
                    cnt_dart++;
                }


                //newCard = ChooseFace(UnityEngine.Random.Range(1, 7), newCard);

                float pos_X = (offset_X * i) + start_pos.x;
                float pos_Y = (offset_Y * j) + start_pos.y;

                _cardArray[i, j].transform.position = new Vector3(pos_X, pos_Y, 0f);

            }
        }
        RandomShuffle();


    }

    void RandomShuffle()
    {
        Vector3 switchCardposition;
        int rand_i;
        int rand_j;
        for (int i = 0; i < columns; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                switchCardposition = _cardArray[i, j].transform.position;
                rand_i = Random.Range(0, columns);
                rand_j = Random.Range(0, rows);
                _cardArray[i, j].transform.position = _cardArray[rand_i, rand_j].transform.position;
                _cardArray[rand_i, rand_j].transform.position = switchCardposition;

            }
        }

    }

    void AddFace(Sprite Face, Card cardToAssign, int id)
    {

        cardToAssign.CardFace = Face;
        cardToAssign.Id = id;
    }


}

