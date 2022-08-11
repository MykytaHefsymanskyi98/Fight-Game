using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModelsHolder : MonoBehaviour
{
    [Header("Models")]
    [Space]
    [SerializeField] private List<PlayerCharacterModel> playerModelsList = new List<PlayerCharacterModel>();

    private PlayerCharacterModel currentModel;

    private void Awake()
    {
        FillModelsList();
    }

    public void SetCharacterModel(Characters character)
    {
        for(int i = 0; i < playerModelsList.Count; i++)
        {
            if(playerModelsList[i].CharacterType == character)
            {
                currentModel = playerModelsList[i];
                currentModel.gameObject.SetActive(true);
            }
        }
    }

    private void FillModelsList()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            if(transform.GetChild(i).TryGetComponent(out PlayerCharacterModel model) && !playerModelsList.Contains(model))
            {
                playerModelsList.Add(model);
                model.gameObject.SetActive(false);
            }
        }
    }
}
