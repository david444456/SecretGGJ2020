using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActiveUIPoster : MonoBehaviour
{

    public int indexPosterActual = 0;
    [SerializeField] public ActiveInteraction[] posters;
    [SerializeField] PhotosInfo photoInfoActual;
    [SerializeField] FirstPersonController fPSController;

    [Header("UI")]
    [SerializeField] Image photoImage;
    [SerializeField] Text textDescription;
    [SerializeField] GameObject gameObjectPhotoInfo;
    [SerializeField] Text textCount;
    [SerializeField] GameObject buttonExit;
 
    int countPhotosComplete = 0;
    int limitCountPhotos = 0;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        limitCountPhotos = posters.Length;
        textCount.text = "Van " + countPhotosComplete + "/" + limitCountPhotos;
        GetComponent<Image>().enabled = true;
        gameObject.SetActive(false);

        
    }

#if UNITY_STANDALONE_WIN || UNITY_EDITOR
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !buttonExit.activeSelf) activeImageWithPhoto();
        if(gameObjectPhotoInfo.activeSelf && Input.GetKeyDown(KeyCode.F) && !buttonExit.activeSelf) desactivePoster();
        if (buttonExit.activeSelf && Input.GetKeyDown(KeyCode.Escape)) exitGame();
    }

#endif 
    public void activeImageWithPhoto() {
        photoImage.sprite = photoInfoActual.photoInfos[indexPosterActual].sprite;
        textDescription.text = photoInfoActual.photoInfos[indexPosterActual].descriptionPhoto;
        fPSController.changeBoolMove(true);
        gameObjectPhotoInfo.SetActive(true);

        audioSource.clip = photoInfoActual.clipObject;
        audioSource.Play();
    }

    public void desactivePoster() {
       

        //basic
        posters[indexPosterActual].gameObject.SetActive(false);
        countPhotosComplete++;

        textCount.text = "Van " + countPhotosComplete + "/" + limitCountPhotos;

        //desactive gameobjects
        fPSController.changeBoolMove(false);
        
        gameObjectPhotoInfo.SetActive(false);

        //win
        if (countPhotosComplete >= limitCountPhotos)
        {
            winCondition();
        }else gameObject.SetActive(false);
    }

    public void exitGame() {
        print("Quit");
        Application.Quit();
    }

    void winCondition() {
        photoImage.sprite = photoInfoActual.photoVictory;
        textDescription.text = photoInfoActual.textVictory;
        fPSController.changeBoolMove(true);
        gameObjectPhotoInfo.SetActive(true);
        buttonExit.SetActive(true);

        audioSource.clip = photoInfoActual.audioClipWin;
        audioSource.Play();
    }
}
