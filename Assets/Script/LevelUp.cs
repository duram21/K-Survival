using UnityEngine;

public class LevelUp : MonoBehaviour
{
    RectTransform rect;
    Item2[] items;

    void Awake()
    {
        rect = GetComponent<RectTransform>();
        items = GetComponentsInChildren<Item2>(true);
    }

    public void Show()
    {
        rect.localScale = Vector3.one;
        GameManager.instance.Stop();
    }

    public void Hide()
    {
        rect.localScale = Vector3.zero;
        GameManager.instance.Resume();

    }

    public void Select(int index)
    {
        items[index].OnClick();
    }
}
