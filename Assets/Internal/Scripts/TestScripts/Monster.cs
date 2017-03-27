using UnityEngine;
using System;

public class Monster : MonoBehaviour
{
    public string monsterName;

    public int iD;
    public int level;

    public Evolution evolution;

    [Serializable]
    public class Evolution
    {
        public int level;
        public Monster monster;
    }

    public Move[] moves;
}