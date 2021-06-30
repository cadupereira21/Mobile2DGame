﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSceneTrigger : MonoBehaviour
{
    private const string Player = "Player";

    [SerializeField] string sceneName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if (collision.CompareTag(Player))
        {
            SceneLoader.Instance.LoadSceneAsync(sceneName);
        }
    }
}
