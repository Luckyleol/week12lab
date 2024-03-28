using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task2 : MonoBehaviour
{
    [SerializeField]
    NameLibrary nameLibrary;
    string[] nameArray=new string[15];
    
    // Start is called before the first frame update
    void Start()
    {
        HashSet<string> names = new HashSet<string>();
        HashSet<string> duplicates = new HashSet<string>();
        string arrayOutput = "Created the name array: ";
        for(int i = 0; i < nameArray.Length; i++)
        {
            nameArray[i] = nameLibrary.Names[Random.Range(0, nameLibrary.Names.Count)];
            if(!names.Add(nameArray[i]))
            {
                duplicates.Add(nameArray[i]);
            }
            arrayOutput +=nameArray[i] + ", ";
        }
        print(arrayOutput);
        string duplicateOutput = "The array has duplicate names: ";
        foreach(string name in duplicates)
        {
            duplicateOutput += name+", ";
        }
        print(duplicateOutput);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
