using UnityEngine;

public class GridPopulator : MonoBehaviour
{
    public GameObject container;
    public GameObject[] imagePrefabs;

    private GameObject selectedImage;

    private void Start()
    {
        PopulateGrid();
    }

    private void PopulateGrid()
    {
        int index = 0;
        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 3; col++)
            {
                Vector3 position = new Vector3(col * 2, row * -2, 0); //I have to adjust this

                GameObject imageObj = Instantiate(imagePrefabs[index], position, Quaternion.identity, container.transform);
                index = (index + 1) % imagePrefabs.Length; // Cycle through the image prefabs

                // Add a script to the image object to handle selection
                ImageSelection imageSelection = imageObj.AddComponent<ImageSelection>();
                imageSelection.OnImageSelected += OnImageSelected;
                imageSelection.OnImageDeselected += OnImageDeselected;

                // I need to customize the image object (e.g., set sprite, adjust size) 
            }
        }
    }

    private void OnImageSelected(GameObject image)
    {
        // Handle the selected image
        selectedImage = image;
        Debug.Log("Image selected: " + image.name);
    }

    private void OnImageDeselected(GameObject image)
    {
        // Handle the deselected image
        if (selectedImage == image)
        {
            selectedImage = null;
            Debug.Log("Image deselected: " + image.name);
        }
    }
}

