using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoleAdjustments : MonoBehaviour
{
    public static RoleAdjustments RoleAdjust;

    private void Awake() => RoleAdjust = this;

    [Header("Basic Weapons")]
    public WeaponBasic Lascarbine;
    public WeaponBasic Lasgun;
    public WeaponBasic Hellgun;
    public WeaponBasic Autogun;
    public WeaponBasic Shotgun;
    public WeaponBasic PumpShotgun;
    public WeaponBasic Boltgun;
    public WeaponBasic MarsMeltagun;
    public WeaponBasic PlasmaGun;

    [Header("Pistol Weapons")]
    public WeaponPistol Laspistol;
    public WeaponPistol Hellpistol;
    public WeaponPistol DuelingPistol;
    public WeaponPistol Autopistol;
    public WeaponPistol Handcannon;
    public WeaponPistol StubRevolver;
    public WeaponPistol BoltPistol;
    public WeaponPistol InfernoPistol;
    public WeaponPistol PlasmaPistol;

    [Header("Melee Weapons")]
    public WeaponMelee Knife;
    public WeaponMelee Sword;
    public WeaponMelee Truncheon;
    public WeaponMelee Staff;
    public WeaponMelee ChainSword;
    public WeaponMelee ChainAxe;
    public WeaponMelee OfficerCutlass;
    public WeaponMelee ShockStaff;

    [Header("Grenades")]
    public WeaponGrenade FragGrenade;
    public WeaponGrenade KrakGrenade;
    public WeaponGrenade PlasmaGrenade;
    public WeaponGrenade SmokeGrenade;

    [Header("Armor")]
    public Armor FlakCloak;
    public Armor GuardFlakArmor;
    public Armor XenoMesh;
    public Armor EnforcerLightCarapace;
    public Armor CarapaceChestplate;
    public Armor StormTrooperCarapace;
    public Armor ArmouredBodyglove;
    public Armor LightPowerArmor;

    [Header("Psychic Powers")]
    public List<PsychicPower> Powers = new List<PsychicPower>();

    public void GetRoleAdjustsForStats()
    {
        switch (NpcDataHolder.DataHolder.role)
        {
            case roles.Thug:
                NpcDataHolder.DataHolder.WS += 5;
                NpcDataHolder.DataHolder.Fel += 5;
                NpcDataHolder.DataHolder.Int -= 5;
                NpcDataHolder.DataHolder.WP -= 5;
                break;
            case roles.Con_Man:
                NpcDataHolder.DataHolder.Fel += 5;
                NpcDataHolder.DataHolder.Per += 5;
                NpcDataHolder.DataHolder.WP -= 5;
                NpcDataHolder.DataHolder.T -= 5;
                break;
            case roles.Sorcerer:
                NpcDataHolder.DataHolder.WP += 10;
                NpcDataHolder.DataHolder.Fel -= 5;
                NpcDataHolder.DataHolder.T -= 5;
                NpcDataHolder.DataHolder.S -= 5;
                break;
            case roles.Soldier:
                GetSoldierStatAdjust();
                break;
            default:
                break;
        }
    }

    private void GetSoldierStatAdjust()
    {
        switch (NpcDataHolder.DataHolder.soldierType)
        {
            case soldierTypes.Normal:
                NpcDataHolder.DataHolder.WS += 5;
                NpcDataHolder.DataHolder.BS += 5;
                NpcDataHolder.DataHolder.Fel -= 5;
                NpcDataHolder.DataHolder.Int -= 5;
                break;
            case soldierTypes.Light:
                NpcDataHolder.DataHolder.Per += 5;
                NpcDataHolder.DataHolder.Ag += 5;
                NpcDataHolder.DataHolder.WP -= 5;
                NpcDataHolder.DataHolder.Fel -= 5;
                break;
            case soldierTypes.Heavy:
                NpcDataHolder.DataHolder.T += 5;
                NpcDataHolder.DataHolder.WS += 5;
                NpcDataHolder.DataHolder.Fel -= 5;
                NpcDataHolder.DataHolder.Int -= 5;
                break;
            case soldierTypes.Super_Heavy:
                NpcDataHolder.DataHolder.T += 10;
                NpcDataHolder.DataHolder.WS += 5;
                NpcDataHolder.DataHolder.S += 5;
                NpcDataHolder.DataHolder.Ag -= 10;
                NpcDataHolder.DataHolder.Fel -= 5;
                NpcDataHolder.DataHolder.Int -= 5;
                break;
        }
    }

    public void GetRoleAdjustsForGear()
    {
        switch (NpcDataHolder.DataHolder.role)
        {
            case roles.Thug:
                NpcDataHolder.DataHolder.BasicWeapon = (WeaponBasic)GenerateWeapon(Hellgun, null, Lasgun, Shotgun, Lascarbine, Autogun);
                NpcDataHolder.DataHolder.Pistol = (WeaponPistol)GenerateWeapon(BoltPistol, Hellpistol, Laspistol, Autopistol, StubRevolver, StubRevolver);
                NpcDataHolder.DataHolder.Melee = (WeaponMelee)GenerateWeapon(Sword, Sword, Truncheon, Knife, Knife, Knife);
                NpcDataHolder.DataHolder.Grenade = (WeaponGrenade)GenerateWeapon(FragGrenade, SmokeGrenade, null, null, null, null);
                NpcDataHolder.DataHolder.Armor = GenerateArmor(GuardFlakArmor, FlakCloak, XenoMesh, null);
                break;
            case roles.Con_Man:
                NpcDataHolder.DataHolder.BasicWeapon = (WeaponBasic)GenerateWeapon(null, null, Shotgun, Lascarbine, Autogun, null);
                NpcDataHolder.DataHolder.Pistol = (WeaponPistol)GenerateWeapon(Hellpistol, Laspistol, Autopistol, StubRevolver, StubRevolver, StubRevolver);
                NpcDataHolder.DataHolder.Melee = (WeaponMelee)GenerateWeapon(Truncheon, Truncheon, Knife, Knife, Knife, Knife);
                NpcDataHolder.DataHolder.Grenade = (WeaponGrenade)GenerateWeapon(SmokeGrenade, null, null, null, null, null);
                NpcDataHolder.DataHolder.Armor = GenerateArmor(null, FlakCloak, XenoMesh, null);
                break;
            case roles.Sorcerer:
                NpcDataHolder.DataHolder.BasicWeapon = (WeaponBasic)GenerateWeapon(null, null, null, Shotgun, Lascarbine, Autogun);
                NpcDataHolder.DataHolder.Pistol = (WeaponPistol)GenerateWeapon(Hellpistol, Laspistol, Autopistol, StubRevolver, StubRevolver, StubRevolver);
                NpcDataHolder.DataHolder.Melee = (WeaponMelee)GenerateWeapon(ShockStaff, Truncheon, Knife, Knife, Staff, Staff);
                NpcDataHolder.DataHolder.Grenade = (WeaponGrenade)GenerateWeapon(FragGrenade, SmokeGrenade, null, null, null, null);
                NpcDataHolder.DataHolder.Armor = GenerateArmor(null, FlakCloak, XenoMesh, null);
                break;
            case roles.Soldier:
                GetSoldierAdjustsForGear();
                break;
            default:
                NpcDataHolder.DataHolder.BasicWeapon = Autogun;
                NpcDataHolder.DataHolder.Pistol = StubRevolver;
                NpcDataHolder.DataHolder.Melee = Knife;
                NpcDataHolder.DataHolder.Grenade = null;
                NpcDataHolder.DataHolder.Armor = XenoMesh;
                break;
        }
    }

    private void GetSoldierAdjustsForGear()
    {
        switch (NpcDataHolder.DataHolder.soldierType)
        {
            case soldierTypes.Normal:
                NpcDataHolder.DataHolder.BasicWeapon = (WeaponBasic)GenerateWeapon(Hellgun, Hellgun, Lasgun, PumpShotgun, Lasgun, Autogun);
                NpcDataHolder.DataHolder.Pistol = (WeaponPistol)GenerateWeapon(Hellpistol, Hellpistol, Laspistol, Laspistol, Autopistol, StubRevolver);
                NpcDataHolder.DataHolder.Melee = (WeaponMelee)GenerateWeapon(ChainSword, OfficerCutlass, OfficerCutlass, OfficerCutlass, Truncheon, Knife);
                NpcDataHolder.DataHolder.Grenade = (WeaponGrenade)GenerateWeapon(FragGrenade, FragGrenade, SmokeGrenade, null, null, null);
                NpcDataHolder.DataHolder.Armor = GenerateArmor(EnforcerLightCarapace, FlakCloak, FlakCloak, FlakCloak);
                break;
            case soldierTypes.Light:
                NpcDataHolder.DataHolder.BasicWeapon = (WeaponBasic)GenerateWeapon(Hellgun, Lasgun, Lasgun, PumpShotgun, Lasgun, Autogun);
                NpcDataHolder.DataHolder.Pistol = (WeaponPistol)GenerateWeapon(Hellpistol, Laspistol, Laspistol, Laspistol, Autopistol, StubRevolver);
                NpcDataHolder.DataHolder.Melee = (WeaponMelee)GenerateWeapon(OfficerCutlass, OfficerCutlass, OfficerCutlass, OfficerCutlass, Truncheon, Knife);
                NpcDataHolder.DataHolder.Grenade = (WeaponGrenade)GenerateWeapon(FragGrenade, SmokeGrenade, SmokeGrenade, null, null, null);
                NpcDataHolder.DataHolder.Armor = GenerateArmor(FlakCloak, XenoMesh, XenoMesh, ArmouredBodyglove);
                break;
            case soldierTypes.Heavy:
                NpcDataHolder.DataHolder.BasicWeapon = (WeaponBasic)GenerateWeapon(Boltgun, Hellgun, Lasgun, PumpShotgun, Lasgun, Autogun);
                NpcDataHolder.DataHolder.Pistol = (WeaponPistol)GenerateWeapon(BoltPistol, Hellpistol, Laspistol, Laspistol, Autopistol, StubRevolver);
                NpcDataHolder.DataHolder.Melee = (WeaponMelee)GenerateWeapon(ChainAxe, ChainSword, OfficerCutlass, OfficerCutlass, Truncheon, Knife);
                NpcDataHolder.DataHolder.Grenade = (WeaponGrenade)GenerateWeapon(KrakGrenade, FragGrenade, FragGrenade, SmokeGrenade, null, null);
                NpcDataHolder.DataHolder.Armor = GenerateArmor(CarapaceChestplate, EnforcerLightCarapace, GuardFlakArmor, FlakCloak);
                break;
            case soldierTypes.Super_Heavy:
                NpcDataHolder.DataHolder.BasicWeapon = (WeaponBasic)GenerateWeapon(PlasmaGun, Boltgun, Hellgun, Lasgun, PumpShotgun, Autogun);
                NpcDataHolder.DataHolder.Pistol = (WeaponPistol)GenerateWeapon(PlasmaPistol, BoltPistol, Hellpistol, Laspistol, Autopistol, StubRevolver);
                NpcDataHolder.DataHolder.Melee = (WeaponMelee)GenerateWeapon(ChainAxe, ChainSword, ChainSword, OfficerCutlass, Truncheon, Knife);
                NpcDataHolder.DataHolder.Grenade = (WeaponGrenade)GenerateWeapon(PlasmaGrenade, KrakGrenade, FragGrenade, FragGrenade, SmokeGrenade, SmokeGrenade);
                NpcDataHolder.DataHolder.Armor = GenerateArmor(StormTrooperCarapace, CarapaceChestplate, GuardFlakArmor, GuardFlakArmor);
                break;
        }
    }

    private Weapon GenerateWeapon(Weapon type1, Weapon type2, Weapon type3, Weapon type4, Weapon type5, Weapon type6)
    {
        Weapon generated;
        int rng = Random.Range(1, 101);
        if (rng < 6)
        {
            generated = type1;
        }
        else if (rng < 16)
        {
            generated = type2;
        }
        else if (rng < 31)
        {
            generated = type3;
        }
        else if (rng < 46)
        {
            generated = type4;
        }
        else if (rng < 61)
        {
            generated = type5;
        }
        else
        {
            generated = type6;
        }
        return generated;
    }

    private Armor GenerateArmor(Armor type1, Armor type2, Armor type3, Armor type4)
    {
        Armor generated;
        int rng = Random.Range(1, 101);
        if(rng < 11)
        {
            generated = type1;
        }
        else if(rng < 26)
        {
            generated = type2;
        }
        else if(rng < 51)
        {
            generated = type3;
        }
        else
        {
            generated = type4;
        }
        return generated;
    }

    public void GeneratePsychicPowers()
    {
        NpcDataHolder.DataHolder.PsychicPowers = new List<PsychicPower>();

        if (NpcDataHolder.DataHolder.role == roles.Sorcerer)
        {
            int powers;
            int rng = Random.Range(1, 101);
            if(rng < 51)
            {
                powers = 1;
            }
            else if (rng < 91)
            {
                powers = 2;
            }
            else
            {
                powers = 3;
            }

            for(int i = powers; i > 0; i--)
            {
                NpcDataHolder.DataHolder.PsychicPowers.Add(SelectPsychicPower());
            }
        }
    }

    private PsychicPower SelectPsychicPower()
    {
        int rng = Random.Range(0, Powers.Count);
        return Powers[rng];
    }
}
