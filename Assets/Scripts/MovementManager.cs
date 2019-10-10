using UnityEngine;

public class MovementManager : MonoBehaviour
{
    [SerializeField] private Ball ball;

    private float clicktime = 0;
    private float clickdelay = 0.2f;

    private bool pendingClick = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            RegisterClick();

        if (pendingClick && Time.timeSinceLevelLoad - clicktime > clickdelay)
        {
            OnSingleClick();
            pendingClick = false;
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
