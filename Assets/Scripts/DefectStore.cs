using System.Collections.Generic;
using UnityEngine;

public class DefectStore : MonoBehaviour
{
    public static DefectStore Instance;

    public List<Defect> defects = new();

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
}
