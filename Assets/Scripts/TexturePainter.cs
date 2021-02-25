using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TexturePainter : MonoBehaviour
{
    [SerializeField] private GameObject brushCursor, brushContainer, BrushEntity; 
    [SerializeField] private Camera sceneCamera, canvasCam;  
    [SerializeField] private Material baseMaterial; 
    [SerializeField] private float brushSize = 1.0f; 
    [SerializeField] private Color brushColor;
    [SerializeField] private RenderTexture wallTexture;

    void Update()
    {
        if (GameManager.Instance.gameState != GameManager.GameState.Paint)
            return;

        if (Input.GetMouseButton(0))
        {
            SetBrush();
        }

        UpdateBrush();
    }

    private void SetBrush()
    {
        Vector3 uvWorldPosition = Vector3.zero;
        if (CheckPosBrush(ref uvWorldPosition))
        {
            GameObject brushObj;
            brushObj = Instantiate(BrushEntity);
            brushObj.GetComponent<SpriteRenderer>().color = brushColor; 
            brushObj.transform.parent = brushContainer.transform;
            brushObj.transform.localPosition = uvWorldPosition; 
            brushObj.transform.localScale = Vector3.one * brushSize;
        }
    }

    void UpdateBrush()
    {
        Vector3 uvWorldPosition = Vector3.zero;
        if (CheckPosBrush(ref uvWorldPosition))
        {
            brushCursor.SetActive(true);
            brushCursor.transform.position = uvWorldPosition + brushContainer.transform.position;
        }
        else
        {
            brushCursor.SetActive(false);
        }
    }

    bool CheckPosBrush(ref Vector3 uvWorldPosition)
    {
        RaycastHit hit;
        Vector3 cursorPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0.0f);
        Ray cursorRay = sceneCamera.ScreenPointToRay(cursorPos);
        if (Physics.Raycast(cursorRay, out hit, 200))
        {
            MeshCollider meshCollider = hit.collider as MeshCollider;
            if (meshCollider == null || meshCollider.sharedMesh == null)
                return false;

            Vector2 pixelUV = new Vector2(hit.textureCoord.x, hit.textureCoord.y);
            uvWorldPosition.x = pixelUV.x - canvasCam.orthographicSize;
            uvWorldPosition.y = pixelUV.y - canvasCam.orthographicSize;
            uvWorldPosition.z = 0.0f;
            return true;
        }
        else
        {
            return false;
        }

    }
}
