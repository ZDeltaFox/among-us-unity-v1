using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SwipeCard : MonoBehaviour, IDragHandler
{
    private Canvas _canvas;

    float LatePosX;
    float LatePosY;
    float PosX;
    float PosY;

    public float xMetrosPorSegundo;
    public static float xMS;
    public float yMetrosPorSegundo;
    public static float yMS;

    public static float timer = 0.1f;

    private void Awake()
    {
        _canvas = GetComponentInParent<Canvas>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 pos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            _canvas.transform as RectTransform, 
            eventData.position, 
            _canvas.worldCamera, 
            out pos);
        transform.position = _canvas.transform.TransformPoint(pos);
    }

    void Update()
    {
        timer += Time.deltaTime;
        PosX = gameObject.transform.position.x;
        PosY = gameObject.transform.position.y;

        if (timer >= 0.1)
        {
            LatePosX = PosX;
            LatePosY = PosY;
        }

        xMetrosPorSegundo = -(LatePosX - PosX);
        yMetrosPorSegundo = -(LatePosY - PosY);
        xMS = xMetrosPorSegundo;
        yMS = yMetrosPorSegundo;
    }

    void Start() 
    {
        timer = 0.1f;
    }
}
