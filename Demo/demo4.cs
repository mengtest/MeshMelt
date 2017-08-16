using UnityEngine;
using System.Collections;

public class demo4 : MonoBehaviour
{

    #region Invisible variable
    private GameObject _MainCamera;
    private GameObject _Plane;
    private float x = 94.0f;
    private float y = 24.0f;
    private float distance = 10.0f;
    #endregion
    // Use this for initialization
    void Start()
    {
        _MainCamera = GameObject.Find("Main Camera");
        _Plane = GameObject.Find("Plane");
    }
    #region Invisible method
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mouse = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            Ray ray = _MainCamera.GetComponent<Camera>().ScreenPointToRay(new Vector3(mouse.x, mouse.y, 0));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.GetComponent<MeshMelt>() != null)
                    hit.transform.GetComponent<MeshMelt>().BeginMelt();
            }
        }
        if (_MainCamera != null && _Plane != null)
        {
            if (Input.GetAxis("Mouse ScrollWheel") < 0)
            {
                if (Camera.main.fieldOfView <= 100)
                    Camera.main.fieldOfView += 2;
            }
            if (Input.GetAxis("Mouse ScrollWheel") > 0)
            {
                if (Camera.main.fieldOfView > 2)
                    Camera.main.fieldOfView -= 2;
            }
            if (Input.GetMouseButton(1))
            {
                x += Input.GetAxis("Mouse X") * 150 * 0.02f;
                y -= Input.GetAxis("Mouse Y") * 150 * 0.02f;

                if (y < -360) y += 360;
                if (y > 360) y -= 360;
                y = Mathf.Clamp(y, -85, 85);
            }
            distance = Mathf.Clamp(distance, 0, 10);
            Quaternion rotation = Quaternion.Euler(y, x, 0.0f);
            Vector3 disVector = new Vector3(0.0f, 0.0f, -distance);
            Vector3 position = rotation * disVector + _Plane.transform.position;

            _MainCamera.transform.rotation = Quaternion.Lerp(_MainCamera.transform.rotation, rotation, Time.deltaTime * 5.0f);
            _MainCamera.transform.position = Vector3.Lerp(_MainCamera.transform.position, position, Time.deltaTime * 5.0f);

            _MainCamera.transform.LookAt(_Plane.transform);
        }
    }
    void OnGUI()
    {
        GUI.Box(new Rect(0, 0, 200, 30), "点击场景中的物体，融化该物体");
    }
    #endregion
}
