using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;


public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4.0f;
    private object other;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        
            transform.Translate(Vector3.down * _speed * Time.deltaTime);

        if(transform.position.y  < -5f)
        {
            transform.position = new Vector3(Random.Range(-4f, 4f), 5, 0); 
        }
        
    }
        private void OnTriggerEnter2D(Collider2D other) 
        { 
             //Dont forget to add a tag to each gameObject.
        if (other.tag == "Player")
        {
            Player player = other.transform.GetComponent<Player>();
            if (player != null)
            {
                player.Damage();
            }
            Destroy(this.gameObject);
        }
           //Dont forget to add a tag to each gameObject.
        if (other.tag == "Laser")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject); 
        }




    }
        

}

