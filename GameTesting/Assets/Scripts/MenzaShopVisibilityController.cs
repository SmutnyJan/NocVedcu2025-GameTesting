using UnityEngine;

public class MenzaShopVisibilityController : MonoBehaviour
{
    public Canvas MenzaShopCanvas;
    void Start()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        MenzaShopCanvas.enabled = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        MenzaShopCanvas.enabled = false;
    }
}
