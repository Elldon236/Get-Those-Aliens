using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poweup : MonoBehaviour
{
    [SerializeField]
    private float _rotationSpeed = 50f;
    [SerializeField]
    private float _speed = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, _rotationSpeed * Time.deltaTime, 0f, Space.Self);
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        if (transform.position.y < -6.0f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
      if (other.tag == "Player")
        {
            Player player = other .transform.GetComponent<Player>();
            if (player != null)
            {
                player.TripleShotActive();
            }
           Destroy(this.gameObject);
        }
    }
}
