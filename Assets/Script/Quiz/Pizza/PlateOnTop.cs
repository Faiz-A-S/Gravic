using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

//Tempat nyimpen banyaknya pizza dipiring & buah di dalam tas
public class PlateOnTop : MonoBehaviour
{
    [field: SerializeField]
    public int OnPiring { get; private set; }
    public int ApelInsideBag;
    public int JerukInsideBag;
    public int PisangInsideBag;
    public int AlpukatInsideBag;

    public int GetOnPiring()
    {
        return OnPiring;
    }
    public int GetApelInsideBag()
    {
        return ApelInsideBag;
    }
    public int GetJerukInsideBag()
    {
        return JerukInsideBag;
    }
    public int GetPisangInsideBag()
    {
        return PisangInsideBag;
    }
    public int GetAlpukatInsideBag()
    {
        return AlpukatInsideBag;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Pizza": OnPiring += 1;
                Debug.Log("Touching Pizza");
                break;
            case "Apel": ApelInsideBag = ApelInsideBag > 4 ? 5 : ApelInsideBag += 1;
                Destroy(collision.gameObject);
                Debug.Log("Apel nambah");
                break;
            case "Pisang": PisangInsideBag = PisangInsideBag > 4 ? 5 : PisangInsideBag += 1;
                Destroy(collision.gameObject);
                Debug.Log("Pisang nambah");
                break;
            case "Alpukat": AlpukatInsideBag = AlpukatInsideBag > 4 ? 5 : AlpukatInsideBag += 1;
                Destroy(collision.gameObject);
                Debug.Log("Alpukat nambah");
                break;
            case "Jeruk": JerukInsideBag = JerukInsideBag > 4 ? 5 : JerukInsideBag += 1;
                Destroy(collision.gameObject);
                Debug.Log("Jeruk nambah");
                break;
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Pizza":
                OnPiring -= 1;
                Debug.Log("Touching Pizza");
                break;
        }
    }

    public void RemoveApel()
    {
        ApelInsideBag -= 1;
    }
    public void RemovePisang()
    {
        PisangInsideBag -= 1;
    }
    public void RemoveJeruk()
    {
        JerukInsideBag -= 1;
    }
    public void RemoveAlpukat()
    {
        AlpukatInsideBag -= 1;
    }
}
