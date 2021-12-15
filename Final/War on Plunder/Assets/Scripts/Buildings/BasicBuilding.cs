using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SG.WOP.Buildings
{
    [CreateAssetMenu(fileName = "Building", menuName = "New Building/Basic")]
    public class BasicBuilding : ScriptableObject
    {
        // Can add more building types in the future such as production, 
        // income, towers, upgrades, etc...
        public enum buildingType
        {
            Fortress //Main base
        }

        [Header("Building Settings")]
        [Space(15)]

        // Settings for any type of building
        public buildingType type;
        public new string name;
        public GameObject playerBuildingPrefab;
        public GameObject enemyBuildingPrefab;
        public GameObject icon;
        public float spawnTime;

        [Space(40)]
        [Header("Building Stats")]
        [Space(15)]

        // The statistics for the building
        public BuildingStatTypes.Base baseStats;

    }
}

