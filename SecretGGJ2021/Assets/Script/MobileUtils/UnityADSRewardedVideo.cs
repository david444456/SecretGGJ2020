using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class UnityADSRewardedVideo : MonoBehaviour {


    [SerializeField] UnityEvent IRewarded = new UnityEvent();
    [SerializeField] UnityEvent IRewardedFailed = new UnityEvent();

    [Header("View")]
	string placementID = "rewardedVideo"; //ID del anuncio
	[Range(0, 10)]public int rewardGemns;
	int gemns;

    string GooglePlay_Id = "4041025";


    void Start () {
		// Inicia el SDK de Unity Ads
		//Advertisement.Initialize (placementID, true); //El TRUE es para activar el Modo Testeo
		Advertisement.Initialize (GooglePlay_Id);

		//Setea las gemas y el texto a CERO
		gemns = 0;
		//txtGemns.text = gemns.ToString ();
	}

	//Muestra el Video Recompensado, si esta listo
	public void ShowRewardedVideo () {
		//ShowOptions es una coleccion que nos permite trabajar con los diferentes resultados del video
		ShowOptions options = new ShowOptions ();

		//Devolución de llamada para recibir el resultado del anuncio.
		options.resultCallback = HandleShowResult;

		//Si esta listo, muestra el video
		if (Advertisement.IsReady(placementID)) {
			Advertisement.Show (placementID, options);
			print ("REWARDED - Video abierto.");
			//txtMessage.text = "REWARDED - Video abierto.";
		} else {
			print ("El Video Recompensado aun no esta listo.");
			//txtMessage.text = "El Video Recompensado aun no esta listo.";
		}
	}

	void HandleShowResult (ShowResult result) {
		if (result == ShowResult.Finished) {
			print ("REWARDED - Recompensado.");
            //txtMessage.text = "REWARDED - Recompensado.";
            IRewarded.Invoke();

        } else if (result == ShowResult.Skipped) {
			print ("REWARDED - Video salteado.");
            IRewardedFailed.Invoke();
            //txtMessage.text = "REWARDED - Video salteado.";
        } else if (result == ShowResult.Failed) {
			print ("REWARDED - Falla al cargar el video.");
            IRewardedFailed.Invoke();
            //txtMessage.text = "REWARDED - Falla al cargar el video.";
        }
	}

}
