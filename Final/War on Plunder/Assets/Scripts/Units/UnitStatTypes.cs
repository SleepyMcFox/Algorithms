using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SG.WOP.Units
{
    public class UnitStatTypes : ScriptableObject
    {
        [System.Serializable]
        //Stores the base statistics of the units
        public class Base
        {
            public float cost, aggroRange, atkRange, atkSpeed, attack, health, defense;
        }

        // Upgrades
        // Similar to Starcraft , having +1, +2 and +3 upgrades for the units for both attack
        // and defense


        // New Abilities
        // Maybe have the Bandit Axeman upgrade to have a throwing ability and have their
        // range increased
    }
}
