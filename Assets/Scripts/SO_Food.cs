using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Food",menuName = "NewFood")]
public class SO_Food : ScriptableObject
{
    public string foodName;
    [TextArea(5,25)]
    public string foodDescription;
    public string foodPrice;
    public string url;
}
