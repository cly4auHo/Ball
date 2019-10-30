using UnityEngine;

public class MovementManager : MonoBehaviour
{
    [SerializeField] private Ball ball;

    private float clicktime = 0;
    private float clickdelay = 0.2f;

    private bool pendingClick = false;
    private Ray ray;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && hit.transform.name == "Ball")
            {
                OnSingleClick();

                if (pendingClick && Time.timeSinceLevelLoad - clicktime > clickdelay)
                {
                    pendingClick = false;
                }

                RegisterClick();
            }
        }
    }

    private void RegisterClick()
    {
        if (!pendingClick)
        {
            clicktime = Time.timeSinceLevelLoad;
            pendingClick = true;
        }
        else
        {
            OnDoubleClick();
            pendingClick = false;
        }
    }

    void OnDoubleClick()
    {
        ball.ResetToStart();
    }

    void OnSingleClick()
    {
        ball.StartMove();
    }
}
