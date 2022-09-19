using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ledge : MonoBehaviour
{
    float speed = 0.0f;
    bool isTaken = false;

    [SerializeField] BoxCollider topCollider;
    [SerializeField] BoxCollider botCollider;

    void Start()
    {
        
    }

    void Update()
    {
        var step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y-300, 0), step);
    }

    public void SetWidth(float width)
    {
        float height = this.GetComponent<RectTransform>().sizeDelta.y;
        this.GetComponent<RectTransform>().sizeDelta = new Vector2(width, height);
        topCollider.size = new Vector3(width, height / 2);
        botCollider.size = new Vector3(width, height / 2);
    }

    public void SetSpeed(float _speed)
    {
        speed = _speed;
    }

    public void SetIsTaken(bool _isTaken)
    {
        isTaken = _isTaken;
    }
    public bool IsTaken()
    {
        return isTaken;
    }
}
