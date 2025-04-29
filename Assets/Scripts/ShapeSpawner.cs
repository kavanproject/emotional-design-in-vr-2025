using UnityEngine;

public class ShapeSpawner : MonoBehaviour
{
    public GameObject shapeone;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()

    {
        
    }

    public void Spawnshapeone()
    {
      Instantiate(shapeone);
    }
}
