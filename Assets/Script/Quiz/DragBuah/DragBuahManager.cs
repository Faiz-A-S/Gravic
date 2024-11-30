using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragBuahManager : MonoBehaviour
{
    public string PromptString;
    public List<int> KebutuhanBuah;
    [SerializeField] Text _promptStringText;
    [SerializeField] Slider _sliderApel;
    [SerializeField] Slider _sliderJeruk;
    [SerializeField] Slider _sliderPisang;
    [SerializeField] Slider _sliderAlpukat;

    bool _start;

    private PlateOnTop _plateOnTop;
    // Start is called before the first frame update
    void Start()
    {
        _plateOnTop = GetComponent<PlateOnTop>();
        
        _start = true;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSliders();
        if (_start == true)
        {
            _start = false;
            GenerateKebutuhan();
            TextInit();
        }
    }

    private void UpdateSliders()
    {
        UpdateSlider(_sliderApel, _plateOnTop.ApelInsideBag);
        UpdateSlider(_sliderJeruk, _plateOnTop.JerukInsideBag);
        UpdateSlider(_sliderPisang, _plateOnTop.PisangInsideBag);
        UpdateSlider(_sliderAlpukat, _plateOnTop.AlpukatInsideBag);
    }

    private void UpdateSlider(Slider slider, int value)
    {
        if (value == 0)
        {
            slider.gameObject.SetActive(false);
        }
        else
        {
            slider.gameObject.SetActive(true);
            slider.value = value * 1; //- 1
        }
    }

    void GenerateKebutuhan()
    {
        for (int i = 0; i < KebutuhanBuah.Count; i++)
        {
            KebutuhanBuah[i] = Random.Range(0, 5);
        }
    }

    public void CheckKebutuhan()
    {
        if (KebutuhanBuah[0] == _plateOnTop.ApelInsideBag &&
            KebutuhanBuah[1] == _plateOnTop.JerukInsideBag &&
            KebutuhanBuah[2] == _plateOnTop.PisangInsideBag &&
            KebutuhanBuah[3] == _plateOnTop.AlpukatInsideBag)
        {
            Debug.Log("benar");
            Fungus.Flowchart.BroadcastFungusMessage("BuahBenar");
            _plateOnTop.ApelInsideBag = 0;
            _plateOnTop.JerukInsideBag = 0;
            _plateOnTop.PisangInsideBag = 0;
            _plateOnTop.AlpukatInsideBag = 0;
            _start = true;
        }
        else
        {
            Debug.Log("salah");
            Fungus.Flowchart.BroadcastFungusMessage("BuahSalah");
        }
    }

    private void TextInit()
    {
        _promptStringText.text = PromptString + "\n \n" +
            "Apel : " + KebutuhanBuah[0] + "\n" +
            "Jeruk : " + KebutuhanBuah[1] + "\n" +
            "Pisang : " + KebutuhanBuah[2] + "\n" +
            "Alpukat : " + KebutuhanBuah[3];
    }
}
