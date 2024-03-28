using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="Name Library",menuName ="NameLibrary",order =0)]
public class NameLibrary : ScriptableObject
{
    [SerializeField]
    List<string> names = new List<string>();
    public IReadOnlyList<string> Names { get { return names.AsReadOnly(); } }
    
}
