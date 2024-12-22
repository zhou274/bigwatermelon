using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fruit : MonoBehaviour
{

    //等级
    public int level;
    //是否第一次触发
    private bool isFirstTrigger = true;

    private void Start()
    {
        Debug.Log(gameObject.GetInstanceID());
    }

    //如果碰撞执行
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Floor" && Mathf.Abs(this.gameObject.GetComponent<Rigidbody2D>().velocity.y) > 0.2f)
        {
            AudioManager.Instace.PlayAudio(AudioManager.Instace.audioClips[1]);
        }
        if (PlayerManager.Instance.readyFruit != this.gameObject && collision.gameObject.tag == "Fruit")
        {
            if (this.level == collision.gameObject.GetComponent<Fruit>().level)
            {
                //如果我的示例ID大于对方的
                if (this.gameObject.GetInstanceID() > collision.gameObject.GetInstanceID())
                {
                    //合成
                    //获取比我高一级别的水果
                    GameObject prefab = PlayerManager.Instance.fruitPrefabs[level];
                    GameObject fruit = Instantiate(prefab);
                    fruit.transform.position = this.gameObject.transform.position;
                    UIManager.Instance.Score += this.level * 2;
                    AudioManager.Instace.PlayAudio(AudioManager.Instace.audioClips[0]);
                    Destroy(this.gameObject);
                    Destroy(collision.gameObject);
                }
            }
            else
            {
                if (Mathf.Abs(this.gameObject.GetComponent<Rigidbody2D>().velocity.y) > 0.2f)
                {
                    AudioManager.Instace.PlayAudio(AudioManager.Instace.audioClips[1]);
                }
            }
        }
    }

    //如果触发执行
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (isFirstTrigger == false && PlayerManager.Instance.readyFruit != this.gameObject && collision.gameObject.name == "DeadLine")
    //    {
    //        SceneManager.LoadSceneAsync("SampleScene");
    //    }
    //    else if (isFirstTrigger == true && collision.gameObject.name == "DeadLine")
    //    {
    //        isFirstTrigger = false;
    //    }
    //}
}
