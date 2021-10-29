using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _blocks;

    public void Loose()
    {
        Debug.Log("LOSE");
    }

    public void CheckWin()
    {
        if (_blocks.Where(block => block.activeInHierarchy).Count() <= 0)
            Debug.Log("WIN!");
    }
}
