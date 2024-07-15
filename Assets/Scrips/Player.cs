using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour 
{
    //public or private reference
    //data type (int, float, bool, string)
    //every variable has a name
    //optional value assingned
    [SerializeField]
    private float _speed = 3.5f;

    void Start()
    {
      transform.position = new Vector3(0, 0, 0);  
    }

    // Update is called once per frame
    void Update()
    {
       movement();
    }

     
     void movement()
     {
        
        float horizontalInput = Input 
        .GetAxis("Horizontal");

     float verticalInput = Input 
        .GetAxis("Vertical");
        
        //Bottom line is another way to write code. so now 3 ways
       
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

}



