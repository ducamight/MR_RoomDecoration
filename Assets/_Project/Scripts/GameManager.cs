using Oculus.Interaction;
using Oculus.Interaction.HandGrab;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("Level Items")]
    public GameObject[] levelItems;
    public int totalItemsSnapCorrectly;
    [SerializeField] BoxCollider RoomCollider;

    [Space]
    [Header("Win FX")]
    public GameObject winParticlePrefab;
    public Transform centerRoomPoint;

    public Vector3 winParticlePrefabScale;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        winParticlePrefab.transform.localScale = winParticlePrefabScale;
        AudioManager.Instance.Play("BackgroundMusic_1");
        RoomCollider.enabled = false; 
    }

    public void SnapCorrect()
    {
        totalItemsSnapCorrectly++;
    }
    public void SnapUnCorrect()
    {
        totalItemsSnapCorrectly--;
    }

    private void DisableGrab()
    {
        foreach (GameObject item in levelItems)
        {
            item.GetComponentInChildren<HandGrabInteractable>().enabled = false;
        }
    }

    private void EnableRoomCollider()
    {
        RoomCollider.enabled = true;    
    }
    public void WinGame()
    {
        if(totalItemsSnapCorrectly == levelItems.Length)
        {
            Debug.Log("You win the game!");
            // Add your win game logic here
            Instantiate(winParticlePrefab, centerRoomPoint.position, Quaternion.identity);
            AudioManager.Instance.Play("VictorySound");
            DisableGrab();
            EnableRoomCollider();
        }
    }

}
