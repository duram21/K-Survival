using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Order", menuName = "Scriptable Objects/Order")]
public class Order : MonoBehaviour
{
    [SerializeField] Graphic[] backGraphics;
    [SerializeField] Graphic[] middleGraphics;
    [SerializeField] string sortingLayerName;
    int originOrder;

    private Canvas canvas;

    void Awake()
    {
        canvas = GetComponentInParent<Canvas>();   
    }



    public void SetOriginOrder(int originOrder)
  {
    this.originOrder = originOrder;
    SetOrder(originOrder);
  }

  public void SetMostFrontOrder(bool isMostFront){
    SetOrder(isMostFront ? 100 : originOrder);
  }
  public void SetOrder(int order)
    {
      int mulOrder = order * 10;

      foreach (var graphic in backGraphics){
        canvas.sortingLayerName = sortingLayerName;
        canvas.sortingOrder = mulOrder;
      }

      foreach ( var renderer in middleGraphics)
      {
        canvas.sortingLayerName = sortingLayerName;
        canvas.sortingOrder = mulOrder + 1;
      }
    }


}
