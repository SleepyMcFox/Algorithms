using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SG.WOP.Buildings
{
    public class BuildingStatTypes : ScriptableObject
    {
        [System.Serializable]
        public class Base
        {
            public float health, defense, attack;    
        }
    }

}

