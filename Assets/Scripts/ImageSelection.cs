using UnityEngine;
using UnityEngine.EventSystems;

public class ImageSelection : MonoBehaviour, IPointerClickHandler
{
    public delegate void ImageSelected(GameObject image);
    public delegate void ImageDeselected(GameObject image);

    public event ImageSelected OnImageSelected;
    public event ImageDeselected OnImageDeselected;

    private bool isSelected;
    private GameManager gameManager;

    private void Start()
    {
        // Get a reference to the GameManager script
        gameManager = FindObjectOfType<GameManager>();
    }

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

        // Call a method in the GameManager to check the image selections
        gameManager.CheckImageSelections();
    }
}

