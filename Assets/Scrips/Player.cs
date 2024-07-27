using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour 
{
    [SerializeField]
    private float _speed = 3.5f;
   [SerializeField]
    private GameObject _MissilePrefab;
    public Vector3 missileOffset = new Vector3(0, 0, 0);
    [SerializeField]
    private float _fireRate = 5f;
    private float _canFire = -1f;
    [SerializeField]
    private int _Lives = 6;
    [SerializeField]
    private SpawnManager  _spawnManager;


    void Start()
    {
      transform.position = new Vector3(0, 0, 0);
      _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
       movement();

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire)
        {
            FireMissile();
        }


    }

   void movement()
     {
        
        float horizontalInput = Input 
        .GetAxis("Horizontal");

     float verticalInput = Input 
        .GetAxis("Vertical");
        
        //transform.Translate(Vector3.left *
        //horizontalInput  * _speed * Time.deltaTime);

        // transform.Translate(Vector3.up *
        //verticalInput * _speed * Time.deltaTime);

    transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * _speed * Time.deltaTime);


       //this is for block up and down
       if (transform.position.y >= 0) 
       {
          transform.position = new Vector3(transform.position.x, 0, 0);
       }
       else if(transform.position.y <= -1.59f)
       {
          transform.position = new Vector3(transform.position.x, -1.59f, 0); 
       }


       //this is for warp side to side
       if (transform.position.x > 8.43) 
       {
        transform.position = new Vector3(-8.43f, transform.position.y, 0);
       }

      else if(transform.position.x <= -8.43f)
      {
          transform.position = new Vector3(8.43f, transform.position.y, 0);  
      }
     
  
   }

    void FireMissile()
    
        {
            _canFire = Time.time + _fireRate;
            Instantiate(_MissilePrefab, transform.position + new Vector3(0, 0.38f, 0), Quaternion.identity);
        }

        public void Damage()
        {
            _Lives --;
        

        if (_Lives < 1)
        {
          _spawnManager.OnPlayerDeath();
          Destroy(this.gameObject);
        }

        }
    }



