using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/*
    stage1: 1 - teki1; 1 - teki2
    stage2: 2 - teki1; 1 - teki2
    stage3: 2 - teki1; 2 - teki2: speed up
    stage4: 3 - teki1; 2 - teki2: speed up
    stage5: 3 - teki1: speed up; 3 - teki2: speed up up
 */


public class StageControl : MonoBehaviour
{
    private int stage;
    public int liveteki;
    //计时器
    private float lastTime;
    private float curTime;
    public float gapTime;

    //敌人
    public GameObject TankTeki1;
    public GameObject TankTeki2;

    //实例化后的敌人
    private List<GameObject> Teki1;
    private List<GameObject> Teki2;

    //获取玩家
    private GameObject playerObject;

    void Start()
    {
        stage = liveteki = 0;
        curTime = Time.time;
        lastTime = curTime - gapTime + 1;
        playerObject = GameObject.Find("Tank1");
    }

    // Update is called once per frame
    void Update()
    {
        curTime = Time.time;
        if (curTime - lastTime < gapTime || liveteki != 0)
            return;
        lastTime = Time.time;
        stage ++;

        if (stage == 1)
        {
            liveteki += 2;

            Vector3 randomPosition = new Vector3(Random.Range(-25, 25), 0, Random.Range(-25, 25));
            GameObject teki11 = GameObject.Instantiate(TankTeki1, randomPosition, playerObject.transform.rotation) as GameObject;
            //Teki1.Add(teki11);

            randomPosition = new Vector3(Random.Range(-25, 25), 0, Random.Range(-25, 25));
            GameObject teki21 = GameObject.Instantiate(TankTeki2, randomPosition, playerObject.transform.rotation) as GameObject;
            //Teki2.Add(teki21);
        }
        else if (stage == 2)
        {
            liveteki += 3;

            Vector3 randomPosition = new Vector3(Random.Range(-25, 25), 0, Random.Range(-25, 25));
            GameObject teki11 = GameObject.Instantiate(TankTeki1, randomPosition, playerObject.transform.rotation) as GameObject;

            randomPosition = new Vector3(Random.Range(-25, 25), 0, Random.Range(-25, 25));
            GameObject teki12 = GameObject.Instantiate(TankTeki1, randomPosition, playerObject.transform.rotation) as GameObject;

            randomPosition = new Vector3(Random.Range(-25, 25), 0, Random.Range(-25, 25));
            GameObject teki21 = GameObject.Instantiate(TankTeki2, randomPosition, playerObject.transform.rotation) as GameObject;
        }
        else if (stage == 3)
        {
            liveteki += 4;

            Vector3 randomPosition = new Vector3(Random.Range(-25, 25), 0, Random.Range(-25, 25));
            GameObject teki11 = GameObject.Instantiate(TankTeki1, randomPosition, playerObject.transform.rotation) as GameObject;

            randomPosition = new Vector3(Random.Range(-25, 25), 0, Random.Range(-25, 25));
            GameObject teki12 = GameObject.Instantiate(TankTeki1, randomPosition, playerObject.transform.rotation) as GameObject;

            randomPosition = new Vector3(Random.Range(-25, 25), 0, Random.Range(-25, 25));
            GameObject teki21 = GameObject.Instantiate(TankTeki2, randomPosition, playerObject.transform.rotation) as GameObject;
            teki21.GetComponent<NavMeshAgent>().speed += 5;
            teki21.GetComponent<NavMeshAgent>().acceleration += 5;
            teki21.GetComponent<TankAttack2>().attackgapTime -= 0.2f;

            randomPosition = new Vector3(Random.Range(-25, 25), 0, Random.Range(-25, 25));
            GameObject teki22 = GameObject.Instantiate(TankTeki2, randomPosition, playerObject.transform.rotation) as GameObject;
            teki22.GetComponent<NavMeshAgent>().speed += 5;
            teki22.GetComponent<NavMeshAgent>().acceleration += 5;
            teki22.GetComponent<TankAttack2>().attackgapTime -= 0.2f;
        }
        else if (stage == 4)
        {
            liveteki += 5;

            Vector3 randomPosition = new Vector3(Random.Range(-25, 25), 0, Random.Range(-25, 25));
            GameObject teki11 = GameObject.Instantiate(TankTeki1, randomPosition, playerObject.transform.rotation) as GameObject;

            randomPosition = new Vector3(Random.Range(-25, 25), 0, Random.Range(-25, 25));
            GameObject teki12 = GameObject.Instantiate(TankTeki1, randomPosition, playerObject.transform.rotation) as GameObject;

            randomPosition = new Vector3(Random.Range(-25, 25), 0, Random.Range(-25, 25));
            GameObject teki13 = GameObject.Instantiate(TankTeki1, randomPosition, playerObject.transform.rotation) as GameObject;

            randomPosition = new Vector3(Random.Range(-25, 25), 0, Random.Range(-25, 25));
            GameObject teki21 = GameObject.Instantiate(TankTeki2, randomPosition, playerObject.transform.rotation) as GameObject;
            teki21.GetComponent<NavMeshAgent>().speed += 5;
            teki21.GetComponent<NavMeshAgent>().acceleration += 5;
            teki21.GetComponent<TankAttack2>().attackgapTime -= 0.2f;

            randomPosition = new Vector3(Random.Range(-25, 25), 0, Random.Range(-25, 25));
            GameObject teki22 = GameObject.Instantiate(TankTeki2, randomPosition, playerObject.transform.rotation) as GameObject;
            teki22.GetComponent<NavMeshAgent>().speed += 5;
            teki22.GetComponent<NavMeshAgent>().acceleration += 5;
            teki22.GetComponent<TankAttack2>().attackgapTime -= 0.2f;
        }
        else if (stage == 5)
        {
            liveteki += 6;

            Vector3 randomPosition = new Vector3(Random.Range(-25, 25), 0, Random.Range(-25, 25));
            GameObject teki11 = GameObject.Instantiate(TankTeki1, randomPosition, playerObject.transform.rotation) as GameObject;

            randomPosition = new Vector3(Random.Range(-25, 25), 0, Random.Range(-25, 25));
            GameObject teki12 = GameObject.Instantiate(TankTeki1, randomPosition, playerObject.transform.rotation) as GameObject;

            randomPosition = new Vector3(Random.Range(-25, 25), 0, Random.Range(-25, 25));
            GameObject teki13 = GameObject.Instantiate(TankTeki1, randomPosition, playerObject.transform.rotation) as GameObject;

            randomPosition = new Vector3(Random.Range(-25, 25), 0, Random.Range(-25, 25));
            GameObject teki21 = GameObject.Instantiate(TankTeki2, randomPosition, playerObject.transform.rotation) as GameObject;
            teki21.GetComponent<NavMeshAgent>().speed += 10;
            teki21.GetComponent<NavMeshAgent>().acceleration += 10;
            teki21.GetComponent<TankAttack2>().attackgapTime -= 0.4f;

            randomPosition = new Vector3(Random.Range(-25, 25), 0, Random.Range(-25, 25));
            GameObject teki22 = GameObject.Instantiate(TankTeki2, randomPosition, playerObject.transform.rotation) as GameObject;
            teki22.GetComponent<NavMeshAgent>().speed += 10;
            teki22.GetComponent<NavMeshAgent>().acceleration += 10;
            teki22.GetComponent<TankAttack2>().attackgapTime -= 0.4f;

            randomPosition = new Vector3(Random.Range(-25, 25), 0, Random.Range(-25, 25));
            GameObject teki23 = GameObject.Instantiate(TankTeki2, randomPosition, playerObject.transform.rotation) as GameObject;
            teki23.GetComponent<NavMeshAgent>().speed += 10;
            teki23.GetComponent<NavMeshAgent>().acceleration += 10;
            teki23.GetComponent<TankAttack2>().attackgapTime -= 0.4f;
        }
        else 
        {
            Debug.Log("Game Over!");
        }
    }
}
