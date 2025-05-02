using UnityEngine;

public class Welcome_canvas : MonoBehaviour
{
    public GameObject canvasToDisable;

    public void DisableCanvas(){
        canvasToDisable.SetActive(false);
    }
}
