using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowsManager : MonoBehaviour
{
    [SerializeField]
    private Transform[] windows = null;

    public static Transform[] Windows { get; private set; }

    //Initialize private windows to public Windows
    private void Awake()
    {
        Windows = windows;
    }
}
