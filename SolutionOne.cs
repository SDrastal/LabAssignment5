using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SolutionOne : MonoBehaviour
{
    public bool hasTough;
    public bool isHillDwarf;
    public bool isRolledHP;
    public string className;
    public int level;
    public int con;
    public string charName;

    private Dictionary<string, float> hitDie = new Dictionary<string, float>
    {
        {"Artificer", 8f},
        {"Barbarian", 12f},
        {"Bard", 8f},
        {"Cleric", 8f},
        {"Druid", 8f},
        {"Fighter", 10f},
        {"Monk", 8f},
        {"Ranger", 10f},
        {"Rogue", 8f},
        {"Paladin", 10f},
        {"Sorcerer", 6f},
        {"Wizard", 6f},
        {"Warlock", 8f}
    };
    private int[] conMod = new int[]
    {
        -5, -4, -4, -3, -3, -2, -2, -1, -1, 0, 0,
        1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7,
        8, 8, 9, 9, 10, 10
    };
    private int hp;

    // Start is called before the first frame update
    void Start()
    {
        hp = (int)CalcHP();
        //Debug.Log(DisplayMessage());
    }

    public float CalcHP()
    {
        float maxHP = 0;

        maxHP = hitDie[className];
        maxHP += conMod[con - 1];

        if (level > 1)
        {
            for (int i = 0; i < level; i++)
            {
                if (isRolledHP) maxHP += Random.Range(1, (int)hitDie[className] + 1);
                else maxHP += ((hitDie[className] + 1f) / 2f) + 0.5f);    
            }
        }

        if (hasTough)
            maxHP += 2 * level;
        if (isHillDwarf)
            maxHP += level;

        return maxHP;
    }

    public string DisplayMessage()
    {
    
    }
}
