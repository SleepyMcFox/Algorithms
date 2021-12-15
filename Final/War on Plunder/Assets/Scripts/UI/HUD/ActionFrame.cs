using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SG.WOP.UI.HUD
{
    public class ActionFrame : MonoBehaviour
    {
        // singleton
        public static ActionFrame instance = null;

        [SerializeField]
        private Button actionButton = null;

        [SerializeField]
        private Transform layoutGroup = null;

        private List<Button> buttons = new List<Button>();
        private PlayerActions actionsList = null;

        public List<float> spawnQueue = new List<float>();
        public List<GameObject> spawnOrder = new List<GameObject>();
        public GameObject spawnPoint = null;


        private void Awake()
        {
            instance = this;
        }

        public void SetActionButton(PlayerActions actions, GameObject spawnLocation)
        {
            actionsList = actions;
            spawnPoint = spawnLocation;
            // If there are basic units inside of the list
            if(actions.basicUnits.Count > 0)
            {
                foreach(Units.BasicUnit unit in actions.basicUnits)
                {
                    Button btn = Instantiate(actionButton, layoutGroup);
                    btn.name = unit.name;
                    GameObject icon = Instantiate(unit.icon, btn.transform);
                    // Add highlight text possibly in the future with information
                    // pertaining to the unit cost and production time
                    buttons.Add(btn);
                }
            }
            if(actions.basicBuildings.Count > 0)
            {
                foreach (Buildings.BasicBuilding building in actions.basicBuildings)
                {
                    Button btn = Instantiate(actionButton, layoutGroup);
                    btn.name = building.name;
                    GameObject icon = Instantiate(building.icon, btn.transform);
                    //add text possibly in the future
                    buttons.Add(btn);
                }
            }
        }

        public void ClearActions()
        {
            foreach(Button btn in buttons)
            {
                Destroy(btn.gameObject);
            }
            buttons.Clear();
        }

        public void StartSpawnTimer(string objectToSpawn)
        {
            
            if(IsUnit(objectToSpawn))
            {
                // Create unit
                Units.BasicUnit unit = IsUnit(objectToSpawn);
                spawnQueue.Add(unit.spawnTime);
                spawnOrder.Add(unit.playerPrefab);
            }
            else if(IsBuilding(objectToSpawn))
            {
                // Create building
                Buildings.BasicBuilding building = IsBuilding(objectToSpawn);
                spawnQueue.Add(building.spawnTime);
                spawnOrder.Add(building.playerBuildingPrefab);
            }
            else
            {
                Debug.Log($"{objectToSpawn} is not a spawnable object");
            }

            // Set to only call the coroutine only when it is necessary
            if(spawnQueue.Count == 1)
            {
                ActionTimer.instance.StartCoroutine(ActionTimer.instance.SpawnQueueTimer());
            }
            else if(spawnQueue.Count == 0)
            {
                ActionTimer.instance.StopAllCoroutines();
            }
        }

        private Units.BasicUnit IsUnit(string name)
        {
            if(actionsList.basicUnits.Count > 0)
            {
                foreach(Units.BasicUnit unit in actionsList.basicUnits)
                {
                    if(unit.name == name)
                    {
                        return unit;
                    }
                }
            }
            return null;
        }

        private Buildings.BasicBuilding IsBuilding(string name)
        {
            if (actionsList.basicBuildings.Count > 0)
            {
                foreach(Buildings.BasicBuilding building in actionsList.basicBuildings)
                {
                    if (building.name == name)
                    {
                        return building;
                    }
                }
            }
            return null;
        }

        public void SpawnObject()
        {
            GameObject spawnedObject = Instantiate(spawnOrder[0], new Vector3(spawnPoint.transform.parent.position.x,
                                                                              spawnPoint.transform.parent.position.y,
                                                                              spawnPoint.transform.parent.position.z),
                                                                              Quaternion.identity); //Technical Debt

            Units.Player.PlayerUnit pU = spawnedObject.GetComponent<Units.Player.PlayerUnit>();
            pU.transform.SetParent(GameObject.Find(pU.unitType.type.ToString().Substring(0, pU.unitType.type.ToString().Length - 3) + "men").transform);

            spawnedObject.GetComponent<Units.Player.PlayerUnit>().MoveUnit(spawnPoint.transform.position);
            spawnQueue.Remove(spawnQueue[0]);
            spawnOrder.Remove(spawnOrder[0]);

        }
    }
}

