using UnityEngine.EventSystems;
using UnityEngine;

public class DoubleClick : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private Camera camera;
    [SerializeField] private GameObject ball;
    [SerializeField] private TrailRenderer trailRenderer;

    float clicked = 0;
    float clicktime = 0;
    float clickdelay = 0.5f;

    public void OnPointerDown(PointerEventData data)
    {
        clicked++;
        if (clicked == 1)
        {
            clicktime = Time.time;
        }
        if (clicked > 1 && Time.time - clicktime < clickdelay)
        {
            clicked = 0;
            clicktime = 0;
            // do position 0

        }
        else if (clicked > 2 || Time.time - clicktime > clickdelay)
        {
            clicked = 0;
        }
    }
}
