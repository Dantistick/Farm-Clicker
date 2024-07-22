using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float speed = 1.0f;
    public Vector3 minPosition;
    public Vector3 maxPosition;

    private Vector3 dragStartPosition;
    private bool isDragging;
    private float startYPosition;

    void Start()
    {
        startYPosition = transform.position.y;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            dragStartPosition = Input.mousePosition;
            isDragging = true;
        }

        if (Input.GetMouseButton(0) && isDragging)
        {
            Vector3 dragDelta = Input.mousePosition - dragStartPosition;
            float currentYPosition = transform.position.y;
            transform.position = new Vector3(
                Mathf.Clamp(transform.position.x, minPosition.x, maxPosition.x),
                startYPosition,
                Mathf.Clamp(transform.position.z, minPosition.z, maxPosition.z)
            );
            transform.Translate(-dragDelta * Time.deltaTime * speed);
            transform.position = new Vector3(
                Mathf.Clamp(transform.position.x, minPosition.x, maxPosition.x),
                currentYPosition,
                Mathf.Clamp(transform.position.z, minPosition.z, maxPosition.z)
            );
            dragStartPosition = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }
    }
}
