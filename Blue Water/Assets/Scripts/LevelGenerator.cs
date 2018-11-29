using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelGenerator : MonoBehaviour {

    public GameObject[] availableLevels;
    public List<GameObject> currentLevels;
    private float screenHeightInPoints;
    int currentLevelNumber;

    private void Start()
    {
        currentLevelNumber = 2;
        screenHeightInPoints = 2.0f * Camera.main.orthographicSize;
        StartCoroutine(GeneratorCheck());
    }

    void AddLevel(float farthestLevelEndY)
    {
        int randomLevelIndex = Random.Range(0, availableLevels.Length);
        GameObject level = (GameObject)Instantiate(availableLevels[randomLevelIndex]);
        float levelHeight = level.transform.Find("Background").localScale.y;
        float levelCenter = farthestLevelEndY + levelHeight * 0.5f;
        level.transform.position = new Vector3(0, levelCenter, 0);
        level.transform.Find("LevelUI").Find("LevelNumber").GetComponent<Text>().text = currentLevelNumber.ToString();
        currentLevelNumber++;
        currentLevels.Add(level);
    }
    private void GenerateLevelIfRequired()
    {
        List<GameObject> levelsToRemove = new List<GameObject>();
        bool addLevels = true;
        float playerY = transform.position.y;
        float removeLevelY = playerY - (screenHeightInPoints * 2.0f);
        float addLevelY = playerY + screenHeightInPoints;
        float farthestLevelEndY = 0;
        foreach (var level in currentLevels)
        {
            float levelHeight = level.transform.Find("Background").localScale.y;
            float levelStartY = level.transform.position.y - (levelHeight * 0.5f);
            float levelEndY = levelStartY + levelHeight;
            if (levelStartY > addLevelY)
            {
                addLevels = false;
            }
            if (levelEndY < removeLevelY)
            {
                levelsToRemove.Add(level);
            }
            farthestLevelEndY = Mathf.Max(farthestLevelEndY, levelEndY);
        }
        foreach (var room in levelsToRemove)
        {
            currentLevels.Remove(room);
            Destroy(room);
        }
        if (addLevels)
        {
            AddLevel(farthestLevelEndY);
        }
    }

    private IEnumerator GeneratorCheck()
    {
        while (true)
        {
            GenerateLevelIfRequired();
            yield return new WaitForSeconds(0.25f);
        }
    }
}
