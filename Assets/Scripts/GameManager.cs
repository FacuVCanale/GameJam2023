using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get; private set; }
    // Start is called before the first frame update
    [SerializeField] private float initialScrollSpeed;
    private float scrollSpeed;
    private float timer;
    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    // Update is called once per frame
    void Update()
    {
        UpdateSpeed();
        UpdateTime();
    }

    private void UpdateTime()
    {
        timer += Time.deltaTime;
    }

    public float GetScrollSpeed()
    {
        return scrollSpeed;
    }

    public void EraseHype()
    {
        timer = 0f;
    }

    private void UpdateSpeed()
    {
        float speedDivider = 10f;
        scrollSpeed = initialScrollSpeed +  timer / speedDivider;
    }
}
