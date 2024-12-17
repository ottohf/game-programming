using UnityEngine;
using TMPro;

public class FPS_UI : MonoBehaviour
{
    [SerializeField] FPSCounter fps_counter; 
    [SerializeField] TMP_Text text;          

    void Update()
    {
        // Display the real-time FPS
        text.text = $"{fps_counter.fps} fps";
    }
}