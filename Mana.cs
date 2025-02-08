using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mana : MonoBehaviour
{
    public float xMov, yMov, yMax, yMin = 0;
    private bool goingUp;
    private Rigidbody2D mov_mana;
    private Vector2 position;
    public float cantMana;
    private GameObject manaBar;

    
    private void Start() {
        goingUp = true;
        xMov = Globales.instance.velocidad_h_Mana;
        yMov = Globales.instance.velocidad_v_Mana;
        yMax = transform.position.y + 0.7f;
        yMin = transform.position.y - 0.7f;
        mov_mana= gameObject.GetComponent<Rigidbody2D>();
        manaBar = GameObject.FindWithTag("ManaBar");
    }
    void Update()
    {
        if((Mathf.Approximately(transform.position.y, yMax) && goingUp == true) || (Mathf.Approximately(transform.position.y, yMin) && goingUp == false))
        {
            yMov *= -1;
            goingUp = !goingUp;
        }
        if(Globales.instance.dash == false){
            position = new Vector2(transform.position.x - xMov, transform.position.y + yMov);
        } else{
            position = new Vector2(transform.position.x - (xMov * Globales.instance.DashSpeed), transform.position.y + (yMov * Globales.instance.DashSpeed));
        }
        position.y = Mathf.Clamp(position.y,yMin,yMax);
        mov_mana.MovePosition(position);
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}


