using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Monster", menuName = "Monster or Move/Monster", order = 2)]
[System.Serializable]
public class MonsterScriptable : ScriptableObject
{

    public int iD;
    public string monsterName;

    //STATS
    public int index;
    public ElementalType firstType;
    public ElementalType secondType;
    public float physAttack;
    public float physDefense;
    public float elementalAttack;
    public float elementalDefense;
    public float baseSpeed;
    public float accuracy;
    public float elusivity;
    public int baseMana;
    public int manaPerTurn;
    public float totalHP;

    public string description;

    //VISUAL
    public GameObject myModel;
    public Sprite myPreviewSprite;

    //MOVES
    public Move[] allLearnableMoves;

    //EVOLUTION
    [System.Serializable]
    public class Evolution
    {
        public int atLevel;
        public Monster monster;
    }

    public Evolution evolution;
}

public enum ElementalType : short { normal, fire, water, electro, fairy, grass, fight }
public enum SkillState : short { notLearnt, learnt, selectedForCombat }
