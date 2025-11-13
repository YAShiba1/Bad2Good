using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Object/Item")]
public class Item : ScriptableObject
{
    [Header("Only gameplay")]
    public Sprite Sprite;
    public Vector2Int range = new(5, 4);

    [Header("Only UI")]
    public bool _stackable = true;
}
