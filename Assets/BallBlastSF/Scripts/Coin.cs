using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private float fallingSpeed;

    private Vector3 velocity;

    private void Awake()
    {
        velocity.x = 0;
        velocity.y = fallingSpeed;
        velocity.z = 0;
    }
    private void Update()
    {
        if (transform.position.y > -4f)
            Move();
    }
    public void Move()
    {
        transform.position -= velocity * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Cart cart = collision.transform.root.GetComponent<Cart>();
        if (cart != null)
        {
            CoinCollector.Instance.AddCoins(1);
            Destroy(gameObject);
        }
    }
}
