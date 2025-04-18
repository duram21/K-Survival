using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;


public class CardManager : MonoBehaviour
{
    public static CardManager Inst {get; private set;}

    [SerializeField] ItemSO itemSO;
    [SerializeField] GameObject cardPrefab;
    [SerializeField] RectTransform canvasParent;
    [SerializeField] List<Card> myCards;
    [SerializeField] RectTransform myCardLeft;
    [SerializeField] RectTransform myCardRight;
    [SerializeField] RectTransform myCardSet;



    List<Item> itemBuffer;
    PRS myCardSetPRS;

    void Awake()
    {
        Inst = this;
        myCardSetPRS = new PRS(myCardSet.anchoredPosition, Quaternion.identity, Vector3.one);
    }

    public Item PopItem()
    {
        if (itemBuffer.Count == 0)
            SetupItemBuffer();

        Item item = itemBuffer[0];
        itemBuffer.RemoveAt(0);
        return item;
    }

    void SetupItemBuffer()
    {
        itemBuffer = new List<Item>(10);
        for (int i = 0; i < itemSO.items.Length; i++)
        {
            Item item = itemSO.items[i];
            for (int j = 0; j < item.percent; j++)
            {
                itemBuffer.Add(item);
            }
        }
        for (int i = 0; i < itemBuffer.Count; i++)
        {
            int rand = UnityEngine.Random.Range(i, itemBuffer.Count);
            Item temp = itemBuffer[i];
            itemBuffer[i] = itemBuffer[rand];
            itemBuffer[rand] = temp;
        }
    }

    void AddCard()
    {
        var cardObject = Instantiate(cardPrefab, canvasParent);
        // 보여주면 안됨
        if(CardShowBtn.Inst.isActive)
            cardObject.SetActive(false);
        else   
            cardObject.SetActive(true);
        

        // RectTransform을 통해 UI 기준으로 위치를 0,0 (부모의 중앙)으로 설정
        RectTransform rect = cardObject.GetComponent<RectTransform>();
        rect.anchoredPosition = Vector2.zero;  // 부모의 중앙으로 위치 설정
        rect.localRotation = Quaternion.identity;  // 회전 초기화
        rect.localScale = Vector3.one;
        var card = cardObject.GetComponent<Card>();
        card.Setup(PopItem());
        myCards.Add(card);
        SetOriginOrder();
        CardAlignment();

    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetupItemBuffer();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Keypad1))
            AddCard();
    }

    void SetOriginOrder()
    {
        int count = myCards.Count ;
        for (int i = 0; i < count; i++)
        {
            var targetCard =  myCards[i];
            targetCard?.GetComponent<Order>().SetOriginOrder(i);
        }
    }

    void CardAlignment()
    {
        List<PRS> originCardPRSs = new List<PRS>();
 
        originCardPRSs = LinearAlignment(myCardLeft, myCardRight, myCards.Count, Vector3.one);
        
       
        var targetCards = myCards;
        for (int i = 0; i < targetCards.Count; i++)
        {
            var targetCard = targetCards[i];

            targetCard.originPRS = originCardPRSs[i];
            // 펼쳐져 있는 상태라면
            if(!CardShowBtn.Inst.isActive)
                targetCard.MoveTransform(targetCard.originPRS, true, 0.7f);
            else if(CardShowBtn.Inst.isActive)
                targetCard.MoveTransform(myCardSetPRS, false);
        }
    }

    List<PRS> LinearAlignment(RectTransform leftTr, RectTransform rightTr, int objCount, Vector3 scale)
    {
        float[] objLerps = new float[objCount];
        List<PRS> results = new List<PRS>(objCount);

        switch (objCount)
        {
            case 1: objLerps = new float[] { 0.0f }; break;
            case 2: objLerps = new float[] { 0.0f, 0.25f }; break;
            case 3: objLerps = new float[] { 0.0f, 0.25f, 0.50f }; break;
            default:
                float interval = 1f / (objCount - 1);
                for (int i = 0; i < objCount; i++)
                {
                    objLerps[i] = interval * i;
                }
                break;
        }

        for (int i = 0; i < objCount; i++)
        {
            var targetPos = Vector3.Lerp(leftTr.anchoredPosition, rightTr.anchoredPosition, objLerps[i]);
            var targetRot = Utils.QI;
            results.Add(new PRS(targetPos, targetRot, scale));

        }

        return results;
    }

    public void FoldCard()
    {
        var targetCard = myCards;

        Sequence sequence = DOTween.Sequence();

        foreach(var card in targetCard)
        {
            RectTransform rect = card.GetComponent<RectTransform>();
            // myCardSet 으로 이동
            if(card == myCards[0])
                sequence.Append(rect.DOAnchorPos(myCardSet.anchoredPosition, 1.0f)).SetEase(Ease.InSine);
            else   
                sequence.Join(rect.DOAnchorPos(myCardSet.anchoredPosition, 1.0f)).SetEase(Ease.InSine);
        
        }
        // 사라짐

        sequence.AppendCallback(() => 
        {
            foreach (var card in myCards)
            {
                card.gameObject.SetActive(false);
            }
        });

    }

    public void ShowCard()
    {
        var targetCard = myCards;

        Sequence sequence = DOTween.Sequence();

        // 먼저 active


        foreach(var card in targetCard)
        {
            RectTransform rect = card.GetComponent<RectTransform>();

            card.gameObject.SetActive(true);
            
            // myCardSet 으로 이동
            if(card == myCards[0])
                sequence.Append(rect.DOAnchorPos(card.originPRS.pos, 1.0f)).SetEase(Ease.InSine);
            else   
                sequence.Join(rect.DOAnchorPos(card.originPRS.pos, 1.0f)).SetEase(Ease.InSine);
        
        }

        
    }


    
}
