using UnityEngine;

public class PinchZoom : MonoBehaviour
{
    public float perspectiveZoomSpeed = 0.5f;        // The rate of change of the field of view in perspective mode.
    public float orthoZoomSpeed = 0.5f;        // The rate of change of the orthographic size in orthographic mode.

    public Camera _activeCamera;

    void Start()
    {
        if ( _activeCamera != null )
        {
            _activeCamera = this.GetComponent<Camera>();
        }
    }

    void Awake()
    {
        if (_activeCamera != null)
        {
            _activeCamera = this.GetComponent<Camera>();
        }
    }
    void Update()
    {
        if (_activeCamera != null)
        {
            _activeCamera = this.GetComponent<Camera>();
        }


        // If there are two touches on the device...
        if (Input.touchCount == 2)
        {
            // Store both touches.
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            // Find the position in the previous frame of each touch.
            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            // Find the magnitude of the vector (the distance) between the touches in each frame.
            float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

            // Find the difference in the distances between each frame.
            float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

            // If the camera is orthographic...
            if (camera.isOrthoGraphic)
            {
                // ... change the orthographic size based on the change in distance between the touches.
                camera.orthographicSize += deltaMagnitudeDiff * orthoZoomSpeed;

                // Make sure the orthographic size never drops below zero.
                camera.orthographicSize = Mathf.Max(camera.orthographicSize, 0.1f);
            }
            else
            {
                // Otherwise change the field of view based on the change in distance between the touches.
                camera.fieldOfView += deltaMagnitudeDiff * perspectiveZoomSpeed;

                // Clamp the field of view to make sure it's between 0 and 180.
                camera.fieldOfView = Mathf.Clamp(camera.fieldOfView, 0.1f, 179.9f);
            }
        }
        else
        if ( Input.mousePresent && !_activeCamera.isOrthoGraphic)
        {
            //var cam = this;
            //if (Input.GetAxis("Mouse ScrollWheel") > 0) // forward
            //{
            //    cam.transform.Translate(-cam.transform.forward);
            //    Debug.Log(cam.transform.position);
            //}
            //if (Input.GetAxis("Mouse ScrollWheel") < 0) // back
            //{
            //    cam.transform.Translate(cam.transform.forward);
            //    Debug.Log(cam.transform.position);
            //}

            var scrollVal = -Input.GetAxis("Mouse ScrollWheel");
            if ( scrollVal != 0 )
            {
                _activeCamera.fieldOfView += scrollVal * perspectiveZoomSpeed;
                _activeCamera.fieldOfView = Mathf.Clamp(camera.fieldOfView, 30f, 100f);
            }
        }
        else
        if (Input.mousePresent && _activeCamera.isOrthoGraphic)
        {
            var scrollVal = -Input.GetAxis("Mouse ScrollWheel");
            if (scrollVal != 0)
            {
                _activeCamera.orthographicSize += scrollVal * perspectiveZoomSpeed;
                _activeCamera.orthographicSize = Mathf.Max(camera.orthographicSize, 0.1f);
            }
        }
    }
}