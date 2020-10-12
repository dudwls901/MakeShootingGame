using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    private MeshRenderer render;

    public float speed;
    private float offset;
    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))//마우스 클릭 받아옴
        {
            SceneManager.LoadScene("GameScene"); //게임씬 로드
        }

        offset += Time.deltaTime * speed;
        render.material.mainTextureOffset = new Vector2(0,offset);
    }
}
