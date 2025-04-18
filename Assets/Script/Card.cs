using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;

public class Card : MonoBehaviour
{
    [SerializeField] Image card;
    [SerializeField] Image character;
    [SerializeField] TMP_Text nameTMP;
    [SerializeField] TMP_Text attackTMP;

    public Item item;
    public PRS originPRS;

    RectTransform rectTransform;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();   
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
}
