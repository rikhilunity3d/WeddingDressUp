using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeItem : MonoBehaviour
{
    [Header("Enter the matching [ID] according to the button")]
    [SerializeField]
    int id;
   private void OnEnable() {
       Debug.Log("Change Item OnEnable");
       EventHandler.Instance.OnChangeableAction += ChangeItemSprite;
       EventHandler.Instance.OnLoadSpriteFromSO += LoadSpriteFromSO;


   }
    private void Start()
    {
        
    }
    private void OnDisable() {
       Debug.Log("Change Item OnDisable");
        EventHandler.Instance.OnChangeableAction -= ChangeItemSprite;
        EventHandler.Instance.OnLoadSpriteFromSO -= LoadSpriteFromSO;
    }

    public void LoadSpriteFromSO(ChangeableScriptableObjects SO)
    {

        if (id == SO.ItemId)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = SO.ItemArray[SO.Counter];
        }
    }

    public void ChangeItemSprite(ChangeableScriptableObjects SO)
   {
       if(id == SO.ItemId)
       {
            if (SO.Counter<SO.ItemArray.Length-1)
            {
                SO.Counter+=1;
            }
            else
            {
                SO.Counter=0;
            }
            this.gameObject.GetComponent<SpriteRenderer>().sprite = SO.ItemArray[SO.Counter];
       }
    }
}
