using UnityEngine;
using UnityEngine.UI;

public class MobileCharacterControllerR : MonoBehaviour
{
    public float donmeHizi = 100f;
    public Button rightButton;

    private bool sagaDondur = false;

    private void Start()
    {
        // Sağ düğmesine tıklama olayını dinleyen bir metot ekliyoruz.
        rightButton.onClick.AddListener(OnRightButtonTiklandi);
    }

    private void Update()
    {
        if (sagaDondur)
        {
            transform.Rotate(Vector3.up, donmeHizi * Time.deltaTime);
        }
    }

    private void OnRightButtonTiklandi()
    {
        sagaDondur = !sagaDondur;

        if (!sagaDondur)
        {
            // Sağ düğmesine tekrar tıklandığında dönüşü durdurmak için ek işlemler yapabilirsiniz.
        }
    }
}
