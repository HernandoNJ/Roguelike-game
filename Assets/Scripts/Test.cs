using UnityEngine;

public class Test : MonoBehaviour
{
    public GameObject prefab;
    public float speed;
    public Vector2 bulletDirection = Vector2.right;
    private Rigidbody2D _rigidbody2D;

    private void Start()
    {
        _rigidbody2D = prefab.GetComponent<Rigidbody2D>();
        InvokeRepeating("Bullets", 0, 0.5f);
    }

    private void Bullets()
    {
        Instantiate(prefab, transform.position, transform.rotation);
        _rigidbody2D.AddForce(bulletDirection * speed, ForceMode2D.Impulse);
    }
}