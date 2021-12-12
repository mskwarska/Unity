using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class zadanie1 : MonoBehaviour
{
    List<Vector3> positions = new List<Vector3>();
    public float delay = 3.0f;
    int objectCounter = 0;
    public List<Material> materials = new List<Material>();
    public GameObject block;

    void Start()
    {
       
        Renderer rendererBlock = block.GetComponent<Renderer>();
        Renderer renderer = GetComponent<Renderer>();
        List<int> pozycje_x = new List<int>(Enumerable.Range(0, Convert.ToInt32(renderer.bounds.size.x)).OrderBy(x => Guid.NewGuid()).Take(10));
        List<int> pozycje_z = new List<int>(Enumerable.Range(0, Convert.ToInt32(renderer.bounds.size.z)).OrderBy(x => Guid.NewGuid()).Take(10));

        for (int i = 0; i < 10; i++)
        {
            this.positions.Add(new Vector3(pozycje_x[i] + transform.position.x - Convert.ToInt32(renderer.bounds.size.x / 2) + +rendererBlock.bounds.size.x / 2, 0, pozycje_z[i] + transform.position.z - Convert.ToInt32(renderer.bounds.size.z / 2) + rendererBlock.bounds.size.z / 2));
        }
        System.Random random = new System.Random();
        rendererBlock.material = materials[random.Next(0, materials.Count)];

        // uruchamiamy coroutine
        StartCoroutine(GenerujObiekt());

    }

    void Update()
    {
        System.Random random = new System.Random();
        Renderer rendererBlock = block.GetComponent<Renderer>();
        rendererBlock.material = materials[random.Next(0, materials.Count)];
    }

    IEnumerator GenerujObiekt()
    {
        Debug.Log("wywołano coroutine");
        foreach (Vector3 pos in positions)
        {
            Instantiate(this.block, this.positions.ElementAt(this.objectCounter++), Quaternion.identity);
            yield return new WaitForSeconds(this.delay);
        }
        // zatrzymujemy coroutine
        StopCoroutine(GenerujObiekt());
    }
}