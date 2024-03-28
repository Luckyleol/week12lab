using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task1 : MonoBehaviour
{
    [SerializeField]
    NameLibrary nameLibrary;
    Dictionary<string,char> players = new Dictionary<string,char>();
    Queue<string> playerQueue=new Queue<string>();
    string lastLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    private void Awake()
    {
        foreach(string name in nameLibrary.Names)
        {
            players[name] = lastLetters[Random.Range(0, lastLetters.Length)];
        }
        int initialAmount=Random.Range(4,8);
        string outputString = "Initial login queue created. There are " + initialAmount + " players in the queue: ";
        for (int i = 0; i < initialAmount; i++)
        {
            string name = nameLibrary.Names[Random.Range(0, nameLibrary.Names.Count)];
            playerQueue.Enqueue(name + " "+ players[name]);
            outputString += " " + name + " " + players[name] +",";
            //Debug.Log(name + " " + players[name]);
        }
        print(outputString);
        InvokeRepeating("LoginLoop", 1, 2);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void LoginLoop()
    {

        print(playerQueue.Dequeue() + " is now inside the game");
        string player;
        do
        {
            string name = nameLibrary.Names[Random.Range(0, nameLibrary.Names.Count)];
            player = name + " " + players[name];
        } while (playerQueue.Contains(player));
        print(player + " is trying to login and added to the login queue.");
        playerQueue.Enqueue(player);
    }
}
