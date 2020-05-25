using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Armor", menuName = "New Armor", order = 5)]
public class Armor : ScriptableObject
{
    public string Name;
    public string Value;
    public string Locations;
}
