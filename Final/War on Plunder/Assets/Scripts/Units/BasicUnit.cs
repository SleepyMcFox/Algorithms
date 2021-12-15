using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Way to organize code
namespace SG.WOP.Units 
{
    //Modifying the editor for a simpler way of creating new units
    [CreateAssetMenu(fileName = "New Unit", menuName = "New Unit/Basic")]
    //This is the Unit template, used for all of the units
    public class BasicUnit : ScriptableObject
    {
        public enum unitType
        {
            Swordsman,
            Spearman,
            Axeman
        };

        [Header("Unit Settings")]
        [Space(15)]

        public unitType type;
        public string unitName;
        public GameObject playerPrefab;
        public GameObject enemyPrefab;
        public GameObject icon;
        public float spawnTime;

        [Space(40)]
        [Header("Unit Statistics")]
        [Space(15)]

        public UnitStatTypes.Base baseStats;
    }
}

