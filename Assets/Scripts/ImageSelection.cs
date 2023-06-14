using UnityEngine;
using UnityEngine.EventSystems;

public class ImageSelection : MonoBehaviour, IPointerClickHandler
{
    public delegate void ImageSelected(GameObject image);
    public delegate void ImageDeselected(GameObject image);

    public event ImageSelected OnImageSelected;
    public event ImageDeselected OnImageDeselected;

    private bool isSelected;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (isSelected)
        {
            isSelected = false;
            OnImageDeselected?.Invoke(gameObject);
        }
        else
        {
            isSelected = true;
            OnImageSelected?.Invoke(gameObject);
        }
    }
}
