using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] Image card;
    [SerializeField] Image character;
    [SerializeField] TMP_Text nameTMP;
    [SerializeField] TMP_Text attackTMP;

    [SerializeField] GraphicRaycaster raycaster;
    [SerializeField] EventSystem eventSystem;
    public Canvas canvas;

    public Item item;
    public PRS originPRS;
    public int originIndex;

    RectTransform rectTransform;
    bool isEnter;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>(); 
        canvas = GetComponentInParent<Canvas>();
        originIndex = transform.GetSiblingIndex();
        if (eventSystem == null)
            eventSystem = EventSystem.current;
    }

    public void Setup(Item item)
    {
        this.item = item;
        character.sprite = this.item.sprite;
        nameTMP.text = this.item.name;
        attackTMP.text = this.item.attack.ToString();
    }

    public void MoveTransform(PRS prs, bool useDotween, float dotweenTime = 0)
    {
      if(useDotween)
      {
        rectTransform.DOAnchorPos(prs.pos, dotweenTime);
        rectTransform.DORotateQuaternion(prs.rot, dotweenTime);
        rectTransform.DOScale(prs.scale, dotweenTime);
      }
      else
      {
        rectTransform.anchoredPosition = prs.pos;
        rectTransform.rotation = prs.rot;
        rectTransform.localScale = prs.scale;
      }
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isEnter = true;
        CardManager.Inst.CardMouseOver(this);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isEnter =false;
        CardManager.Inst.CardMouseExit(this);
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        // UI에서 마우스를 눌렀을 때
        CardManager.Inst.CardMouseDown();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // UI에서 마우스를 뗐을 때
        CardManager.Inst.CardMouseUp();
    }


    /* void OnMouseOver()
     {
         CardManager.Inst.CardMouseOver(this);
     }

     void OnMouseExit()
     {
         CardManager.Inst.CardMouseExit(this);   
     } */

    /*  void OnMouseDown()
      {
          CardManager.Inst.CardMouseDown();
      }

      void OnMouseUp()
      {
          CardManager.Inst.CardMouseUp();
      } */
}
