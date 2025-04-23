using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;

    public AudioClip clip;
    private AudioSource source;

    public float Volumn;
    public bool loop;

    public void SetSource(AudioSource _source)
    {
        source = _source;
        source.clip = clip;
        source.loop = loop;
    }

    public void SetVolumn()
    {
        source.volume = Volumn;
    }

    public void Play()
    {
        source.Play();
    }

    public void Stop()
    {

    }
}

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    public Sound[] sounds;

    private void Start()
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            GameObject soundObject = new GameObject("���� ���� �̸� :" + i + "=" + sounds[i].name);
            sounds[i].SetSource(soundObject.AddComponent<AudioSource>());
            soundObject.transform.SetParent(this.transform);
        }
    }

    public void Play(string _name)
    {
        for(int i = 0; i < sounds.Length; i++)
        {
            if(_name == sounds[i].name)
            {
                sounds[i].SetVolumn();
                sounds[i].Play();
                return;
            }
        }
    }
}
