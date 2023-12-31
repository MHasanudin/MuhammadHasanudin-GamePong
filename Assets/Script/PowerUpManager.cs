using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class PowerUpManager : MonoBehaviour
{
    [Header("Amount & Interval waktu spawn")]
    public int maxPUAmount;
    public int spawnInterval;

    [Header("Area Spawn Power Up")]
    public Transform spawnArea;
    public Vector2 powerUpAreaMin;
    public Vector2 powerUpAreaMax;

    [Header("Notification Power Up")]
    public GameObject uiRightSpeed;
    public TextMeshProUGUI txtRightSpeed;

    public GameObject uiRightExtend;
    public TextMeshProUGUI txtRightExtend;

    public GameObject uiLeftSpeed;
    public TextMeshProUGUI txtLeftSpeed;

    public GameObject uiLeftExtend;
    public TextMeshProUGUI txtLeftExtend;

    public List<GameObject> PUTemplateList;

    private List<GameObject> powerUpList;

    private float timer;

    private void Start()
    {
        powerUpList = new List<GameObject>();
        timer = 0;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if(timer > spawnInterval)
        {
            GenerateRandomPU();
            timer -= spawnInterval;
        }
    }

    public void GenerateRandomPU()
    {
        GenerateRandomPU(new Vector2(Random.Range(powerUpAreaMin.x, powerUpAreaMax.x), Random.Range(powerUpAreaMin.y, powerUpAreaMax.y)));
    }

    public void GenerateRandomPU(Vector2 position)
    {
        if(powerUpList.Count >= maxPUAmount)
        {
            RemovePU(powerUpList[0]);
        }

        if (position.x < powerUpAreaMin.x || position.x > powerUpAreaMax.x ||
            position.y < powerUpAreaMin.y || position.y > powerUpAreaMax.y)
        {
            return;
        }

        int randomIndex = Random.Range(0, PUTemplateList.Count);

        GameObject powerUp = Instantiate(PUTemplateList[randomIndex], new Vector3(position.x, position.y, PUTemplateList[randomIndex].transform.position.z), Quaternion.identity, spawnArea);
        powerUp.SetActive(true);

        powerUpList.Add(powerUp);
    }

    public void RemovePU(GameObject powerUp)
    {
        powerUpList.Remove(powerUp);
        Destroy(powerUp);
    }

    public void RemoveAllPU()
    {
        while (powerUpList.Count > 0)
        {
            RemovePU(powerUpList[0]);
        }
    }
}
