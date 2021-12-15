using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using SG.WOP.Units.Player;
using UnityEngine.EventSystems;

namespace SG.WOP.InputManager
{
    public class InputHandler : MonoBehaviour
    {
        //singleton
        public static InputHandler instance;

        //what is hit with the ray
        private RaycastHit hit;

        public List<Transform> selectedUnits = new List<Transform>();
        public Transform selectedBuilding = null;

        public LayerMask interactableLayer = new LayerMask();

        private bool isDragging = false;

        private Vector3 mousePos;


        private void Awake()
        {
            instance = this;
        }

        /// <summary>
        /// What draws the box for drag select
        /// </summary>
        private void OnGUI()
        {
            if(isDragging)
            {
                Rect rect = MultiSelect.GetScreenRect(mousePos, Input.mousePosition);
                MultiSelect.DrawScreenRect(rect, new Color(0f, 255f, 0f, 0.25f));
                MultiSelect.DrawScreenRectBorder(rect, 3, Color.green);
            }
        }

        /// <summary>
        /// Unit Selection code
        /// </summary>
        public void HandleUnitMovement()
        {
            // Single-click unit selection
            if(Input.GetMouseButtonDown(0))
            {
                if (EventSystem.current.IsPointerOverGameObject())
                {
                    return;
                }

                mousePos = Input.mousePosition;
                // create a ray
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                // check if the ray hits something
                if(Physics.Raycast(ray,out hit, 100, interactableLayer))
                {
                    if(AddedUnit(hit.transform, Input.GetKey(KeyCode.LeftShift)))
                    {
                        // be able to do stuff with units
                    }
                    else if(AddedBuilding(hit.transform))
                    {
                        // be able to do stuff with buildings
                    }
                }
                else 
                {
                    isDragging = true;
                    DeselectUnits();
                }
            }

            if(Input.GetMouseButtonUp(0))
            {
                //Checking for the children that are inside playerUnits
                foreach(Transform child in Player.PlayerManager.instance.playerUnits)
                {
                    //checking for all the children in the child transform
                    foreach(Transform unit in child)
                    {
                        if(IsWithinSelectionBounds(unit))
                        {
                            AddedUnit(unit, true);
                        }
                    }
                }
                isDragging = false;
            }

            if(Input.GetMouseButtonDown(1) && HaveSelectedUnits())
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                // check if the ray hits something
                if (Physics.Raycast(ray, out hit))
                {
                    // if the ray its, do something with the data
                    // Gives us the layer of whatever gameObject that it hits
                    LayerMask layerHit = hit.transform.gameObject.layer;

                    switch (layerHit.value)
                    {
                        case 8: // PlayerUnits Layer
                            // Do something
                            break;
                        case 9: // EnemyUnit Layer
                            // Attack them or set them as a target
                            break;
                        default: // If none of the above happens
                            // Do something
                            // Since the unit hasn't been clicked on, if the mouse is still being
                            // held dragging will be true
                            foreach(Transform unit in selectedUnits)
                            {
                                PlayerUnit pU = unit.gameObject.GetComponent<PlayerUnit>();
                                pU.MoveUnit(hit.point);
                            }
                            break;
                    }

                }
            }
            else if(Input.GetMouseButtonDown(1) && selectedBuilding != null)
            {
                selectedBuilding.gameObject.GetComponent<Ineractables.IBuilding>().SetSpawnMarkerLocation();
            }
        }

        private void DeselectUnits()
        {
            if(selectedBuilding)
            {
                selectedBuilding.gameObject.GetComponent<Ineractables.IBuilding>().OnInteractExit();
                selectedBuilding = null;
            }
            for (int i = 0; i < selectedUnits.Count; i++)
            {
                selectedUnits[i].gameObject.GetComponent<Ineractables.IUnit>().OnInteractExit();
            }
            selectedUnits.Clear();
        }

        private bool IsWithinSelectionBounds(Transform tf)
        {
            if(!isDragging)
            {
                return false;
            }

            Camera cam = Camera.main;

            Bounds vpBounds = MultiSelect.GetVPBounds(cam, mousePos, Input.mousePosition);
            return vpBounds.Contains(cam.WorldToViewportPoint(tf.position));
        }

        private bool HaveSelectedUnits()
        {
            if(selectedUnits.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private Ineractables.IUnit AddedUnit(Transform tf, bool canMultiSelect = false)
        {
            Ineractables.IUnit iUnit = tf.GetComponent<Ineractables.IUnit>();
            // If the variable is not equal to null
            if(iUnit)
            {
                if(!canMultiSelect)
                {
                    DeselectUnits();
                }

                selectedUnits.Add(iUnit.gameObject.transform);
                iUnit.OnInteractEnter();
                return iUnit;
            }
            else
            {
                return null;
            }
        }

        private Ineractables.IBuilding AddedBuilding(Transform tf)
        {
            Ineractables.IBuilding iBuilding = tf.GetComponent<Ineractables.IBuilding>();

            if(iBuilding)
            {
                DeselectUnits();
                selectedBuilding = iBuilding.gameObject.transform;
                iBuilding.OnInteractEnter();
                return iBuilding;
            }
            else
            {
                return null;
            }
        }

    }
}


