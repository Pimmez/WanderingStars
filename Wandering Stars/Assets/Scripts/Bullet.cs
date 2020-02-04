using UnityEngine;

public class Bullet : MonoBehaviour
{
	private Rigidbody2D rigid;
	[SerializeField] private float bulletForce = 10f;

	private void Awake()
	{
		rigid = GetComponent<Rigidbody2D>();
	}

	private void FixedUpdate()
	{
		rigid.AddForce(transform.up * bulletForce, ForceMode2D.Impulse);
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		gameObject.SetActive(false);
		//instantiate (GameObject) hit effect
	}
}