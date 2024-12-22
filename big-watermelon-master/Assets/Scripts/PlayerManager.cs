using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    //设置单例模式
    public static PlayerManager Instance;
    //水果预制体数组
    public GameObject[] fruitPrefabs;
    //准备水果的位置
    public Transform createFruitPoint;
    //准备中的水果
    public GameObject readyFruit;

    //游戏时间
    public  float time;
    public float PlayTimeTotal=60;

    //游戏结束界面
    public GameObject GameOverPanel;

    public bool isGameOver = false;
    

    private void Awake()
    {
        time = PlayTimeTotal;
        Instance = this;
    }
    void Start()
    {
        CreateFruit();
    }

    void Update()
    {
        if(isGameOver==false)
        {
            time -= Time.deltaTime;
            if (time < 0)
            {
                isGameOver = true;
                GameOverPanel.SetActive(true);
            }
            if (readyFruit == null)
            {
                return;
            }
            if (Input.GetMouseButton(0))
            {
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector3 newPos = new Vector3(mousePos.x, readyFruit.transform.position.y, readyFruit.transform.position.z);

                float maxX = 2.8f - readyFruit.GetComponent<CircleCollider2D>().radius;
                float minX = -2.8f + readyFruit.GetComponent<CircleCollider2D>().radius;
                if (newPos.x > maxX)
                {
                    newPos.x = maxX;
                }
                else if (newPos.x < minX)
                {
                    newPos.x = minX;
                }
                readyFruit.transform.position = newPos;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                readyFruit.GetComponent<Rigidbody2D>().gravityScale = 1;
                Invoke("CreateFruit", 0.8f);
                readyFruit = null;
            }
        }
        

    }

    /// <summary>
    /// 创建水果
    /// </summary>
    public void CreateFruit()
    {
        //随机一个索引
        int index = Random.Range(0, 4);
        GameObject prefab = fruitPrefabs[index];
        readyFruit = Instantiate(prefab);
        readyFruit.transform.position = createFruitPoint.position;
        readyFruit.GetComponent<Rigidbody2D>().gravityScale = 0;
    }
}
