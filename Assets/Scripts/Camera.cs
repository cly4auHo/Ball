using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float rotSpeed = 1.5f;

    private float rotY;
    private float rotX;
    private float minimumVert = -45.0f;
    private float maximumVert = 45.0f;

    private Vector3 offset;
    private float horInput;
    private float vertInput;
    private Quaternion rotation;

    void Start()
    {
        rotX = transform.eulerAngles.x;
        rotY = transform.eulerAngles.y;
        offset = target.position - transform.position;
    }

    void LateUpdate()
    {
        horInput = Input.GetAxis("Horizontal");
        vertInput = Input.GetAxis("Vertical");

        if (horInput != 0)
        {
            rotY += horInput * rotSpeed;
            rotX -= vertInput * rotSpeed;
            rotX = Mathf.Clamp(rotX, minimumVert, maximumVert);
        }
        else
        {
            rotY += Input.GetAxis("Mouse X") * rotSpeed * 3;
            rotX -= Input.GetAxis("Mouse Y") * rotSpeed * 3;
            rotX = Mathf.Clamp(rotX, minimumVert, maximumVert);
        }

        rotation = Quaternion.Euler(rotX, rotY, 0);
        transform.position = target.position - (rotation * offset);
        transform.LookAt(target);
    }
}
