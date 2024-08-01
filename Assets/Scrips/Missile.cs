using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
      [SerializeField]
    private float _speed = 5f;
    [SerializeField] 
    private int _outOfBounds = 7;
    
    void Update()
    {
       transform.position += Vector3.up * _speed * Time.deltaTime; 

       if(transform.position.y > _outOfBounds)
       {
         if(transform.parent != null)
            {
               Destroy(transform.parent.gameObject);
            }
         Destroy(this.gameObject);
       }
    }

}
