using UnityEngine;

[System.Serializable]

public class Item
{
    public string name;
    public int attack;
    public Sprite sprite;
    public float percent;
}

[CreateAssetMenu(fileName = "ItemSO", menuName = "Scriptable Object/ItemSO")]
public class ItemSO : ScriptableObject
{
    public Item[] items;
}
