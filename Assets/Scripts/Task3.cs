using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.VersionControl.Asset;

public class Task3 : MonoBehaviour
{
    Stack deck= new Stack();
    List<string> hand=new List<string>();
    List<string> cards =new List<string>{ "King of Hearts", "King of Spades", "King of Clubs", "King of Diamonds", "Queen of Hearts", "Queen of Spades", "Queen of Clubs", "Queen of Diamonds", "Jack of Hearts", "Jack of Spades", "Jack of Clubs", "Jack of Diamonds", "Ace of Hearts", "Ace of Spades", "Ace of Clubs", "Ace of Diamonds" };
    // Start is called before the first frame update
    void Start()
    {
        while (cards.Count>0)
        {
            string newCard = cards[Random.Range(0,cards.Count)];
            cards.Remove(newCard);
            deck.Push(newCard);
        }
        for(int i = 0; i < 4; i++)
        {
            hand.Add(deck.Pop().ToString());
            
        }
        string handOutput = "I made the initial deck and draw. ";
        if (!WinningHand(ref handOutput))
        {
            PlayGame();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void PlayGame()
    {
        

        string cardToRemove = hand[Random.Range(0, hand.Count)];
        cards.Remove(cardToRemove);
        
        string cardToAdd = deck.Pop().ToString();
        string handOutput = "I discarded " + cardToRemove + " and draw " + cardToAdd+". ";
        hand.Add(cardToAdd);
        if(!WinningHand(ref handOutput))
        {
            Invoke("PlayGame", 0.5f);
        }
     
    }

    bool WinningHand(ref string handOutput)
    {
        int hearts = 0, spades = 0, clubs = 0, diamonds = 0;
        handOutput += "My hand is: ";
        foreach (string card in hand)
        {
            if (card.Contains("Hearts"))
            {
                hearts++;
            }
            else if (card.Contains("Spades"))
            {
                spades++;
            }
            else if (card.Contains("Clubs"))
            {
                clubs++;
            }
            else if (card.Contains("Diamonds"))
            {
                diamonds++;
            }
            handOutput += card + ", ";
        }
        if (hearts >= 3 || spades >= 3 || clubs >= 3 || diamonds >= 3)
        {

            handOutput += ". this is a winning hand";
            print(handOutput);
            return true;
        }
        else
        {
          
            handOutput += ". this is not a winning hand";
            print(handOutput);
            return false;
        }
    }
}
