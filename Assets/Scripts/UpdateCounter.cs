using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateCounter : MonoBehaviour
{
    [SerializeField] private GameObject objectPrefab;
    private TextMeshProUGUI uiText;
    private string objectId;

    private void Awake()
    {
        uiText = GetComponent<TextMeshProUGUI>();
        objectId = objectPrefab.GetComponent<CollectiblesCounter>().ID;
    }

    private void LateUpdate()
    {
        uiText.text = PlayerPrefs.GetInt(objectId).ToString();
    }

}
