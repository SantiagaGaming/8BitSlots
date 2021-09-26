using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class StartSpin : MonoBehaviour
{
    public event UnityAction <bool> StartSpinning;

    [HideInInspector] public bool isChecked = false;

    [SerializeField]private GameObject _buttonClick;
    [SerializeField] private Slot[] _slotsList;

    private CheckWin _checkWin;
    private Button _button;

    private void Awake()
    {
        _checkWin = FindObjectOfType<CheckWin>();
        _button = GetComponent<Button>();
        _button.onClick.AddListener(StartAllSpins);
    }
    private void Update()
    {
        CheckAllSpins();
    }
    private void StartAllSpins()
    {
        StartSpinning.Invoke(true);
        StartCoroutine(ClickedButton());
        foreach ( Slot slot in _slotsList)
        {
            slot.StartChangingSprite();
        }
    }
   private IEnumerator ClickedButton()
    {
        _buttonClick.transform.position = new Vector3(0.07f, -2.45f, 0);
        yield return new WaitForSeconds(0.1f);
        _buttonClick.transform.position = new Vector3(0, -2.3f, 0);
    }

    private void CheckAllSpins()
    {
        if(_slotsList[0].canSpin == true && _slotsList[1].canSpin == true && _slotsList[2].canSpin == true)
        {
            StartSpinning.Invoke(false);
            if (!isChecked)
            {
                _checkWin.StartCheck();
                isChecked = true;
            }
        }
        else if (_slotsList[0].canSpin == false || _slotsList[1].canSpin == false || _slotsList[2].canSpin == false)
        {
            isChecked = false;
        }
    }
}
