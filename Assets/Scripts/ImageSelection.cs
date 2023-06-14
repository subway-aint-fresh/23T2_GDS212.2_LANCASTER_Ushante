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

    public string expectedLayerName = "CorrectImage"; // Name of the expected correct image layer

    private void Start()
    {
        gameManager = GameManager.Instance;
        IsSelected = false; // Initialize selection state to false
    }

        public void OnPointerClick(PointerEventData eventData)
    {
        Camera mainCamera = Camera.main;
        if (mainCamera != null)
        {
            RaycastHit2D hit = Physics2D.Raycast(mainCamera.ScreenToWorldPoint(eventData.position), Vector2.zero);

            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                if (LayerMask.LayerToName(hit.collider.gameObject.layer) == expectedLayerName)
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
        else
        {
            Debug.Log("No main camera found!");
        }
    }

}






