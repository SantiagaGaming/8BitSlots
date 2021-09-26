using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamps : MonoBehaviour
{
    [SerializeField] private GameObject[] _lamps;

    private Color _whiteColor;
    private Color _yellowColor;
    private CheckWin _checkWin;
    private StartSpin _startSpin;

    private bool _spining = false;
    private bool _winLight = false;

    private void Awake()
    {
        _checkWin = FindObjectOfType<CheckWin>();
        _startSpin = FindObjectOfType<StartSpin>();
    }
    void Start()
    {
           _whiteColor = new Color(255, 255, 255, 255);
           _yellowColor = new Color(255, 224, 0, 255);
            StartCoroutine(IdleLight());
    }

private IEnumerator IdleLight()
    {
        for (int i = 0; i < _lamps.Length; i++)
        {
            if (_spining && !_winLight) {
                _lamps[i].GetComponent<SpriteRenderer>().color = _yellowColor;
                yield return new WaitForSeconds(0.1f);
                _lamps[i].GetComponent<SpriteRenderer>().color = _whiteColor;
            }
            else if (!_spining && !_winLight)
            {
                _lamps[i].GetComponent<SpriteRenderer>().color = _yellowColor;
                yield return new WaitForSeconds(1f);
                _lamps[i].GetComponent<SpriteRenderer>().color = _whiteColor;
            }
            else if(!_spining && _winLight)
            {
                int blink = 4;
                while (blink > 0)
                {
                    for (int x = 0; x < _lamps.Length; x++)
                    {
                        _lamps[x].GetComponent<SpriteRenderer>().color = _yellowColor;
                    }
                    yield return new WaitForSeconds(0.3f);
                    for (int x = 0; x < _lamps.Length; x++)
                    {
                        _lamps[x].GetComponent<SpriteRenderer>().color = _whiteColor;
                    }
                    yield return new WaitForSeconds(0.3f);
                    blink--;
                }
                _winLight = false;
            }
        }
        StartCoroutine(IdleLight());
    }
    private void ChangeSeconds(bool spin)
    {
        _spining = spin;
    }
    private void ChangeBlink(bool blink)
    {
        _winLight = blink;
    }

    private void OnEnable()
    {
        _startSpin.StartSpinning += ChangeSeconds;
        _checkWin.Win += ChangeBlink;
    }
    private void OnDisable()
    {
        _startSpin.StartSpinning -= ChangeSeconds;
        _checkWin.Win -= ChangeBlink;
    }
}
