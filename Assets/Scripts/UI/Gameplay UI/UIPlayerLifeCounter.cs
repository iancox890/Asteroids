using UnityEngine;
using UnityEngine.UI;
using Asteroids.Gameplay;

namespace Asteroids.UI
{
    /// <summary>
    /// Grabs the starting lives for the player and instantiates
    /// the corresponding life graphics.
    /// 
    /// On life lost, disables the last life image added.
    /// </summary>
    public class UIPlayerLifeCounter : MonoBehaviour
    {
        [SerializeField] private GameObject _lifePrefab;

        private PlayerLifeManager _lifeManager;
        private Image[] _lives;

        private void Start()
        {
            _lifeManager = FindObjectOfType<PlayerLifeManager>();
            _lives = new Image[_lifeManager.StartingLives];

            for (int i = 0; i < _lives.Length; i++)
            {
                GameObject life = GameObject.Instantiate(_lifePrefab.gameObject, transform);
                _lives[i] = life.GetComponent<Image>();
            }

            _lifeManager.OnLifeLost += RemoveLife;
        }

        private void OnDestroy()
        {
            _lifeManager.OnLifeLost -= RemoveLife;
        }

        private void RemoveLife(int remainingLives)
        {
            _lives[remainingLives].enabled = false;
        }
    }
}