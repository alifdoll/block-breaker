using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip destroyAudio;
    [SerializeField] GameObject blockSparkle;
    [SerializeField] int timesHit; //TODO for DEBUG 
    [SerializeField] Sprite[] hitSprites;
    Level level;

    private void Start()
    {
        CountBreakableBlocks();
    }

    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>();
        if (tag == "Breakable") level.CountBlocks();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(tag == "Breakable")
        {
            HandleHit();
        }
    }

    private void HandleHit()
    {
        timesHit++;
        int maxHitPoint = hitSprites.Length + 1;
        if (timesHit >= maxHitPoint)
        {
            DestroyBlock();
        }
        else
        {
            ShowNextSprite();
        }
    }

    private void ShowNextSprite()
    {
        int sprIdx = timesHit - 1;
        if(hitSprites[sprIdx] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[sprIdx];
        }
        else
        {
            Debug.LogError("Block Sprite Missing" + gameObject.name);
        }
    }

    private void DestroyBlock()
    {
        DestroySound();
        Destroy(gameObject);
        level.BlockDestroyed();
        TriggerSparkle();
    }

    private void DestroySound()
    {
        FindObjectOfType<GameSession>().AddToScore();
        AudioSource.PlayClipAtPoint(destroyAudio, Camera.main.transform.position);
    }

    private void TriggerSparkle()
    {
        GameObject sparkles = Instantiate(blockSparkle, transform.position, transform.rotation);
        Destroy(sparkles, 2f);
    }
}
