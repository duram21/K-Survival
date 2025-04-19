using UnityEngine;
using TMPro;
using DG.Tweening;


public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Inst {get ; private set;}

    [SerializeField] GameObject damagePrefab;



    public Enemy selectEnemy;
    WaitForSeconds delay1 = new WaitForSeconds(1);
    WaitForSeconds delay2 = new WaitForSeconds(2);

    void Awake()
    {
        Inst = this;
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnemyMouseOver(Enemy enemy)
    {
        if(CardManager.Inst.isMyCardDrag)
            selectEnemy = enemy;
    }

    public void EnemyMouseExit()
    {
        selectEnemy = null;
    }

    public void EnemyMouseDown(Enemy enemy)
    {
        // 애초에 몬스터 공격하려고 카드 끌어서 옮기는데 마우스 우클릭 할 이유가 없지 않나 ? 이거 일단 배제해도 될듯?

        // if(!CanMouseInput)
        //     return;

        // selectEnemy = enemy;
    }

    public void EnemyMouseUp()
    {
        // if(!CanMouseInput)
        //     return;
        
       
        

    }




}
