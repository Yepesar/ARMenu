using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Food",menuName = "NewFood")]
public class SO_Food : ScriptableObject
{
    public string foodName;
    [TextArea]
    public string foodDescription;
    public int foodPrice;
}
