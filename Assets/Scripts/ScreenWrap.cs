using UnityEngine;

namespace AsteroidsApp
{
    /// <summary>
    /// Handles screen wrapping for a given game object.
	/// i.e., go through the left side of the screen and come out on the right and vice versa.
    /// </summary>
    public class ScreenWrap : MonoBehaviour
    {
        private Transform _transform;
        private Vector2 _wrapBounds;

        private void Start()
        {
            _transform = GetComponent<Transform>();

            Vector2 scaleOffset = _transform.localScale * GetComponent<SpriteRenderer>().size;

            _wrapBounds = ScreenBounds.Bounds;

            _wrapBounds.x += scaleOffset.x;
            _wrapBounds.y += scaleOffset.y;
        }

        private void Update()
        {
            Vector2 position = _transform.position;

            if (position.x > _wrapBounds.x || position.x < -_wrapBounds.x)
            {
                position.x = Mathf.Clamp(-position.x, -_wrapBounds.x, _wrapBounds.x);
                _transform.position = position;
            }

            if (position.y > _wrapBounds.y || position.y < -_wrapBounds.y)
            {
                position.y = Mathf.Clamp(-position.y, -_wrapBounds.y, _wrapBounds.y);
                _transform.position = position;
            }
        }
    }
}