using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;

    GameObject currentFloor;

    [SerializeField] int Hp;
    [SerializeField] GameObject HpBar;
    [SerializeField] Text scoreText;
    int score;
    float scoreTime;
    // Start is called before the first frame update
    void Start()
    {
        Hp = 10;
        score = 0;
        scoreTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.D))
        {
            transform.Translate(moveSpeed*Time.deltaTime, 0, 0);
        }
        if(Input.GetKey(KeyCode.A))
        {
            transform.Translate(-moveSpeed*Time.deltaTime, 0, 0);
        }
        UpdateScore();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Normal")
        {
            if(other.contacts[0].normal == new Vector2(0f,1f))
            {
                Debug.Log("撞到第一種階梯");
                currentFloor = other.gameObject;
                ModifyHp(1);
            }
        }
        else if(other.gameObject.tag == "Nails")
        {
            if(other.contacts[0].normal == new Vector2(0f,1f))
            {
                Debug.Log("撞到第二種階梯");
                currentFloor = other.gameObject;
                ModifyHp(-3);
            }
        
        }
        else if(other.gameObject.tag == "Ceiling")
        {
            Debug.Log("撞到天花板");
            currentFloor.GetComponent<BoxCollider2D>().enabled = false;
            ModifyHp(-3);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "DeathLine")
        {
            Debug.Log("你輸了");
        }
    }

    void ModifyHp(int num){
        Hp += num;
        if(Hp>10)
        {
            Hp=10;
        }
        else if(Hp<0)
        {
            Hp = 0;
        }
        UpdateHpBar();
    }

    void  UpdateHpBar()
    {
        for(int i=0; i<HpBar.transform.childCount; i++)
        {
            if(Hp>i)
            {
                HpBar.transform.GetChild(i).gameObject.SetActive(true);
            }
            else
            {
                HpBar.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }

    void UpdateScore()
    {
        scoreTime += Time.deltaTime;
        if(scoreTime>2f)
        {
            score++;
            scoreTime = 0f;
            scoreText.text = "地下" + score.ToString() + "層";
        }
    }
}
