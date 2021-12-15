using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using SG.WOP.Player;

namespace SG.WOP.Units
{
    public class UnitHandler : MonoBehaviour
    {
        //singleton
        public static UnitHandler instance;

        [SerializeField]
        private BasicUnit swordsman, spearman, axeman;

        public LayerMask pUnitLayer, eUnitLayer, eBuildingLayer;

        private void Awake()
        {
            instance = this;
        }


        /// <summary>
        /// Returns the Unit Statistics
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public UnitStatTypes.Base GetBasicUnitStats(string type)
        {
            BasicUnit unit;
            switch (type)
            {
                case "swordsman":
                    unit = swordsman;
                    break;
                case "spearman":
                    unit = spearman;
                    break;
                case "axeman":
                    unit = axeman;
                    break;
                default:
                    Debug.Log($"Unit Type: {type} could not be found or does not exist");
                    return null;
            }
            return unit.baseStats;
        }

        
    }
}

