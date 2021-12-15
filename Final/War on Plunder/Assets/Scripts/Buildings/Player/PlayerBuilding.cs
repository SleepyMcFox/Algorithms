using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SG.WOP.Buildings.Player
{
    public class PlayerBuilding : MonoBehaviour
    {
        public BasicBuilding buildingType;


        [HideInInspector]
        public BuildingStatTypes.Base baseStats;

        public Units.UnitStatDisplay statDisplay;

        private void Start()
        {
            baseStats = buildingType.baseStats;
            //statDisplay.SetStatDisplayBasicBuilding(baseStats, false);
        }
    }
}


