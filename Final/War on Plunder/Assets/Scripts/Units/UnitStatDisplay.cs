using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SG.WOP.Units
{
    public class UnitStatDisplay : MonoBehaviour
    {
        public float maxHealth, defense, currentHealth;

        [SerializeField]
        private Image healthBarAmount;

        private bool isPlayerUnit = false;

        public void SetStatDisplayBasicUnit(UnitStatTypes.Base stats, bool isPlayer)
        {
            maxHealth = stats.health;
            defense = stats.defense;

            isPlayerUnit = isPlayer;

            currentHealth = maxHealth;
        }

        public void SetStatDisplayBasicBuilding(Buildings.BuildingStatTypes.Base stats, bool isPlayer)
        {
            maxHealth = stats.health;
            defense = stats.defense;

            isPlayerUnit = isPlayer;

            currentHealth = maxHealth;
        }
    

        // Update is called once per frame
        void Update()
        {
            HandleHeath();
        }

        public void TakeDamage(float damage)
        {
            float totalDamage;

            // Checks to see if the defense is higher than the damage taken,
            // if it is it makes the damage 1 instead of 0 or lower
            if (damage - defense <= 0)
            {
                totalDamage = 1;
            }
            else
            {
                totalDamage = damage - defense;

            }

            currentHealth -= totalDamage;

        }

        private void HandleHeath()
        {
            Camera camera = Camera.main;
            //Rotating the healthbars to look at the camera no matter where it is facing
            gameObject.transform.LookAt(gameObject.transform.position +
                camera.transform.rotation * Vector3.forward, camera.transform.rotation * Vector3.up);

            healthBarAmount.fillAmount = currentHealth / maxHealth;

            CheckDeath();
        }

        private void CheckDeath()
        {
            if (currentHealth <= 0)
            {
                if(isPlayerUnit)
                {
                    InputManager.InputHandler.instance.selectedUnits.Remove(gameObject.transform.parent);
                    Destroy(gameObject.transform.parent.gameObject);
                }
                else
                {
                    Destroy(gameObject.transform.parent.gameObject);
                }
                
            }
        }
    }
}


