using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LedgeSpawner : MonoBehaviour
{
    [SerializeField] Ledge ledgePrefab;
    [SerializeField] RectTransform parent;

    private List<Ledge> ledgePool = new List<Ledge>();

    void Start()
    {
        
    }

    private void Update()
    {

    }

    public void AddToPool(Ledge ledgeObject)
    {
        ledgePool.Add(ledgeObject);
    }

    public void GenerateLedge(int currentFloor)
    {
        Ledge ledgeObject;
        float width = 0.0f;
        if (currentFloor % 10 == 0)
        {
            width = parent.rect.xMax;
        }
        else
        {
            width = Random.Range(20, 50);
        }

        Vector3 position = new Vector3(Random.Range((parent.rect.xMin + width / 2), (parent.rect.xMax - width / 2)), parent.position.y, 0);
        if (ledgePool.Any(_ => !_.IsTaken()))
        {
            ledgeObject = ledgePool.FirstOrDefault(_ => !_.IsTaken());
        }
        else
        {
            ledgeObject = GameObject.Instantiate<Ledge>(ledgePrefab, position, Quaternion.identity, parent);
            ledgePool.Add(ledgeObject);
        }
        ledgeObject.transform.localPosition = position;
        ledgeObject.gameObject.SetActive(false);
        ledgeObject.SetIsTaken(true);
        ledgeObject.SetSpeed(GameState.Instance.GetSpeed());
        ledgeObject.SetWidth(width);

        ledgeObject.gameObject.SetActive(true);
    }
}
