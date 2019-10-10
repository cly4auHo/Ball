using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float speed = 15f;
    private Vector3 position;
    private Vector3 velocity;
    private Vector3 delta;


    void Start()
    {

    }


    void Update()
    {
        delta = Vector3.left * speed;
        velocity = new Vector3(delta.x, delta.x * delta.x, delta.z);
        transform.position += velocity * Time.deltaTime;
    }
}
