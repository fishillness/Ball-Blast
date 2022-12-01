using UnityEngine;

public class Cart : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float movementSpeed;
    [SerializeField] private float venichleWidth;

    private Vector3 movementTarget;

    private void Start()
    {
        movementTarget = transform.position;
    }
    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, movementTarget, movementSpeed * Time.deltaTime);
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
