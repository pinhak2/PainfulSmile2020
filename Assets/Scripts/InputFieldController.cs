using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputFieldController : MonoBehaviour
{
    Input Input;
    void Start()
    {
        
    }


    public void UpdateSpawn()
    {
        Spawner.spawnDelay =  float.Parse(this.GetComponent<InputField>().text);
    }
}
