using UnityEngine;

public class Cart : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float movementSpeed;
    [SerializeField] private float venichleWidth;

    [Header("Wheels")]
    [SerializeField] private Transform[] wheels;
    [SerializeField] private float wheelRadius;

    private Vector3 movementTarget;
    private float deltaMovement;
    private float lastPositioX;

    private void Start()
    {
        movementTarget = transform.position;
    }
    private void Update()
    {
        Move();
        RotateWheel();
    }

    private void Move()
    {
        lastPositioX = transform.position.x;
        transform.position = Vector3.MoveTowards(transform.position, movementTarget, movementSpeed * Time.deltaTime);
        deltaMovement = transform.position.x - lastPositioX;
    }

    private void RotateWheel()
    {
        float angle = (180 * deltaMovement) / (Mathf.PI * wheelRadius * 2);

        for (int i = 0; i < wheels.Length; i++)
        {
            wheels[i].Rotate(0, 0, -angle);
        }
    }

    public void SetMovementTarget(Vector3 target)
    {
        movementTarget = ClampMovementTarget(target);
    }

    private Vector3 ClampMovementTarget(Vector3 target)
    {
        float leftBorder = -8.8f + venichleWidth * 0.5f;
        float rightBorder = 8.8f - venichleWidth * 0.5f;

        Vector3 movTarget = target;
        movTarget.z = transform.position.z;
        movTarget.y = transform.position.y;

        if (movTarget.x < leftBorder)
            movTarget.x = leftBorder;
        if (movTarget.x > rightBorder)
            movTarget.x = rightBorder;

        return movTarget;
    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position - new Vector3(venichleWidth * 0.5f, 0.5f, 0),
             transform.position + new Vector3(venichleWidth * 0.5f, -0.5f, 0) );
    }
#endif
}
