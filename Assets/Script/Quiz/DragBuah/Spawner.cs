using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//Spawner BUAH
public class Spawner : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] GameObject _Apel;
    [SerializeField] GameObject _Jeruk;
    [SerializeField] GameObject _Pisang;
    [SerializeField] GameObject _Alpukat;

    public void OnPointerClick(PointerEventData eventData)
    {
        string objectName = eventData.pointerEnter.name;
        switch (objectName)
        {
            case "Apel":
                Spawn(_Apel);
                break;
            case "Jeruk":
                Spawn(_Jeruk);
                break;
            case "Pisang":
                Spawn(_Pisang);
                break;
            case "Alpukat":
                Spawn(_Alpukat);
                break;
        }
    }

    private void Spawn(GameObject prefab)
    {
        Vector3 mousePos = Input.mousePosition;
        Instantiate(prefab, mousePos, Quaternion.identity, this.transform.parent); Debug.Log(mousePos);
    }
}
