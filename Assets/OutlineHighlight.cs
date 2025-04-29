using UnityEngine;

public class OutlineHighlight : MonoBehaviour
{
    [SerializeField] private Color outlineColor = Color.yellow;
    [SerializeField] private float outlineWidth = 5f;
    
    private Renderer meshRenderer;
    private Material originalMaterial;
    private Material outlineMaterial;
    private bool isHovering = false;
    
    void Start()
{
    // Get the renderer component from your mesh
    meshRenderer = GetComponent<Renderer>();
    
    // Store the original material
    originalMaterial = meshRenderer.material;
    
    // Create the outline material
    outlineMaterial = new Material(Shader.Find("Custom/Outline"));
    outlineMaterial.SetColor("_OutlineColor", outlineColor);
    outlineMaterial.SetFloat("_OutlineWidth", outlineWidth / 100f);
}

// Remove the SetupOutlineMaterial method as we're now setting properties directly
    
    void OnMouseEnter()
    {
        isHovering = true;
        ApplyOutlineMaterial();
    }
    
    void OnMouseExit()
    {
        isHovering = false;
        RemoveOutlineMaterial();
    }
    
    void ApplyOutlineMaterial()
    {
        // Create a materials array with both original and outline materials
        Material[] materials = new Material[2];
        materials[0] = originalMaterial;
        materials[1] = outlineMaterial;
        
        // Apply both materials
        meshRenderer.materials = materials;
    }
    
    void RemoveOutlineMaterial()
    {
        // Restore original material
        meshRenderer.material = originalMaterial;
    }
}