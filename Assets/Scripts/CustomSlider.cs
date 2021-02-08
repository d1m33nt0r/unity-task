using UnityEngine;

public class CustomSlider : MonoBehaviour
{
    private Vector2 startPos;
    private Vector2 min, max;

    [SerializeField]
    private Camera cam;

    [SerializeField]
    private Transform circle;

    [SerializeField]
    private Transform square;

    private bool isMoving;

    private void Start()
    {
        min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        square.localScale = new Vector3(Mathf.Abs(min.x - max.x), square.localScale.y, square.localScale.z);
        square.position = new Vector2(square.position.x, min.y + Mathf.Abs(min.y - max.y) / 10);
        circle.position = square.position;
    }

    void Update()
    {
        if(isMoving)
        {
            if (Input.GetMouseButtonDown(0))
                startPos = cam.ScreenToWorldPoint(Input.mousePosition);
            else if (Input.GetMouseButton(0))
            {
                float pos = cam.ScreenToWorldPoint(Input.mousePosition).x - startPos.x;
                circle.position = new Vector3(Mathf.Clamp(circle.position.x + pos, min.x, max.x), circle.position.y, circle.position.z);
                startPos = circle.position;
            }
        }
    }

    public void EnableMoving()
    {
        isMoving = true;
    }

    public void DisableMoving()
    {
        isMoving = false;
    }
}