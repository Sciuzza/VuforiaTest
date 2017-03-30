using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Monster", menuName = "Monster or Move/Monster", order = 2)]
[System.Serializable]
public class MonsterScriptable : ScriptableObject
{

    public string monsterName;
    public int index;
    public ElementalType firstType;
    public ElementalType secondType;
    public string description;

    #region Stats
    public int physAttack;
    public int physDefense;
    public int elementalAttack;
    public int elementalDefense;
    public int baseSpeed;
    public int accuracy;
    public int elusivity;
    public int baseMana;
    public int manaPerTurn;
    public int totalHP;
    #endregion

    public GameObject myModel;
    public Sprite myPreviewSprite; 

    //MOVES
    public MoveScriptable[] allLearnableMoves;

    //EVOLUTION
    [System.Serializable]
    public class Evolution
    {
        public int atLevel;
        public MonsterScriptable monster;
    }

    public Evolution evolution;
}

public enum ElementalType : short { normal, fire, water, electro, fairy, grass, fight }
