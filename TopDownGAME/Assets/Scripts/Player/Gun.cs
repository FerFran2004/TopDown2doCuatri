using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    public GameObject bulletHolder;
    public Transform ShootPoint;
    public float ShootForce = 10f;
    public int Energy = 0;
    public Text EnergyText;
    public float FireRate = 0.5f;

    private Color DefaultColor; 


    private float ReadytoFire = 0;


    void Start()
    {

    }

    
    void Update()
    {
       EnergyText.text =  Energy.ToString();
       if (FireRate == 0) //Si el arma es automatica; no hay retardo entre bala y bala...
        {

            if (Input.GetKey(KeyCode.Mouse1))
            {
                if (Energy > 0)
                {
                    GameObject bullet = Instantiate(bulletHolder, ShootPoint.position, ShootPoint.rotation);
                    bullet.GetComponent<Rigidbody2D>().AddForce(ShootPoint.up * ShootForce, ForceMode2D.Impulse);
                    Energy -= 1;

                }
                if (Energy <= 0)
                {
                    Debug.Log("No Energy: " + Energy);
                    
                }

            }

       }
       if (ReadytoFire < FireRate) //Sumatoria hasta llegar al tiempo para hacer el disparo
        {
            ReadytoFire += Time.deltaTime;

        }

       else //Si no es automatica...
       {

            if (Input.GetKey(KeyCode.Mouse1) && ReadytoFire > FireRate)
            {
                if (Energy > 0)
                {
                    GameObject bullet = Instantiate(bulletHolder, ShootPoint.position, ShootPoint.rotation);
                    
                    bullet.GetComponent<Rigidbody2D>().AddForce(ShootPoint.up * ShootForce, ForceMode2D.Impulse);
                    Energy -= 1;
                    ReadytoFire = 0;
                }
                if (Energy <= 0)
                {
                    Debug.Log("No Energy: " + Energy);

                }
            }
        }

    }

    public void FillEnergy(int energy)
    {
        Energy += energy;

    }
}
