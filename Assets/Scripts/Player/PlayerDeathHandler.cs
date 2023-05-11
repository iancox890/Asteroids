using UnityEngine;
using System.Collections.Generic;

namespace Asteroids
{
    /// <summary>
    /// Controls when and if the player dies.
    /// </summary>
    public class PlayerDeathHandler : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Asteroid") == false)
            {
                return;
            }

            gameObject.SetActive(false);
        }
    }
}