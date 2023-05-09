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
            _screenBorder = new Vector2(Camera.main.orthographicSize * 2, (Camera.main.aspect * Camera.main.orthographicSize) / 2);
        }

        private void OnBecameInvisible()
        {
            Vector2 position = _transform.position;

            if (position.x > _screenBorder.x || position.x < -_screenBorder.x)
            {
                position.x = -position.x;
                _transform.position = position;
            }

            if (position.y > _screenBorder.y || position.y < -_screenBorder.y)
            {
                position.y = -position.y;
                _transform.position = position;
            }
        }
    }
}