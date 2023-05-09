using UnityEngine;

namespace Asteroids
{
    /// <summary>
    /// Handles screen wrapping for a given game object.
	/// i.e., go through the left side of the screen and come out on the right and vice versa.
    /// </summary>
    public class ScreenWrap : MonoBehaviour
    {
        private Transform _transform;
        private Vector2 _screenBorder;

        private void Start()
        {
            _transform = GetComponent<Transform>();
            _screenBorder = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);

            Vector2 scaleOffset = _transform.localScale * GetComponent<SpriteRenderer>().size;

            _screenBorder.x += scaleOffset.x;
            _screenBorder.y += scaleOffset.y;
        }

        private void Update()
        {
            Vector2 position = _transform.position;

            if (position.x > _screenBorder.x || position.x < -_screenBorder.x)
            {
                position.x = -(int)position.x;
                _transform.position = position;
            }

            if (position.y > _screenBorder.y || position.y < -_screenBorder.y)
            {
                position.y = -(int)position.y;
                _transform.position = position;
            }
        }
    }
}