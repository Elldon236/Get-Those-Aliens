using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
      [SerializeField]
    private float _speed = 5f;
    public int _outOfBounds = 3;
    
    void Update()
    {
       transform.position += Vector3.up * _speed * Time.deltaTime; 

       if(transform.position.y > _outOfBounds)
       {
         Destroy(this.gameObject);
       }
    }

}
