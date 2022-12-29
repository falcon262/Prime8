using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class webCamMotionDetection : MonoBehaviour {

	public float updating;

	[Range(0.0f, 1.0f)]
	public float sensibility;

	public GameObject motionShowUI;

	public enum Mode{
		contrast,
		color
	};
	public Mode detectionMode = Mode.contrast;

	private int pixelsAffected;
	public int motionDetect;
	private WebCamTexture webcamTextureInitial;
	private WebCamTexture webcamTexture;

	private Color[] pixelColor;
	private float ratio;
	private int webcamResizeX = 160;
	private int webcamResizeY;
	private Color colorUpdate;
	private Sprite mySprite;

	public Gradient gradient;
	private float differencePixel;
	private float totalDifference;

	public bool audioAlert;
	[Range(0.0f, 1.0f)]
	public float volumeSensibility = 0.1f;



	void Awake() {

		

	}

	IEnumerator OnCamEnabled()
	{
        yield return Application.RequestUserAuthorization(UserAuthorization.WebCam);
        if (Application.HasUserAuthorization(UserAuthorization.WebCam))
        {
            //create webcamTexture with default resolution
            webcamTextureInitial = new WebCamTexture();
            Renderer renderer = GetComponent<Renderer>();
            renderer.material.mainTexture = webcamTextureInitial;
            webcamTextureInitial.Play();

            ratio = (float)webcamTextureInitial.width / (float)webcamTextureInitial.height;

            //scale webCam plane
            gameObject.transform.localScale = new Vector3(1f * ratio, 1f, 1f);

            //scale motionShowUI
            motionShowUI.transform.localScale = new Vector3(1f * (1f / ratio), 1f, 1f);


            float newfloatY = webcamResizeX / ratio;
            webcamResizeY = (int)newfloatY;

            webcamTextureInitial.Stop();

            //resize webcamTexture with predeterminate width and height (to optimize calculations)
            webcamTexture = new WebCamTexture(webcamResizeX, webcamResizeY, 25);
            renderer.material.mainTexture = webcamTexture;
            webcamTexture.Play();

            //create colors
            pixelColor = new Color[webcamResizeX * webcamResizeY];

            this.transform.localPosition = new Vector3(-6.19f, 1.98f, 0.07f);
            this.transform.localScale = new Vector3(0.5246233f, 0.2712144f, 0.3525787f);

            InvokeCam();

        }
        else
        {
            Debug.Log("no webcams found");
        }
    }

    private void OnEnable()
    {
		StartCoroutine(OnCamEnabled());
    }

    private void OnDisable()
    {
        StopCoroutine(OnCamEnabled());
        CancelInvoke("FindMotion");
        webcamTexture.Stop();
		motionDetect = 0;
    }

    public void InvokeCam()
	{
        InvokeRepeating("FindMotion", updating, updating);
    }

	void FindMotion (){

		Texture2D textureUI = new Texture2D(webcamResizeX, webcamResizeY);

		for (int x = 0; x < webcamResizeX; x++){
			for (int y = 0; y < webcamResizeY; y++){
				textureUI.SetPixel(x, y, Color.clear);
			}
		}
		motionShowUI.GetComponent<Image>().sprite = mySprite;

		//for each pixel of texture 
		for (int x = 0; x < webcamResizeX; x++){
			for (int y = 0; y < webcamResizeY; y++){

				//order the pixels with number
				int i = x+webcamResizeX*y;   

				switch (detectionMode){
					case Mode.contrast:
						float lastPixel = pixelColor[i].grayscale;
						float currentPixel = webcamTexture.GetPixel (x,y).grayscale;
						differencePixel = Mathf.Abs(lastPixel - currentPixel);
						break;
					case Mode.color:
						float lastPixel_R = pixelColor[i].r;
						float currentPixel_R = webcamTexture.GetPixel (x,y).r;
						float lastPixel_G = pixelColor[i].r+pixelColor[i].g;
						float currentPixel_G = webcamTexture.GetPixel (x,y).g;
						float lastPixel_B = pixelColor[i].b;
						float currentPixel_B = webcamTexture.GetPixel (x,y).b;
						differencePixel = (Mathf.Abs(lastPixel_R - currentPixel_R) + Mathf.Abs(lastPixel_G - currentPixel_G) + Mathf.Abs(lastPixel_B - currentPixel_B))/3;
						break;
				}

				if (differencePixel > Mathf.Abs(sensibility-1.0f)){
					++pixelsAffected;
					colorUpdate = gradient.Evaluate((differencePixel));
					totalDifference = totalDifference+differencePixel;
					textureUI.SetPixel(x, y, colorUpdate);
				}

				//update pixel color
				pixelColor[i] = webcamTexture.GetPixel (x,y);

			}
		}

		textureUI.Apply();
		mySprite = Sprite.Create(textureUI, new Rect(0.0f, 0.0f, webcamResizeX, webcamResizeY), new Vector2(0.5f, 0.5f), 100.0f);

		if (pixelsAffected > 0){
			//print (pixelsAffected);
			motionDetect = pixelsAffected;
			if (audioAlert){
				gameObject.GetComponent<AudioSource>().volume = (totalDifference/sensibility)/200f*volumeSensibility;
				gameObject.GetComponent<AudioSource>().Play();
			}
		}
		else
		{
			motionDetect = 0;
		}
		totalDifference = 0;
		pixelsAffected = 0;

	}

	public void soundAlert(){

		if (audioAlert == true){
			audioAlert = false;
		} else {
			audioAlert = true;
		}
	}


}