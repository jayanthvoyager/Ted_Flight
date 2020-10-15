using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Test : MonoBehaviour
{
    public float Angle =45;
    public Vector3 Right = new Vector3(0, 0,-1);
    public Vector3 Left=new Vector3(0,0,1);
    public Vector3 Direction;
    public float InTime=2;
    public bool Game_on = false;
    public float Fuel = 180;
    public Coroutine rotateObject;
    public SpriteRenderer sprite;
    public Slider slider;
    public GameManager gameManager;

    public float FinalAngle = 0;

    // Use this for initialization
    void Start()
    {
        Direction = Left;


    }

    public void Update()
    {

      
    }

    public void Rotate_Direction()
    {
        if (Direction == Left)
        {
            Direction = Right;
            sprite.flipX = true;
        }
        else if ((Direction == Right))
        {
            Direction = Left;
            sprite.flipX = false;
        }
    }

    

    public void reduceFuelSubJet1()
    {
        Fuel = Fuel-45;
        slider.value = Fuel / 180;
    }
    public void IncreaseFuelSubJet1()
    {
        Fuel = Fuel + 45;
        slider.value = Fuel / 180;
    }

        public void reduceFuelSubJet2()
    {
        Fuel = Fuel - 45;
        slider.value = Fuel / 180;
    }

    public void IncreaseFuelSubJet2()
    {
        Fuel = Fuel + 45;
        slider.value = Fuel / 180;
    }

        public void IncreseFuel_in_MainJet()
    {
        Fuel = Fuel + 45;
        slider.value = Fuel / 180;
    }
   

    public void GameOn()
    {
        Game_on = true;
        if (Game_on == true)
        {
            rotateObject= StartCoroutine(RotateObject(Angle, Direction, InTime,Fuel));
        }
    }

    IEnumerator RotateObject(float angle, Vector3 axis, float inTime,float Fuel)
    {
        if (Game_on == true)
        {
            // calculate rotation speed
            float rotationSpeed = angle / inTime;

            while (true)
            {
                // save starting rotation position
                Quaternion startRotation = transform.rotation;

                float deltaAngle = 0;

                // rotate until reaching angle
                while (deltaAngle < angle)
                {
                    float tempfuel = Fuel;
                    tempfuel = tempfuel - deltaAngle;
                    slider.value = tempfuel / 180;

                    deltaAngle += rotationSpeed * Time.deltaTime;

                    deltaAngle = Mathf.Min(deltaAngle, angle);

                    transform.rotation = startRotation * Quaternion.AngleAxis(deltaAngle, axis);

                    yield return null;
                }

                // delay here
                yield return new WaitForSeconds(0.01f);
                Fuel = Fuel - deltaAngle;

                this.Fuel = this.Fuel - deltaAngle;
                
                FinalAngle = FinalAngle+ ((axis.z) *(deltaAngle));
                Debug.Log("" + FinalAngle);
                if (this.Fuel <= -10)
                {
                    gameManager.gameLost = true;
                    gameManager.GameLost();
                    //Engine Dead
                }
               // Debug.Log("" + Fuel);

                Game_on = false;
                StopCoroutine(rotateObject);
            }
        }
    }
}