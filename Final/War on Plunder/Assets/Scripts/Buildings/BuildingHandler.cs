using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SG.WOP.Buildings
{
    public class BuildingHandler : MonoBehaviour
    {
        //singleton
        public static BuildingHandler instance;

        [SerializeField]
        private BasicBuilding fortress;

        private void Awake()
        {
            instance = this;
        }

        /// <summary>
        /// Returns the Building Statistics
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public BuildingStatTypes.Base GetBasicBuildingStats(string type)
        {
            BasicBuilding building;
            switch (type)
            {
                case "fortrman":
                    building = fortress;
                    break;
                default:
                    Debug.Log($"Building Type: {type} could not be found or does not exist");
                    return null;
            }
            return building.baseStats;
        }
    }
}
