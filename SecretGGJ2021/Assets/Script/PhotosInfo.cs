using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "InfoPhoto", menuName = "Photo/ New photo data", order = 0)]
public class PhotosInfo : ScriptableObject
{
    [SerializeField] public informationScriptablePhoto[] photoInfos;
    [SerializeField] [TextArea] public  string textVictory;
    [SerializeField] public Sprite photoVictory;
    [SerializeField] public AudioClip audioClipWin;
    [SerializeField] public AudioClip clipObject;
}

[System.Serializable]
public class informationScriptablePhoto
{
    public float indexPhoto;
    public Sprite sprite;
    [TextArea] public string descriptionPhoto;
}
