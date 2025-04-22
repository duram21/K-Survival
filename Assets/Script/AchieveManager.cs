using System;
using UnityEngine;

public class AchieveManager : MonoBehaviour
{
    public GameObject[] lockCharacter;
    public GameObject[] unlockCharacter;

    enum Achieve {UnlockPotato, UnlockBean }
    Achieve[] achieves;

    void Awake()
    {
        achieves = (Achieve[])Enum.GetValues(typeof(Achieve));

        if (!PlayerPrefs.HasKey("MyData"))
            Init();
    }

    void Init()
    {
        PlayerPrefs.SetInt("MyData", 1);

        foreach (Achieve achieve in achieves)
        {
            PlayerPrefs.SetInt(achieve.ToString(), 0);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       UnlockCharacter(); 
    }

    void UnlockCharacter()
    {
        for (int index = 0 ; index < lockCharacter.Length; index++)
        {
            string achieveName = achieves[index].ToString();
            bool isUnlock = PlayerPrefs.GetInt(achieveName) == 1;
            lockCharacter[index].SetActive(!isUnlock);
            unlockCharacter[index].SetActive(isUnlock);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
