using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    [HideInInspector] public string slotName;
    [HideInInspector] public bool canSpin = true;

    [SerializeField]private Sprite _idleSprite;
    [SerializeField] Sprite[] _spritesList;

    private StartSpin _startSpin;
    private Lamps _lamps;
    private SoundEffector _soundEffector;
    private void Awake()
    {
        _startSpin = FindObjectOfType<StartSpin>();
        _lamps = FindObjectOfType<Lamps>();
        _soundEffector = FindObjectOfType<SoundEffector>();
    }
    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = _idleSprite;
    }

IEnumerator ChangeSprite()
    {
        canSpin = false;
        int randomSpin = Random.Range(25, 50);
        while (randomSpin>0)
        {
            GetRandomSprite();
            randomSpin--;
            if (randomSpin >= 10)
                yield return new WaitForSeconds(0.1f);
            else if (randomSpin <10)
                yield return new WaitForSeconds(0.2f);
            else if (randomSpin < 5)
                yield return new WaitForSeconds(0.4f);
        }
        SetSlotName();
        canSpin = true;
    }
   public void StartChangingSprite()
    {
        if(canSpin)
        {
        StartCoroutine(ChangeSprite());
        }
    }

    private void GetRandomSprite()
    {
        int randomSprite = Random.Range(0, _spritesList.Length);
        gameObject.GetComponent<SpriteRenderer>().sprite = _spritesList[randomSprite];
        _soundEffector.PlaySlotSound();
    }
    private void SetSlotName()
    {
        slotName = gameObject.GetComponent<SpriteRenderer>().sprite.name;
    }
}
