using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Power", menuName = "New Psychic Power", order = 6)]
public class PsychicPower : ScriptableObject
{
    public string Name;
    public string Description;
    public string Reference;
}
