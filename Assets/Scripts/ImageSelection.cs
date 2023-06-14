using UnityEngine;
using UnityEngine.EventSystems;

public class ImageSelection : MonoBehaviour, IPointerClickHandler
{
    public delegate void ImageSelected(GameObject image);
    public delegate void ImageDeselected(GameObject image);

    public event ImageSelected OnImageSelected;
    public event ImageDeselected OnImageDeselected;

    private GameManager gameManager; // Reference to the GameManager script

    public bool IsSelected { get; private set; } // Property to track selection state

    private int expectedLayer = 7; // Layer index of the expected correct image layer

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        IsSelected = false; // Initialize selection state to false
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(eventData.position), Vector2.zero);

        if (hit.collider != null && hit.collider.gameObject == gameObject)
        {
            if (hit.collider.gameObject.layer == expectedLayer)
            {
                IsSelected = !IsSelected;

                if (IsSelected)
                {
                    OnImageSelected?.Invoke(gameObject);
                    Debug.Log("Image selected");
                }
                else
                {
                    OnImageDeselected?.Invoke(gameObject);
                    Debug.Log("Image deselected");
                }

                gameManager.CheckImageSelections(); // Call the method in the GameManager to check selected images
            }
        }
    }
}



