using UnityEngine;
using System;

public class Move : MonoBehaviour
{
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