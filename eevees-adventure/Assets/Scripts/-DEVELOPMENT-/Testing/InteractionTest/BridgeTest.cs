using UnityEngine;

public class BridgeTest : MonoBehaviour
{
    [SerializeField] private GameObject _bridgeObject;

    public void ToggleBridge()
    {
        if (this._bridgeObject.activeSelf)
        {
            this._bridgeObject.SetActive(false);
        } else
        {
            this._bridgeObject.SetActive(true);
        }
    }

    public void SpawnBridge()
    {
        this._bridgeObject.SetActive(true);
    }
}
