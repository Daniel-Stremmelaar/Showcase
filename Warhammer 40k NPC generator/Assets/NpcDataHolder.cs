using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcDataHolder : MonoBehaviour
{
    public static NpcDataHolder DataHolder;

    private void Awake() => DataHolder = this;

    [Header ("Generation Data")]
    public races race;
    public roles role;
    public soldierTypes soldierType;
    public int baseStatModifier;

    [Header("Characteristics")]
    public int WS;
    public int BS;
    public int S;
    public int T;
    public int Ag;
    public int Int;
    public int Per;
    public int WP;
    public int Fel;
    public int Wounds;

    [Header("Gear")]
    public WeaponBasic BasicWeapon;
    public WeaponPistol Pistol;
    public WeaponMelee Melee;
    public WeaponGrenade Grenade;
    public Armor Armor;

    [Header("Psychic Powers")]
    public List<PsychicPower> PsychicPowers = new List<PsychicPower>();

    public void GenerateCharacteristics()
    {
        GenerateBaseStats();
        RacialAdjustments.RaceAdjust.GetRacialAdjustsForStats();
        RoleAdjustments.RoleAdjust.GetRoleAdjustsForStats();

        Wounds = Random.Range(1, 6) + (T/10)*2;
    }

    public void GenerateGear()
    {
        RoleAdjustments.RoleAdjust.GetRoleAdjustsForGear();
        RacialAdjustments.RaceAdjust.GetRacialAdjustsForGear();
    }

    private void GenerateBaseStats()
    {
        WS = 25 + Random.Range(1, 11) + Random.Range(1, 11) + baseStatModifier;
        BS = 25 + Random.Range(1, 11) + Random.Range(1, 11) + baseStatModifier;
        S = 25 + Random.Range(1, 11) + Random.Range(1, 11) + baseStatModifier;
        T = 25 + Random.Range(1, 11) + Random.Range(1, 11) + baseStatModifier;
        Ag = 25 + Random.Range(1, 11) + Random.Range(1, 11) + baseStatModifier;
        Int = 25 + Random.Range(1, 11) + Random.Range(1, 11) + baseStatModifier;
        Per = 25 + Random.Range(1, 11) + Random.Range(1, 11) + baseStatModifier;
        WP = 25 + Random.Range(1, 11) + Random.Range(1, 11) + baseStatModifier;
        Fel = 25 + Random.Range(1, 11) + Random.Range(1, 11) + baseStatModifier;
    }
}
