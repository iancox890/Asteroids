using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using Asteroids.Data;

namespace Asteroids.Gameplay
{
    /// <summary>
    /// Sets a given components color to match that of the current player
    /// ship.
    /// </summary>
    public class PlayerShipColor : MonoBehaviour
    {
        [SerializeField] private PlayerData _playerData;
        [SerializeField] private ComponentType _component;

        private enum ComponentType { SpriteRenderer, ParticleSystem, Bloom }

        private void Awake()
        {
            UpdateColor();
            _playerData.OnPlayerFileSaved += UpdateColor;
        }

        private void OnDestroy()
        {
            _playerData.OnPlayerFileSaved -= UpdateColor;
        }

        private void UpdateColor()
        {
            Color shipColor = _playerData.File.ShipColor;

            if (_component == ComponentType.SpriteRenderer)
            {
                SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
                spriteRenderer.color = shipColor.SetOpacity(spriteRenderer.color.a);
            }
            else if (_component == ComponentType.ParticleSystem)
            {
                var main = GetComponent<ParticleSystem>().main;

                if (main.startColor.mode == ParticleSystemGradientMode.Color)
                {
                    main.startColor = shipColor;
                }
                else
                {
                    GradientColorKey[] colorKeys = new GradientColorKey[2];

                    colorKeys[0] = new GradientColorKey(shipColor, 0);
                    colorKeys[1] = new GradientColorKey(shipColor, 1);

                    ParticleSystem.MinMaxGradient particleGradient = new ParticleSystem.MinMaxGradient();
                    particleGradient.mode = ParticleSystemGradientMode.Gradient;

                    Gradient gradient = new Gradient();

                    gradient.SetKeys(colorKeys, main.startColor.gradient.alphaKeys);
                    particleGradient.gradient = gradient;

                    main.startColor = particleGradient;
                }
            }
            else if (_component == ComponentType.Bloom)
            {
                Volume volume = GetComponent<Volume>();

                Bloom bloom;
                volume.profile.TryGet<Bloom>(out bloom);

                bloom.tint.value = shipColor;
            }
        }
    }
}