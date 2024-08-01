using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour 
{
    [SerializeField]
    private float _speed = 3.5f;
    [SerializeField]
    private GameObject _missilePrefab;
    [SerializeField]
    private GameObject _tripleShotPrefab;
    [SerializeField]
    private float _fireRate = 5f;
    private float _canFire = -1f;
    [SerializeField]
    private int _lives = 6;
    [SerializeField]
    private SpawnManager _spawnManager; 

    [SerializeField]    
    private bool _isTripleShotActive = false;
    

    void Start()
    {

        {
            transform.position = new Vector3(0, 0, 0);
            _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();
        }

    }
    // Update is called once per frame
    void Update()
    {
        Movement();

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire)
        {
            FireMissile();
        }


    }




    void Movement()
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
        else if (transform.position.y <= -5.25f)
        {
            transform.position = new Vector3(transform.position.x, -5.25f, 0);
        }




        //this is for warp side to side
        if (transform.position.x > 8.43)
        {
            transform.position = new Vector3(-8.43f, transform.position.y, 0);
        }

        else if (transform.position.x <= -8.43f)
        {
            transform.position = new Vector3(8.43f, transform.position.y, 0);
        }


    }





    void FireMissile()
    {
        {
            _canFire = Time.time + _fireRate;

            if (_isTripleShotActive == true)
            {
                Instantiate(_tripleShotPrefab, transform.position, Quaternion.identity);
            }

            else
            {
                Instantiate(_missilePrefab, transform.position + new Vector3(0, 0.38f, 0), Quaternion.identity);
            }

        }
     }
    public void Damage()
    {
        _lives--;


        if (_lives < 1)
        {
            _spawnManager.OnPlayerDeath();
            Destroy(this.gameObject);
        }



    }
    public void TripleShotActive()
    { 
      _isTripleShotActive = true;
        StartCoroutine(_TripleShotPowerDownRoutine());
    }


    IEnumerator _TripleShotPowerDownRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        _isTripleShotActive = false;
    }


} 


    

    




    



