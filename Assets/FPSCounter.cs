using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class FPSCounter : MonoBehaviour
{
    public int fps { get; private set; }
    public int fpsAvg { get; private set; } // average over the last n frames
    public int n_frames_to_track { get; private set; } = 10;

    Queue<float> frame_durations = new Queue<float>();
    float fps_float;
    void Awake()
    {
        Application.targetFrameRate = 60; // Limit FPS to 60
    }

    void Update()
    {
        fps_float = 1f / Time.deltaTime;
        fps = (int)fps_float;
        frame_durations.Enqueue(fps_float);

        if (frame_durations.Count > n_frames_to_track)
            frame_durations.Dequeue();

        fpsAvg = (int)frame_durations.Average();
    }
}