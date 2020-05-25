using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NpcGenerator : MonoBehaviour
{
    [Header ("Generator Settings")]
    public Dropdown RaceSelect;
    public Dropdown RoleSelect;
    public InputField BaseStatModifierInput;
    public Dropdown SoldierSelect;

    [Header("Characteristics Elements")]
    public TextMeshProUGUI WS;
    public TextMeshProUGUI BS;
    public TextMeshProUGUI S;
    public TextMeshProUGUI T;
    public TextMeshProUGUI Ag;
    public TextMeshProUGUI Int;
    public TextMeshProUGUI Per;
    public TextMeshProUGUI WP;
    public TextMeshProUGUI Fel;
    public TextMeshProUGUI Wounds;

    [Header("Basic Weapon Elements")]
    public TextMeshProUGUI BasicName;
    public TextMeshProUGUI BasicDamage;
    public TextMeshProUGUI BasicType;
    public TextMeshProUGUI BasicPen;
    public TextMeshProUGUI BasicRange;
    public TextMeshProUGUI BasicSpecial;

    [Header("Pistol Weapon Elements")]
    public TextMeshProUGUI PistolName;
    public TextMeshProUGUI PistolDamage;
    public TextMeshProUGUI PistolType;
    public TextMeshProUGUI PistolPen;
    public TextMeshProUGUI PistolRange;
    public TextMeshProUGUI PistolSpecial;

    [Header("Melee Weapon Elements")]
    public TextMeshProUGUI MeleeName;
    public TextMeshProUGUI MeleeDamage;
    public TextMeshProUGUI MeleeType;
    public TextMeshProUGUI MeleePen;
    public TextMeshProUGUI MeleeRange;
    public TextMeshProUGUI MeleeSpecial;

    [Header("Grenade Weapon Elements")]
    public TextMeshProUGUI GrenadeName;
    public TextMeshProUGUI GrenadeDamage;
    public TextMeshProUGUI GrenadeType;
    public TextMeshProUGUI GrenadePen;
    public TextMeshProUGUI GrenadeRange;
    public TextMeshProUGUI GrenadeSpecial;

    [Header("Armor Elements")]
    public TextMeshProUGUI ArmorName;
    public TextMeshProUGUI ArmorValue;
    public TextMeshProUGUI ArmorLocations;

    [Header("Psychic Elements")]
    public TextMeshProUGUI PowerOneName;
    public TextMeshProUGUI PowerOneDescription;
    public TextMeshProUGUI PowerOneReference;
    public TextMeshProUGUI PowerTwoName;
    public TextMeshProUGUI PowerTwoDescription;
    public TextMeshProUGUI PowerTwoReference;
    public TextMeshProUGUI PowerThreeName;
    public TextMeshProUGUI PowerThreeDescription;
    public TextMeshProUGUI PowerThreeReference;

    public void GenerateCharacter()
    {
        NpcDataHolder.DataHolder.race = (races)((int)RaceSelect.value);
        NpcDataHolder.DataHolder.role = (roles)((int)RoleSelect.value);
        NpcDataHolder.DataHolder.baseStatModifier = BaseStatModifierInput != null ? 0 : int.Parse(BaseStatModifierInput.text);
        NpcDataHolder.DataHolder.soldierType = (soldierTypes)((int)SoldierSelect.value);

        NpcDataHolder.DataHolder.GenerateCharacteristics();
        NpcDataHolder.DataHolder.GenerateGear();
        RoleAdjustments.RoleAdjust.GeneratePsychicPowers();

        RefreshLayout();
    }

    private void RefreshLayout()
    {
        WS.text = NpcDataHolder.DataHolder.WS.ToString();
        BS.text = NpcDataHolder.DataHolder.BS.ToString();
        S.text = NpcDataHolder.DataHolder.S.ToString();
        T.text = NpcDataHolder.DataHolder.T.ToString();
        Ag.text = NpcDataHolder.DataHolder.Ag.ToString();
        Int.text = NpcDataHolder.DataHolder.Int.ToString();
        Per.text = NpcDataHolder.DataHolder.Per.ToString();
        WP.text = NpcDataHolder.DataHolder.WP.ToString();
        Fel.text = NpcDataHolder.DataHolder.Fel.ToString();

        if(NpcDataHolder.DataHolder.BasicWeapon != null)
        {
            BasicName.text = NpcDataHolder.DataHolder.BasicWeapon.Name;
            BasicDamage.text = NpcDataHolder.DataHolder.BasicWeapon.Damage;
            BasicType.text = NpcDataHolder.DataHolder.BasicWeapon.Type;
            BasicPen.text = NpcDataHolder.DataHolder.BasicWeapon.Pen;
            BasicRange.text = NpcDataHolder.DataHolder.BasicWeapon.Range;
            BasicSpecial.text = NpcDataHolder.DataHolder.BasicWeapon.Special;
        }
        else
        {
            BasicName.text = "";
            BasicDamage.text = "";
            BasicType.text = "";
            BasicPen.text = "";
            BasicRange.text = "";
            BasicSpecial.text = "";
        }        

        if(NpcDataHolder.DataHolder.Pistol != null)
        {
            PistolName.text = NpcDataHolder.DataHolder.Pistol.Name;
            PistolDamage.text = NpcDataHolder.DataHolder.Pistol.Damage;
            PistolType.text = NpcDataHolder.DataHolder.Pistol.Type;
            PistolPen.text = NpcDataHolder.DataHolder.Pistol.Pen;
            PistolRange.text = NpcDataHolder.DataHolder.Pistol.Range;
            PistolSpecial.text = NpcDataHolder.DataHolder.Pistol.Special;
        }
        else
        {
            PistolName.text = "";
            PistolDamage.text = "";
            PistolType.text = "";
            PistolPen.text = "";
            PistolRange.text = "";
            PistolSpecial.text = "";
        }        

        if(NpcDataHolder.DataHolder.Melee != null)
        {
            MeleeName.text = NpcDataHolder.DataHolder.Melee.Name;
            MeleeDamage.text = NpcDataHolder.DataHolder.Melee.Damage;
            MeleeType.text = NpcDataHolder.DataHolder.Melee.Type;
            MeleePen.text = NpcDataHolder.DataHolder.Melee.Pen;
            MeleeRange.text = NpcDataHolder.DataHolder.Melee.Range;
            MeleeSpecial.text = NpcDataHolder.DataHolder.Melee.Special;
        }
        else
        {
            MeleeName.text = "";
            MeleeDamage.text = "";
            MeleeType.text = "";
            MeleePen.text = "";
            MeleeRange.text = "";
            MeleeSpecial.text = "";
        }

        if(NpcDataHolder.DataHolder.Grenade != null)
        {
            GrenadeName.text = NpcDataHolder.DataHolder.Grenade.Name;
            GrenadeDamage.text = NpcDataHolder.DataHolder.Grenade.Damage;
            GrenadeType.text = NpcDataHolder.DataHolder.Grenade.Type;
            GrenadePen.text = NpcDataHolder.DataHolder.Grenade.Pen;
            GrenadeRange.text = (Mathf.Floor(NpcDataHolder.DataHolder.S / 10) * 3).ToString() + "m";
            GrenadeSpecial.text = NpcDataHolder.DataHolder.Grenade.Special;
        }
        else
        {
            GrenadeName.text = "";
            GrenadeDamage.text = "";
            GrenadeType.text = "";
            GrenadePen.text = "";
            GrenadeRange.text = "";
            GrenadeSpecial.text = "";
        }
        
        if(NpcDataHolder.DataHolder.Armor != null)
        {
            ArmorName.text = NpcDataHolder.DataHolder.Armor.Name;
            ArmorValue.text = NpcDataHolder.DataHolder.Armor.Value;
            ArmorLocations.text = NpcDataHolder.DataHolder.Armor.Locations;
        }
        else
        {
            ArmorName.text = "None";
            ArmorValue.text = "";
            ArmorLocations.text = "";
        }

        Wounds.text = NpcDataHolder.DataHolder.Wounds.ToString();

        
        PowerOneName.text = "N/A";
        PowerOneDescription.text = "";
        PowerOneReference.text = "";
        PowerTwoName.text = "N/A";
        PowerTwoDescription.text = "";
        PowerTwoReference.text = "";
        PowerThreeName.text = "N/A";
        PowerThreeDescription.text = "";
        PowerThreeReference.text = "";

        if (NpcDataHolder.DataHolder.role == roles.Sorcerer)
        {
            if(NpcDataHolder.DataHolder.PsychicPowers.Count >= 1)
            {
                PowerOneName.text = NpcDataHolder.DataHolder.PsychicPowers[0].Name;
                PowerOneDescription.text = NpcDataHolder.DataHolder.PsychicPowers[0].Description;
                PowerOneReference.text = NpcDataHolder.DataHolder.PsychicPowers[0].Reference;
            }
            if(NpcDataHolder.DataHolder.PsychicPowers.Count >= 2)
            {
                PowerTwoName.text = NpcDataHolder.DataHolder.PsychicPowers[1].Name;
                PowerTwoDescription.text = NpcDataHolder.DataHolder.PsychicPowers[1].Description;
                PowerTwoReference.text = NpcDataHolder.DataHolder.PsychicPowers[1].Reference;
            }
            if(NpcDataHolder.DataHolder.PsychicPowers.Count == 3)
            {
                PowerThreeName.text = NpcDataHolder.DataHolder.PsychicPowers[2].Name;
                PowerThreeDescription.text = NpcDataHolder.DataHolder.PsychicPowers[2].Description;
                PowerThreeReference.text = NpcDataHolder.DataHolder.PsychicPowers[2].Reference;
            }
        }
    }
}
