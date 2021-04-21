using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinchZoom : MonoBehaviour
{
    [SerializeField] private float zoomSpeed = 5;
    [SerializeField] private GameObject[] uis;

    private Vector3[] uisScale;

    // Start is called before the first frame update
    void Awake()
    {
        uisScale = new Vector3[uis.Length];

        for (int i = 0; i < uisScale.Length; i++)
        {
            uisScale[i] = uis[i].transform.localScale;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 2)
        {
            Touch tZero = Input.GetTouch(0);
            Touch tOne = Input.GetTouch(1);

            Vector2 tZeroPrevious = tZero.position - tZero.deltaPosition;
            Vector2 tOnePrevious = tOne.position - tOne.deltaPosition;

            float oldTouchDistance = Vector2.Distance(tZeroPrevious, tOnePrevious);
            float currentDistance = Vector2.Distance(tZero.position, tOne.position);

            float deltaDistance = oldTouchDistance - currentDistance;

            Zoom(deltaDistance, zoomSpeed, true);
        }
        else
        {
            Zoom(0, zoomSpeed, false);
        }
    }

    private void Zoom(float deltaDistance, float speed, bool zoomIn)
    {
        float scaleFactor = deltaDistance * speed;
        Vector3 newScale;

        if (zoomIn)
        {
            for (int i = 0; i < uis.Length; i++)
            {
                newScale = new Vector3(uis[i].transform.localScale.x + scaleFactor, uis[i].transform.localScale.y + scaleFactor, uis[i].transform.localScale.z + scaleFactor);
                uis[i].transform.localScale = newScale;
            }
        }
        else
        {
            for (int i = 0; i < uis.Length; i++)
            {
                uis[i].transform.localScale = uisScale[i];
            }
        }
    }
}
