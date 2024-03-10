using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    Rigidbody2D veggie;
    [SerializeField] float dropForce = 5f;
    [SerializeField] float dropY;
    public GameObject[] vegetables;
    private void Start()
    {
        veggie = GetComponent<Rigidbody2D>();
        veggie.constraints = RigidbodyConstraints2D.FreezeAll;
        SpawnVegetable();

    }
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            DropVegetable();
        }
    }
    private void DropVegetable()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        transform.position = new Vector3(mousePos.x, dropY, 0);
        veggie.constraints = RigidbodyConstraints2D.None;
        veggie.gravityScale = 1f;
        veggie.AddForce(Vector2.down * dropForce, ForceMode2D.Impulse);
        
    }
    void SpawnVegetable()
    {
        int randomVeg = Random.Range(0, 5);
        Instantiate(vegetables[randomVeg], new Vector3(0f, dropY, 0f), Quaternion.identity);
    }
}
