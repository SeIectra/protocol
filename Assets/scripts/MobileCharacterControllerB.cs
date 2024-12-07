using UnityEngine;
using UnityEngine.UI;

public class MobileCharacterControllerB : MonoBehaviour
{
    public float hareketHizi = 5f;
    public Button backButton;

    private bool geriHareket = false;

    private void Start()
    {
        // Geri düğmesine tıklama olayını dinleyen bir metot ekliyoruz.
        backButton.onClick.AddListener(OnBackButtonTiklandi);
    }

    private void Update()
    {
        if (geriHareket)
        {
            transform.Translate(Vector3.back * hareketHizi * Time.deltaTime);
        }
    }

    private void OnBackButtonTiklandi()
    {
        geriHareket = !geriHareket;

        if (!geriHareket)
        {
            // Geri düğmesine tekrar tıklandığında hareketi durdurmak için ek işlemler yapabilirsiniz.
        }
    }
}
