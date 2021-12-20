using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private int maxIcons = 5;

    private int iconsCollected = 0;


    public UnityAction OnAllIconsCollected;
    public UnityAction<int> OnIconCollected;

    public int Icons
    {
        get { return iconsCollected; }
        set { iconsCollected = value;
            if(iconsCollected >= maxIcons)
            {
                OnAllIconsCollected?.Invoke();
            }
            else
            {
                OnIconCollected?.Invoke(iconsCollected);
            }
        }
    }

    public int MaxIcons
    {
        get { return maxIcons; }
    }
}
