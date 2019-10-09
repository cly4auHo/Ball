using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private TrailRenderer trailRenderer;
    [SerializeField] private int scale = 200;
    [SerializeField] private float screenSize = 10;

    [SerializeField] private float speed = 15f;

    private float clicked = 0;
    private float clicktime = 0;
    private float clickdelay = 0.5f;

    void Start()
    {
       
    }


    void Update()
    {

    }

    bool IsDouble()
    {
        return false;
    }
    
}
