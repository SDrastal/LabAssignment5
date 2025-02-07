using UnityEngine;
using System.Collections.Generic;

public class SolutionTwo : MonoBehaviour
{
    public bool Tough;
    public bool HillDwarf;
    public bool RolledHP;
    public string charClass;
    public int inLevel;
    public int CON;
    public string name;

    private int hp;
    private StructVariable myChar;

    // Start is called before the first frame update
    void Start()
    {
        myChar = new StructVariable(HillDwarf, RolledHP, Tough, charClass, inLevel, CON, name);
        
        if (!StructVariable.classes.Contains(myChar.className) || myChar.level < 1 || myChar.level > 20 || myChar.con < 1 || myChar.con > 30 || myChar.charName == "")
        {
            Debug.Log("Invalid input");
            return;
        }
        
        myChar.SetHP((int)CalcHP());
        Debug.Log(DisplayMessage());
    }

    public float CalcHP()
    {
        float maxHP = 0;

        maxHP = StructVariable.hitDie[myChar.className];
        maxHP += StructVariable.ConMod[myChar.con - 1];

        if (myChar.level > 1)
        {
            for (int i = 0; i < myChar.level; i++)
            {
                if (myChar.isRolledHP) maxHP += Random.Range(1, (int)StructVariable.hitDie[myChar.className] + 1);
                else maxHP += ((StructVariable.hitDie[myChar.className] + 1f) / 2f) + 0.5f;    
            }
        }

        if (myChar.hasTough)
            maxHP += 2 * myChar.level;
        if (myChar.isHillDwarf)
            maxHP += myChar.level;

        return maxHP;
    }

    public string DisplayMessage()
    {
        return $"My character {myChar.charName} is a level {myChar.level} {myChar.className} with a CON score of {myChar.con} and {(myChar.isHillDwarf ? "is" : "is not")} a Hill Dwarf and {(myChar.hasTough ? "has" : "does not have")} the Tough feat. I want the HP {(myChar.isRolledHP ? "rolled" : "averaged")}. HP: {myChar.hp}";
    }
}

[System.Serializable]
public struct StructVariable
{
    public bool hasTough;
    public bool isHillDwarf;
    public bool isRolledHP;
    public string className;
    public int level;
    public int con;
    public string charName;

    public int hp;
    //Dictionary of classes and their hit die
    public static readonly Dictionary<string, float> hitDie = new Dictionary<string, float>()
    {
        { "Artificer", 8f },{ "Barbarian", 12f },{ "Bard", 8f },{ "Cleric", 8f },{ "Druid", 8f },
        { "Fighter", 10f },{ "Monk", 8f },{ "Ranger", 10f },{ "Rogue", 8f },{ "Paladin", 10f },
        { "Sorcerer", 6f },{ "Wizard", 6f },{ "Warlock", 8f }

    };
    //List of classes
    public static List<string> classes = new List<string>()
    {
        "Artificer", "Barbarian", "Bard", "Cleric", "Druid", "Fighter", "Monk", 
        "Ranger", "Rogue", "Paladin", "Sorcerer", "Wizard", "Warlock"
    };
    //Array of Con Mods
    public static float[] ConMod = { -5, -4, -4, -3, -3, -2, -2, -1, -1, 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8, 9, 9, 10 };

    public StructVariable(bool isHillDwarf, bool rolledHP, bool hasTough, string charClass, int level, int con, string name)
    {
        this.isHillDwarf = isHillDwarf;
        this.isRolledHP = rolledHP;
        this.hasTough = hasTough;
        this.className = charClass;
        this.level = level;
        this.con = con;
        this.charName = name;
        this.hp = 0;
    }

    public void SetHP(int hp)
    {
        this.hp = hp;
    }
}
