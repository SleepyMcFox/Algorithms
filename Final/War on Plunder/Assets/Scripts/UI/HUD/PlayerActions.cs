using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SG.WOP.UI.HUD
{
    [CreateAssetMenu(fileName = "NewPlayerActions", menuName = "Player Actions")]
    public class PlayerActions : ScriptableObject
    {
        [Header("Units")]
        [Space(5)]
        public List<Units.BasicUnit> basicUnits = new List<Units.BasicUnit>();

        [Space(15)]
        [Header("Buildings")]
        [Space(5)]
        public List<Buildings.BasicBuilding> basicBuildings = new List<Buildings.BasicBuilding>();


    }
}

