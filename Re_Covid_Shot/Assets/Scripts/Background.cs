using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{

    [SerializeField] MeshRenderer mesh;

    [SerializeField] float speed;
    float offset;

    private void Awake()
    {
        mesh = GetComponent<MeshRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        offset += Time.deltaTime * speed;
        mesh.material.mainTextureOffset = new Vector2(0, offset);
    }
}
