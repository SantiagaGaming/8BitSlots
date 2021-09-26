using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CheckWin : MonoBehaviour
{
    public event UnityAction<bool> Win;

    [SerializeField] private Slot[] _slots;

    private SoundEffector _soundEffector;
    private Player _player;

    private string _firstSlot;
    private string _secondSlot;
    private string _thirdSlot;

    void Start()
    {
        _soundEffector = FindObjectOfType<SoundEffector>();
        _player = GetComponent<Player>();
    }
    private void UpdateSlotsNames()
    {
        _firstSlot = _slots[0].slotName;
        _secondSlot = _slots[1].slotName;
        _thirdSlot = _slots[2].slotName;
    }

    public void StartCheck()
    {
        UpdateSlotsNames();

        CheckBigWin("Pipe", 400);
        CheckBigWin("Blue", 800);
        CheckBigWin("Flower", 1500);
        CheckBigWin("Mario", 3000);
        CheckBigWin("Coin", 5000);

        CheckSmallWin("Pipe", 100);
        CheckSmallWin("Blue", 200);
        CheckSmallWin("Flower", 400);
        CheckSmallWin("Mario", 800);
        CheckSmallWin("Coin", 1200);
    }
    private void CheckBigWin(string slotName, int score)
    {
        if (_firstSlot == slotName && _firstSlot == _secondSlot && _firstSlot == _thirdSlot)
        {
            _player.UpdateScore(score);
            Win.Invoke(true);
            _soundEffector.PlayWinSound();
        }
    }
    private void CheckSmallWin(string slotName, int score)
    {
        if (_firstSlot == slotName &&_firstSlot == _secondSlot

         || _firstSlot == slotName && _firstSlot == _thirdSlot

               || _secondSlot == slotName && _secondSlot == _thirdSlot)
        {

            _player.UpdateScore(score);
            Win.Invoke(true);
            _soundEffector.PlayWinSound();
        }
    }
}
