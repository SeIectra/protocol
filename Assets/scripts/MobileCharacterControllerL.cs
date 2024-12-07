using UnityEngine;
using UnityEngine.UI;

public class MobileCharacterControllerL : MonoBehaviour
{
    public float donmeHizi = 100f;
    public Button leftButton;

    private bool solaDondur = false;

    private void Start()
    {
        // Sol düğmesine tıklama olayını dinleyen bir metot ekliyoruz.
        leftButton.onClick.AddListener(OnLeftButtonTiklandi);
    }

    private void Update()
    {
        if (solaDondur)
        {
            transform.Rotate(Vector3.up, -donmeHizi * Time.deltaTime);
        }
    }

    private void OnLeftButtonTiklandi()
    {
        solaDondur = !solaDondur;

        if (!solaDondur)
        {
            // Sol düğmesine tekrar tıklandığında dönüşü durdurmak için ek işlemler yapabilirsiniz.
        }
    }
}
