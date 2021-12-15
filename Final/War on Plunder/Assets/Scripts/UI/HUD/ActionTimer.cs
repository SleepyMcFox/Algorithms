using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SG.WOP.UI.HUD
{
    public class ActionTimer : MonoBehaviour
    {
        public static ActionTimer instance = null;

        private void Awake()
        {
            instance = this;
        }

        /// <summary>
        /// So I don't have to constantly check for the timer, instead of
        /// having it in update, I just made it a coroutine
        /// </summary>
        /// <returns></returns>
        public IEnumerator SpawnQueueTimer()
        {
            if(ActionFrame.instance.spawnQueue.Count > 0)
            {
                Debug.Log($"Waiting for {ActionFrame.instance.spawnQueue[0]} seconds");

                // Returns the first number of seconds in the queue
                yield return new WaitForSeconds(ActionFrame.instance.spawnQueue[0]);

                ActionFrame.instance.SpawnObject();

                // If there are more than one units in the queue after the first element is
                // removed, then it will repeat
                if(ActionFrame.instance.spawnQueue.Count > 0)
                {
                    StartCoroutine(SpawnQueueTimer());
                }
            }
        }
    }
}

