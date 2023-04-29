using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float Speed;
    private float CurrentSpeed;
    Vector3 Direction;


    public float DashSpeed;
    public float DashTime; 
    public float DashCooldown;

    private float DashCounter;
    private float DashCooldownCounter; //Si se quiere cooldown, activar este 

    // Start is called before the first frame update
    void Start()
    {
        CurrentSpeed = Speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.Find("RealPlayer") == null)
        {
            Destroy(gameObject);
            
        }
        else
        {
            
        }

        //Movement Keys
        if (DashCounter <= 0)
        {
            Direction = Vector3.zero;
            if (Input.GetKey(KeyCode.W))
            {
                Direction += new Vector3(0f, 1f, 0f);
            }

            if (Input.GetKey(KeyCode.D))
            {
                Direction += new Vector3(1f, 0f, 0f);

            }

            if (Input.GetKey(KeyCode.A))
            {
                Direction += new Vector3(-1f, 0f, 0f);

            }

            if (Input.GetKey(KeyCode.S))
            {
                Direction += new Vector3(0f, -1f, 0f);

            }
        }

        transform.position += Direction.normalized * CurrentSpeed * Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (DashCounter <= 0) //&& DashCooldownCounter <= 0
            {
                CurrentSpeed = DashSpeed; 
                DashCounter = DashTime; 
                gameObject.transform.GetChild(0).gameObject.layer = 8; 
            }
        }
        if (DashCounter > 0)
        {
            DashCounter -= Time.deltaTime;

            if (DashCounter <= 0)
            {
                CurrentSpeed = Speed;
               // DashCooldownCounter = DashCooldown; 
                gameObject.transform.GetChild(0).gameObject.layer = 3;
            }
        }
        else
        {

        }
        //Si se quiere cooldown, activar este 
        //if (DashCooldownCounter > 0)      
        //{
        //    DashCooldownCounter -= Time.deltaTime; 
        //}


    }
}
