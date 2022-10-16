using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ledge : MonoBehaviour
{
    [SerializeField] bool isTaken = false;
    [SerializeField] BoxCollider topCollider;
    [SerializeField] GameObject health;

    void Start()
    {
        SetWidth(this.GetComponent<RectTransform>().sizeDelta.x);
    }

    void Update()
    {
        if(isTaken)
        {
            var step = GameState.Instance.GetSpeed() * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y-300, 0), step);
        }
    }

    public void SetWidth(float width)
    {
        float height = this.GetComponent<RectTransform>().sizeDelta.y;
        this.GetComponent<RectTransform>().sizeDelta = new Vector2(width, height);
        topCollider.size = new Vector3(width, height);
    }

    public void SetIsTaken(bool _isTaken)
    {
        isTaken = _isTaken;
        if (Random.Range(0, 10) < 2 && _isTaken)
            health.SetActive(_isTaken);
        else
            health.SetActive(false);
        this.gameObject.SetActive(_isTaken);
    }
    public bool IsTaken()
    {
        return isTaken;
    }
}
