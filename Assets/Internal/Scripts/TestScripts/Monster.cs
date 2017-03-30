using UnityEngine;
using System;

public class Monster : MonoBehaviour
{
    public MonstersRepo monstersRepo;

    public string monsterName;
    public int index;
    public ElementalType firstType;
    public ElementalType secondType;
    public string description;

    //my own
    public string playerId;
    public int id;
    public int currentHP;
    public int currentMana;

    //from scriptable/save
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

    //VISUAL
    public GameObject myModel;
    public Sprite myPreviewSprite;

}