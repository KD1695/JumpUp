using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LedgeSpawner : MonoBehaviour
{
    [SerializeField] Ledge ledgePrefab;
    [SerializeField] RectTransform parent;
    [SerializeField] Transform finish;
    [SerializeField] GameState gameState;

    [SerializeField] private List<Ledge> ledgePool = new List<Ledge>();

    void Start()
    {
        
    }

    private void Update()
    {
        foreach(var ledgeObj in ledgePool)
        {
            if(ledgeObj.transform.position.y < finish.position.y)
            {
                ledgeObj.SetIsTaken(false);
            }
        }
    }

    public void GenerateLedge(int currentFloor)
    {
        Ledge ledgeObject;
        float width = Random.Range(20, 75);

        Vector3 position = new Vector3(Random.Range((parent.rect.xMin + width / 2), (parent.rect.xMax - width / 2)), 0, 0);
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
        ledgeObject.SetParent(this);
        ledgeObject.SetIsTaken(true);
        ledgeObject.SetWidth(width);

        ledgeObject.gameObject.SetActive(true);
    }

    public float LedgeSpeed()
    {
        return gameState.GetSpeed();
    }
}
