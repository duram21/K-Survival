using UnityEngine;

[System.Serializable]
public class PRS
{
  public Vector3 pos;
  public Quaternion rot;
  public Vector3 scale;

  public PRS (Vector3 pos, Quaternion rot, Vector3 scale){
    this.pos = pos;
    this.rot = rot;
    this.scale = scale;
  }
}

[System.Serializable]
public class UIPRS
{
  public Vector3 pos;
  public Quaternion rot;
  public Vector3 scale;

  public UIPRS (Vector3 pos, Quaternion rot, Vector3 scale){
    this.pos = pos;
    this.rot = rot;
    this.scale = scale;
  }
}


public class Utils : MonoBehaviour
{
    [SerializeField] public static RectTransform canvasRectTransform;
    public static Quaternion QI => Quaternion.identity;

    void Awake()
    {
        if (canvasRectTransform == null)
        {
            canvasRectTransform = GameObject.Find("Canvas").GetComponent<RectTransform>();
        }
    }


    public static Vector3 MousePos
    {
        get
        {
            Vector3 result = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            result.z = -10;
            return result;
        }
    }

    public static Vector3 UIMousePos()
    {
        if (canvasRectTransform == null)
        {
            canvasRectTransform = GameObject.Find("Canvas").GetComponent<RectTransform>();
        }

        Vector2 result;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRectTransform, Input.mousePosition, null, out result);
        return result;
    }
}
