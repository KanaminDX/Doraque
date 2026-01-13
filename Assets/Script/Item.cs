//Item.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(menuName = "Item/SimpleItem")]
public class Item : ScriptableObject
{
    public string Name;
    public string Description;
    public int Money;
}