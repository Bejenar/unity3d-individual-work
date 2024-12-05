using UnityEngine;

namespace _Project.Source.Village
{
    public class RTSCamera : MonoBehaviour
    {
        // [SerializeField]
        // private float _borderSize = 50f;

        [SerializeField]
        private float _panSpeed = 10f;

        // [SerializeField]
        // private Vector2 _panLimit =
        //     new Vector2(30f, 35f);

        [SerializeField]
        private float _scrollSpeed = 1000f;

        [SerializeField]
        private Vector2 _scrollLimit =
            new Vector2(5f, 10f);

        private Vector3 _initialPosition = Vector3.zero;

        private Camera _cam;

        public bool inputEnabled = true;
        
        public void ToggleInput(bool flag)
        {
            inputEnabled = flag;
        }
        
        private void Awake()
        {
            G.cam = this;
            Debug.Log(G.cam);

            _cam = GetComponent<Camera>();
            _initialPosition = transform.localPosition;

            UnityEngine.Cursor.visible = false;
            UnityEngine.Cursor.lockState = CursorLockMode.Confined;
        }

        private void Update()
        {
            if (!inputEnabled) return;

            HandleMouseMovement();
            HandleZoom();
        }

        private void HandleMouseMovement()
        {
            var mousePositionX = Mathf.Clamp01(Input.mousePosition.x / Screen.width) - 0.5f;
            var mousePositionY = Mathf.Clamp01(Input.mousePosition.y / Screen.height) - 0.5f;

            var playerGlobalPosition =
                new Vector3(mousePositionX * _panSpeed, 0, mousePositionY * _panSpeed);
            var centerPosition = _initialPosition;

            var newPosition = Vector3.Lerp(transform.localPosition,
                Vector3.Lerp(centerPosition, playerGlobalPosition, 0.3f),
                Time.deltaTime * 2f);

            transform.localPosition = newPosition;

            // var mousePosition = Input.mousePosition;
            // var movement = Vector3.zero;
            // if (mousePosition.x < _borderSize)
            // {
            //     movement.x -= _panSpeed;
            // }
            // if (mousePosition.x > Screen.width - _borderSize)
            // {
            //     movement.x += _panSpeed;
            // }
            // if (mousePosition.y < _borderSize)
            // {
            //     movement.z -= _panSpeed;
            // }
            // if (mousePosition.y > Screen.height - _borderSize)
            // {
            //     movement.z += _panSpeed;
            // }
            // movement *= Time.deltaTime;
            // movement = Quaternion.Euler(0, transform.eulerAngles.y, 0) * movement;
            // var newPosition = transform.position + movement;
            // newPosition.x = Mathf.Clamp(newPosition.x, _initialPosition.x - _panLimit.x, _initialPosition.x + _panLimit.x);
            // newPosition.z = Mathf.Clamp(newPosition.z, _initialPosition.z - _panLimit.y, _initialPosition.z + _panLimit.y);
            // transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * _panSpeed);
        }

        private void HandleZoom()
        {
            var scroll = Input.GetAxis("Mouse ScrollWheel");
            var zoom = _cam.orthographicSize - scroll * _scrollSpeed * Time.deltaTime;
            zoom = Mathf.Clamp(zoom, _scrollLimit.x, _scrollLimit.y);
            _cam.orthographicSize = zoom;
        }
    }
}