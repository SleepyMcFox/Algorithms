using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using SG.WOP.InputManager;

namespace SG.WOP.Player
{
    public class PlayerManager : MonoBehaviour
    {
        // Singleton
        public static PlayerManager instance;

        public Transform playerUnits;
        public Transform enemyUnits;

        public Transform playerBuildings;
        public Transform enemyBuildings;


        private void Awake()
        {
            instance = this;
            SetBasicStats(playerUnits);
            SetBasicStats(enemyUnits);
            SetBasicStats(playerBuildings);
            SetBasicStats(enemyBuildings);
        }

        private void Update()
        {
            InputHandler.instance.HandleUnitMovement();
        }

        /// <summary>
        /// Sets the statistics of the unit
        /// </summary>
        /// <param name="type"></param>
        public void SetBasicStats(Transform type)
        {
            foreach (Transform child in type)
            {
                foreach (Transform tf in child)
                {
                    // Changes the name from xmen to xman
                    string name = child.name.Substring(0, child.name.Length - 3).ToLower() + "man";
                    //var stats = Units.UnitHandler.instance.GetBasicUnitStats(unitName);

                    if (type == playerUnits)
                    {
                        // Set Unit Statistics for each unit
                        Units.Player.PlayerUnit pU = tf.GetComponent<Units.Player.PlayerUnit>();

                        pU.baseStats = Units.UnitHandler.instance.GetBasicUnitStats(name);

                        // if there are any upgrades, add them now
                        // add upgrades to unit stats
                    }
                    else if (type == enemyUnits)
                    {
                        // set enemy stats
                        Units.Enemy.EnemyUnit eU = tf.GetComponent<Units.Enemy.EnemyUnit>();

                        eU.baseStats = Units.UnitHandler.instance.GetBasicUnitStats(name);
                    }
                    else if (type == playerBuildings)
                    {
                        Buildings.Player.PlayerBuilding pB = tf.GetComponent<Buildings.Player.PlayerBuilding>();
                        pB.baseStats = Buildings.BuildingHandler.instance.GetBasicBuildingStats(name);
                    }
                    else if(type == enemyBuildings)
                    {
                        Buildings.Enemy.EnemyBuilding eB = tf.GetComponent<Buildings.Enemy.EnemyBuilding>();
                        eB.baseStats = Buildings.BuildingHandler.instance.GetBasicBuildingStats(name);
                    }
                }
            }
        }
    }
}


