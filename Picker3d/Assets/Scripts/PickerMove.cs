using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PickerMove : MonoBehaviour
{
    Rigidbody rg;
    public float OnTheMove;
    float movespeed = 20, change;    
    Vector2 direction=new Vector2(0,0),startpos;
    public Slider sl;

    void Start()
    {
        rg = this.GetComponent<Rigidbody>();
        Time.timeScale = 0f;
        OnTheMove = -5f;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0) 
        {
            Time.timeScale = 1f;
            Touch touch = Input.GetTouch(0);           

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    startpos = touch.position;                   
                    break;
                case TouchPhase.Moved:
                     direction = (touch.position - startpos)/Screen.width;
                     change = touch.position.x - startpos.x;
                                     
                    break;
               
            }

        }
        if (this.transform.position.z < -39)
            SceneManager.LoadScene(1);

        MoveProgressBar((45f-this.transform.position.z)/84);
        
        
    }

    private void FixedUpdate()
    {
        
        
         if (Mathf.Abs(change) > 10)
            
        this.transform.position += new Vector3(-direction.x, 0, 0) * Time.deltaTime * movespeed;

         if (this.transform.position.x > 2f)
         {
             this.transform.position = new Vector3(1.9f, this.transform.position.y, this.transform.position.z);
         }
         else if (this.transform.position.x < -1.9)
         {
             this.transform.position = new Vector3(-1.8f, this.transform.position.y, this.transform.position.z);
         }
         direction = new Vector2(0, 0);
         MovePicker();

    }

    private void MovePicker()
    {
        rg.velocity = new Vector3(0, 0,OnTheMove);
        
    }
    private void MoveProgressBar(float progress)
    {
        sl.value = progress;
    }
   
}
