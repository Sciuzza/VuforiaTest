using UnityEngine;
using System;

[CreateAssetMenu(fileName = "Move", menuName = "Monster or Move/Move", order = 1)]
[System.Serializable]
public class MoveScriptable : ScriptableObject
{
    public string moveName;
    public int iD;
    public ElementalType type;
    public int manaCost;
    public GestureType gesture;
    public float speed;

    [Range(0.0f, 100.0f)]
    public float precision;
    public float power;
    public bool isMelee;

    public AttackStruct[] effects;

    [Serializable]
    public class AttackStruct
    {
        [HideInInspector]
        public string effectName;
        public Attack type;

        public enum Attack
        {
            Physic, Special, Debuff
        }

        public ChooseDamage damage;

        public enum ChooseDamage
        {
            Yes, No
        }

        public float valueDamage;
    }

    private void OnValidate()
    {
        if (Application.isPlaying)
        {
            return;
        }
        CheckEnumerator();
    }

    private void CheckEnumerator()
    {
        for (int i = 0; i < effects.Length; i++)
        {
            effects[i].effectName = "Effect (" + i + ")";

            if (effects[i].damage == AttackStruct.ChooseDamage.No)
            {
                effects[i].valueDamage = 0;
            }
        }
    }

}

public enum GestureType
{
    buff,
    debuff,
    crosshair,
    slash
}