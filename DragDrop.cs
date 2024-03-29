using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour
{
    [HideInInspector]
    public Vector3 screenPoint;
    [HideInInspector]
    public Vector3 offset;
    [HideInInspector]
    public int cost;
    [HideInInspector]
    public bool follow = true;

    private void Update()
    {
        if (follow)
        {
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
            transform.position = curPosition;
            if (Input.GetMouseButtonUp(0))
            {
                follow = false;
                Data.coin -= cost;
                foreach (Behaviour childCompnent in GetComponentsInChildren<Behaviour>())
                childCompnent.enabled = true;
            }
            else
            {
                Destroy(gameObject);
                Debug.Log("Meletakkan area yang tidak di izinkan");
            }
        }
    }
}
