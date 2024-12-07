using UnityEngine;
using UnityEngine.UI;

public class MobileCharacterControllerGas : MonoBehaviour
{
    public float hareketHizi = 5f;
    public Button forwardButton;

    private bool ileriHareket = false;

    private void Start()
    {
        // İleri düğmesine tıklama olayını dinleyen bir metot ekliyoruz.
        forwardButton.onClick.AddListener(OnForwardButtonTiklandi);
    }

    private void Update()
    {
        if (ileriHareket)
        {
            transform.Translate(Vector3.forward * hareketHizi * Time.deltaTime);
        }
    }

    private void OnForwardButtonTiklandi()
    {
        ileriHareket = !ileriHareket;

        if (!ileriHareket)
        {
            // İleri düğmesine tekrar tıklandığında hareketi durdurmak için ek işlemler yapabilirsiniz.
        }
    }
}
