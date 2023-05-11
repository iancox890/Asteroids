using UnityEngine;
using System.Collections;

namespace AsteroidsApp.Player
{
    /// <summary>
    /// Give the player a period of invincibility where they cannot die. (indicated with an opacity flash)
	/// 
	/// This is used on respawn, to give the player a brief moment to get
	/// out of the way of any danger.
    /// </summary>
    public class PlayerShipInvincibility : MonoBehaviour
    {
        [SerializeField] private float _duration;
        [SerializeField] private float _flashCount;
        [SerializeField] private float _opacity;

        private PlayerRespawnHandler _respawnHandler;
        private PlayerShipDeathHandler _deathHandler;

        private SpriteRenderer _spriteRenderer;
        private Color _spriteColor;

        private void Start()
        {
            _respawnHandler = GetComponentInParent<PlayerRespawnHandler>();
            _deathHandler = GetComponent<PlayerShipDeathHandler>();

            _spriteRenderer = GetComponent<SpriteRenderer>();
            _spriteColor = _spriteRenderer.color;

            _respawnHandler.OnRespawn += StartInvincibilityCoroutine;
        }

        private void OnDestroy()
        {
            _respawnHandler.OnRespawn -= StartInvincibilityCoroutine;
        }

        private void StartInvincibilityCoroutine()
        {
            StopAllCoroutines();
            StartCoroutine(EnableInvincibility(Time.time + _duration));
        }

        private IEnumerator EnableInvincibility(float invincibilityEndTime)
        {
            _deathHandler.IsInvincible = true;

            Color lerpColor = _spriteColor;

            float lerpTime = 1;
            float lerpAmount = (_flashCount / _duration) * 2;

            while (Time.time < invincibilityEndTime)
            {
                lerpColor.a = Mathf.Lerp(_opacity, 1f, Mathf.PingPong(lerpTime, 1));
                lerpTime += lerpAmount * Time.deltaTime;

                _spriteRenderer.color = lerpColor;

                yield return null;
            }

            _deathHandler.IsInvincible = false;
        }
    }
}