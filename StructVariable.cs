using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public struct StructVariable
{
    bool isHillDwarf;
    bool rolledHP;
    bool hasTough;
    public string charClass;
    public int level;
    public int con;
    public string name;
    public int hp;
    //Dicitionary of classes and their hit di
    private static readonly Dictionary<string, double> hitDie = new Dictionary<string, double>()
    {
        { "Artificer", 8f },{ "Barbarian", 12f },{ "Bard", 8f },{ "Cleric", 8f },{ "Druid", 8f },
        { "Fighter", 10f },{ "Monk", 8f },{ "Ranger", 10f },{ "Rogue", 8f },{ "Paladin", 10f },
        { "Sorcerer", 6f },{ "Wizard", 6f },{ "Warlock", 8f }

    };
    //List of classes
    private static List<string> classNames = new List<string>()
    {
        "Artificer", "Barbarian", "Bard", "Cleric", "Druid", "Fighter", "Monk", 
        "Ranger", "Rogue", "Paladin", "Sorcerer", "Wizard", "Warlock"
    };
    //Array of Con Mods
    private static double[] ConMod = { -5, -4, -4, -3, -3, -2, -2, -1, -1, 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8, 9, 9, 10 };
}
