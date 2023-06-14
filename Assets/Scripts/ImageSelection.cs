using UnityEngine;
using UnityEngine.EventSystems;

public class ImageSelection : MonoBehaviour, IPointerClickHandler
{
    public delegate void ImageSelected(GameObject image);
    public delegate void ImageDeselected(GameObject image);

    public event ImageSelected OnImageSelected;
    public event ImageDeselected OnImageDeselected;

    private GameManager gameManager; // Reference to the GameManager script

    private bool isSelected;
    private int expectedLayer = 6; // Layer index of the expected correct image layer

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(eventData.position), Vector2.zero);

        if (hit.collider != null && hit.collider.gameObject == gameObject)
        {
            if (hit.collider.gameObject.layer == expectedLayer)
            {
                isSelected = !isSelected;

                if (isSelected)
                {
                    OnImageSelected?.Invoke(gameObject);
                    Debug.Log("image selected");
                }
                else
                {
                    OnImageDeselected?.Invoke(gameObject);
                    Debug.Log("image unselected");
                }

                gameManager.CheckImageSelections(); // Call the method in the GameManager to check selected images
            }
        }
    }
}


