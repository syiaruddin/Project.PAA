using UnityEngine;
using UnityEngine.UI;

public class TambahDroid : MonoBehaviour
{
    public GameObject redDroidPrefab; // Prefab droid merah
    public Transform mapParent; // Parent untuk objek-objek droid

    private bool droidSpawned = false;
    public Transform lokasi_spaw;
    private void Start()
    {
        // Menambahkan listener pada tombol
        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        if (!droidSpawned)
        {
            // Memunculkan droid merah jika belum dimunculkan sebelumnya
            GameObject redDroid = Instantiate(redDroidPrefab, lokasi_spaw);
            redDroid.GetComponent<DroidMerah>().stopMove = true; // Menghentikan pergerakan droid merah

            droidSpawned = true;
        }
        else
        {
            // Mengaktifkan pergerakan droid merah jika sudah dimunculkan sebelumnya
            DroidMerah[] droids = mapParent.GetComponentsInChildren<DroidMerah>();
            foreach (DroidMerah droid in droids)
            {
                droid.stopMove = false;
            }
        }
    }
}
