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
    // Start is called before the first frame update
    void Start()
    {
      //take the current postion = new postion (0, 0, 0,)
      transform.position = new Vector3(0, 0, 0);  
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input 
        .GetAxis("Horizontal");

     float verticalInput = Input 
        .GetAxis("Vertical");
        //new vector3(0, 0, 0) * 5 * real time
        //Bottom line is another way to write code. so now 3 ways
       
        //transform.Translate(Vector3.left *
        //horizontalInput  * _speed * Time.deltaTime);

        // transform.Translate(Vector3.up *
        //verticalInput * _speed * Time.deltaTime);

    transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * _speed * Time.deltaTime);
    }
}
