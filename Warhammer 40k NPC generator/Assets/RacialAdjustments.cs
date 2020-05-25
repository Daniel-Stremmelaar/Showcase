using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacialAdjustments : MonoBehaviour
{
    public static RacialAdjustments RaceAdjust;

    private void Awake() => RaceAdjust = this;

    [Header("Xenos Basic Weapons")]
    public WeaponBasic KrootRifle;
    public WeaponBasic OrkShoota;
    public WeaponBasic SplinterRifle;
    public WeaponBasic PulseRifle;

    [Header("Xenos Pistols")]
    public WeaponPistol OrkSlugga;
    public WeaponPistol SplinterPistol;
    public WeaponPistol PulsePistol;

    [Header("Xenos Melee Weapons")]
    public WeaponMelee OrkChoppa;

    [Header("Xenos Armor")]
    public Armor TauReconArmor;
    public Armor TauCombatArmor;
    public Armor EldarRaiderArmor;

    public void GetRacialAdjustsForStats()
    {
        switch (NpcDataHolder.DataHolder.race)
        {
            case races.Human:
                break;
            case races.Ork:
                NpcDataHolder.DataHolder.BS -= 15;
                NpcDataHolder.DataHolder.S += 5;
                NpcDataHolder.DataHolder.T += 5;
                NpcDataHolder.DataHolder.Ag -= 5;
                NpcDataHolder.DataHolder.Int -= 10;
                NpcDataHolder.DataHolder.Per -= 5;
                NpcDataHolder.DataHolder.WP -= 5;
                NpcDataHolder.DataHolder.Fel -= 10;
                break;
            case races.Kroot:
                NpcDataHolder.DataHolder.WS += 5;
                NpcDataHolder.DataHolder.Ag += 5;
                NpcDataHolder.DataHolder.Int -= 5;
                NpcDataHolder.DataHolder.Fel -= 5;
                break;
            case races.Dark_Eldar:
                NpcDataHolder.DataHolder.T -= 5;
                NpcDataHolder.DataHolder.Ag += 5;
                NpcDataHolder.DataHolder.Per += 5;
                NpcDataHolder.DataHolder.Fel -= 5;
                break;
            case races.Tau:
                NpcDataHolder.DataHolder.WS -= 5;
                NpcDataHolder.DataHolder.S -= 5;
                NpcDataHolder.DataHolder.Ag += 5;
                NpcDataHolder.DataHolder.Int += 5;
                break;
            default:
                break;
        }
    }

    public void GetRacialAdjustsForGear()
    {
        int rng;
        switch (NpcDataHolder.DataHolder.race)
        {
            case races.Human:
                break;
            case races.Ork:
                rng = Random.Range(1, 101);
                if(rng < 91)
                {
                    NpcDataHolder.DataHolder.BasicWeapon = OrkShoota;
                }
                rng = Random.Range(1, 101);
                if (rng < 91)
                {
                    NpcDataHolder.DataHolder.Pistol = OrkSlugga;
                }
                rng = Random.Range(1, 101);
                if (rng < 91)
                {
                    NpcDataHolder.DataHolder.Melee = OrkChoppa;
                }
                break;
            case races.Kroot:
                rng = Random.Range(1, 101);
                if (rng < 67)
                {
                    NpcDataHolder.DataHolder.BasicWeapon = KrootRifle;
                }
                break;
            case races.Dark_Eldar:
                rng = Random.Range(1, 101);
                if (rng < 51)
                {
                    NpcDataHolder.DataHolder.BasicWeapon = SplinterRifle;
                }
                rng = Random.Range(1, 101);
                if(rng < 51)
                {
                    NpcDataHolder.DataHolder.Pistol = SplinterPistol;
                }
                rng = Random.Range(1, 101);
                if(rng < 51)
                {
                    NpcDataHolder.DataHolder.Armor = EldarRaiderArmor;
                }
                break;
            case races.Tau:
                rng = Random.Range(1, 101);
                if(rng < 81)
                {
                    NpcDataHolder.DataHolder.BasicWeapon = PulseRifle;
                }
                rng = Random.Range(1, 101);
                if(rng < 81)
                {
                    NpcDataHolder.DataHolder.Pistol = PulsePistol;
                }
                if(rng < 16)
                {
                    NpcDataHolder.DataHolder.Armor = TauCombatArmor;
                }
                else if (rng < 51)
                {
                    NpcDataHolder.DataHolder.Armor = TauReconArmor;
                }
                break;
            default:
                break;
        }
    }
}
