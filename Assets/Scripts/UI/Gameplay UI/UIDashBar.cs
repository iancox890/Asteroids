using UnityEngine;
using UnityEngine.UI;
using Asteroids.Gameplay;
using System.Collections;

namespace Asteroids.UI
{
    /// <summary>
    /// Updates the dash bar (slider) to fill up when the next dash is available.
    /// </summary>
    public class UIDashBar : MonoBehaviour
    {
        private PlayerShipDash _playerDash;
        private Slider _dashBar;

        private void Start()
        {
            _playerDash = FindObjectOfType<PlayerShipDash>();

            if (_playerDash == null)
            {
                gameObject.SetActive(false);
                return;
            }

            _dashBar = GetComponent<Slider>();
            _playerDash.OnDash += StartUpdateBarCoroutine;
        }

        private void OnDestroy()
        {
            if (_playerDash != null)
            {
                _playerDash.OnDash -= StartUpdateBarCoroutine;
            }
        }

        private void StartUpdateBarCoroutine()
        {
            StartCoroutine(UpdateBar());
        }

        private IEnumerator UpdateBar()
        {
            float nextAvailableDashTime = _playerDash.NextAvailableDashTime - Time.time;
            float time = 0;

            _dashBar.value = 0;

            while (_dashBar.value != 1)
            {
                float t = time / nextAvailableDashTime;

                _dashBar.value = Mathf.Lerp(0, 1, t * t);
                time += Time.deltaTime;

                yield return null;
            }
        }
    }
}