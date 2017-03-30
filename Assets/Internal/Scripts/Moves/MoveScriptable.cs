using UnityEngine;
using System;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Move", menuName = "Monster or Move/Move", order = 1)]
[System.Serializable]
public class MoveScriptable : ScriptableObject
{
    #region Common to all moves
    public string moveName = "name";
    public int iD;
    public string description = "descr"; 
    public ElementalType type;
    public int manaCost;
    public GestureType gesture;
    [Range(0, 100)]
    public int gestureProbability;
    public int speed;
    [Range(0, 100)]
    public int precision;
    public bool contact;
    #endregion

    [Serializable]
    public class AttackStruct
    {
        public Physical physical;
        public Elemental elemental;
        public Buff buff;
        public Debuff debuff;
        public Status status;
        public Drain drain;
        public Heal heal;
    }

    public AttackStruct effects = new AttackStruct();

}

#region Attacks

[Serializable]
public class Physical
{
    public bool active;
    public int damage;
    [Range(0, 100)]
    public int critRate;
    public int knockback;
}

[Serializable]
public class Elemental
{
    public bool active;
    public int damage;
    [Range(0, 100)]
    public int critRate;
}

[Serializable]
public class Buff
{
    public bool active;
    public int rate;
    public Stat[] influencedStats;
    public int buffLevel;
}

[Serializable]
public class Debuff
{
    public bool active;
    [Range(0, 100)]
    public int rate;
    public Stat[] influencedStats;
    public int debuffLevel;
}

[Serializable]
public class Status
{
    public bool active;
    public StatusAlterations alteration;
    [Range(0, 100)]
    public int damageRate;
    public int[] turns;
}

[Serializable]
public class Drain
{
    public bool active;
    [Range(0, 100)]
    public int amountDrained;
    [Range(0, 100)]
    public int amountGained;
}

[Serializable]
public class Heal
{
    public bool active;
    [Range(0, 100)]
    public int amountHealed;
}
#endregion

#region Enums
public enum GestureType
{
    buff,
    debuff,
    crosshair,
    slash
}

public enum Stat
{
    physicalAttack,
    elementalAttack,
    physicalDefense,
    elementalDefense
}

public enum StatusAlterations
{
    poisoned,
    burnt
}
#endregion