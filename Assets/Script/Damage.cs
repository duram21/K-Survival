using UnityEngine;
using TMPro;
using DG.Tweening;

public class Damage : MonoBehaviour
{
    [SerializeField] TMP_Text damageTMP;
    Transform tr;

    public void SetupTransform(Vector3 pos, Transform tr)
    {
        this.tr = tr;
        tr.position = pos;
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tr = transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(tr != null)
            transform.position = tr.position;
    }

    public void Damaged(int damage)
    {
        if(damage <= 0)
            return;
        
        GetComponent<Order>().SetOrder(1000);
        damageTMP.text = $"-{damage}";

        Sequence sequence = DOTween.Sequence()
            .Append(transform.DOScale(Vector3.one * 1.3f, 0.5f).SetEase(Ease.InOutBack))
            // .AppendInterval(0.3f)
            .Append(transform.DOScale(Vector3.zero, 0.5f).SetEase(Ease.InOutBack))
            .OnComplete(() => Destroy(gameObject));
    }
}
