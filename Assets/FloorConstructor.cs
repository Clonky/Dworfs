using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorConstructor : MonoBehaviour
{
    public Sprite GroundTile;
    public Material GroundMaterial;
    public float WidthPerTile;
    // Start is called before the first frame update
    void Start()
    {
        int counterx = -10;
        int countery = -10;
        int end = 10;
        while (countery < end)
        {
            while (counterx < end)
            {
                Vector2 pos = new Vector2(counterx * WidthPerTile, countery * WidthPerTile);
                CreateFloorTile(pos);
                counterx += 1;
            }
            countery += 1;
            counterx = -10;
        }
    }

    void CreateFloorTile(Vector2 position)
    {
        int angle = Random.Range(0, 3);
        GameObject floorTile = new GameObject(position.ToString());
        floorTile.transform.SetParent(this.transform);
        floorTile.transform.localPosition = position;
        floorTile.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, angle * 90f));
        floorTile.AddComponent<SpriteRenderer>();
        floorTile.GetComponent<SpriteRenderer>().sprite = GroundTile;
        floorTile.GetComponent<SpriteRenderer>().material = GroundMaterial;
    }
}
