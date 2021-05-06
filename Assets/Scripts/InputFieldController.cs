using UnityEngine;
using UnityEngine.UI;

public class InputFieldController : MonoBehaviour
{
    private Input Input;

    private void Start()
    {
    }

    public void UpdateSpawn()
    {
        Spawner.spawnDelay = float.Parse(this.GetComponent<InputField>().text);
    }
}