using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextPosterDistance : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    [SerializeField] Image imageCompass;
    [SerializeField] float velocityRotation = 0.2f;

    ActiveInteraction[] uIPoster;

    List<GameObject> postersActives = new List<GameObject>();
    GameObject actualPoster;

    // Start is called before the first frame update
    void Start()
    {
        uIPoster = FindObjectsOfType<ActiveInteraction>();
        foreach (ActiveInteraction poster in uIPoster) {
            postersActives.Add(poster.gameObject); 
        }

        actualPoster = postersActives[0];
    }
    
    // Update is called once per frame
    void Update()
    {
        if(postersActives.Count > 0 && !actualPoster.activeSelf)
            actualPoster = GetPosterDistance();
        print(actualPoster.name);

        Vector2 playerPos = new Vector2(playerTransform.position.x, playerTransform.position.z);
        Vector2 playerFwd = new Vector2(playerTransform.forward.x, playerTransform.forward.z);

        float angle = Vector2.SignedAngle(new Vector2( actualPoster.transform.position.x, actualPoster.transform.position.z) - playerPos, playerFwd);

        imageCompass.rectTransform.rotation = Quaternion.Slerp(imageCompass.rectTransform.rotation, 
                                      Quaternion.Euler(0,0,-angle), velocityRotation);
    }

    GameObject GetPosterDistance() {
        while (postersActives.Count > 1 && !postersActives[0].activeSelf) {
            postersActives.RemoveAt(0);
        }

        GameObject actualPosterDistance = actualPoster;
        for (int i = 0; i < postersActives.Count; i++) {
            if (postersActives.Count > 0 
                //&& Vector3.Distance(playerTransform.position, actualPosterDistance.transform.position) > Vector3.Distance(playerTransform.position, postersActives[i].transform.position) 
                                    && postersActives[i].activeSelf) {
                actualPosterDistance = postersActives[i];
            } else if (!actualPoster.activeSelf) {
                actualPosterDistance = postersActives[0];
            }

        }
        return actualPosterDistance;
    }

    Vector3 GetDirection() {
        Vector3 DirectionActual = new Vector3(actualPoster.transform.position.x - playerTransform.position.y, 0,
                                              actualPoster.transform.position.z - playerTransform.position.z);
        return DirectionActual;
    }
}
