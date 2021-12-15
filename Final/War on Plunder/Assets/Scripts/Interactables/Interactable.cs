using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SG.WOP.Ineractables
{
    public class Interactable : MonoBehaviour
    {
        public bool isInteracting = false;
        public GameObject highlight = null;
        public virtual void Awake()
        {
            highlight.SetActive(false);
        }
        // Occurs once the object is interacted with
        public virtual void OnInteractEnter()
        {
            ShowHighlight();
            isInteracting = true;
        }
        public virtual void OnInteractExit()
        {
            HideHighlight();
            isInteracting = false;
        }
        public virtual void ShowHighlight()
        {
            highlight.SetActive(true);
        }
        public virtual void HideHighlight()
        {
            highlight.SetActive(false);
        }
    }
}


