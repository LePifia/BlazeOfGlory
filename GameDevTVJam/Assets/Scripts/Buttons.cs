using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Buttons : MonoBehaviour
{

    public static Buttons Instance { get; private set; }
    [SerializeField] int numberOfButtons = 3;

    public List<GameObject> buttons;
    [SerializeField] GameObject[] buttonsPrefabs;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void Update()
    {
        
            if (buttons.Count < numberOfButtons)
            {
                buttons.Add (Instantiate(buttonsPrefabs[Random.Range(0, buttonsPrefabs.Length)], gameObject.transform));
            }
        
        
    }
}
