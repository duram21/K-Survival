using UnityEngine;
using TMPro;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject damagePicker;
    [SerializeField] TMP_Text nameTMP;
    [SerializeField] TMP_Text healthTMP;

    [SerializeField] 

    Animator anim;

    
    public int health;
    public bool isDie;

    public void Setup(Item item)
    {
        
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public bool Damaged(int damage)
    {
        health -= damage;
        // healthTMP.text = health.ToString();

        if(health < 0){
            isDie = true;
            Dead();
            return true;
        }
        return false;
    }

    void OnMouseOver()
    {
        if(CardManager.Inst.isMyCardDrag)
            damagePicker.SetActive(true);
        
        else if(!CardManager.Inst.isMyCardDrag)
            damagePicker.SetActive(false);
        //Debug.Log("충돌함");
        EnemyManager.Inst.EnemyMouseOver(this);
    }

    public void OnMouseExit()
    {
        damagePicker.SetActive(false);
        EnemyManager.Inst.EnemyMouseExit();
    }

    public void OnMouseDown()
    {
        // EntityManager.Inst.EntityMouseDown(this);
        EnemyManager.Inst.EnemyMouseDown(this);
    }

    public void OnMouseUp()
    {
        Debug.Log("onmouseup 실행됨!");
        // EntityManager.Inst.EntityMouseUp();
        EnemyManager.Inst.EnemyMouseUp();
    }

    void Dead()
    {
        // animation 죽음 처리
        anim.SetTrigger("Dead");

        // 죽으면 아이템을 떨궈야지 ?? 
        DropItem();

    }

    void DropItem()
    {
        //if(itemPrefab == null) return ;
        
    }
}
