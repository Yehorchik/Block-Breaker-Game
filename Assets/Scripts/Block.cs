using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    Level level;
    GameStatus game; //cashed reference
    [SerializeField] GameObject Particles;
    // max hits for block
    [SerializeField] int maxHits = 3;
    [SerializeField] int timesHit;
    [SerializeField] Sprite[] HitSprite;
    private void Start()
    {
        game = FindObjectOfType<GameStatus>();
        level = FindObjectOfType<Level>();
        level.CountBreakebleBlocks();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(tag == "Breakable")
        {
            HandleHit();
        }
    }

    private void TriggerParticles()
    {
        GameObject hearts = Instantiate(Particles, transform.position +  new Vector3(0,1,-2), Quaternion.Euler(-90,0,0));
        Destroy(hearts, 8f);
    }
    private void HandleHit()
    {
        timesHit ++;
        if (timesHit >= maxHits)
        {
            game.AddToScore();
            level.BlockDestroy();
            Destroy(gameObject);
            TriggerParticles();
        }
        else 
        {
            ShowNextSprite();
        }
    }

    private void ShowNextSprite()
    {
        int spriteIndex = timesHit - 1;
        GetComponent<SpriteRenderer>().sprite = HitSprite[spriteIndex];
    }
}
