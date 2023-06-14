using UnityEngine;

public class ImageSelection : MonoBehaviour
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

    private void OnMouseDown()
    {
        if (gameObject.layer == LayerMask.NameToLayer(expectedLayerName))
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







