using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Image))]
public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private Item _item;

    private Transform _parentAfterDrag;
    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
        _image.sprite = _item.Sprite;
    }

    public void InitialiseItem(Item newItem)
    {
        _item = newItem;
        _image.sprite = newItem.Sprite;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _image.raycastTarget = false;
        _parentAfterDrag = transform.parent;
        transform.SetParent(_parentAfterDrag.root);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _image.raycastTarget = true;
        transform.SetParent(_parentAfterDrag);
    }

    public void SetParentAfterDrag(Transform parent)
    {
        _parentAfterDrag = parent;
    }
}
