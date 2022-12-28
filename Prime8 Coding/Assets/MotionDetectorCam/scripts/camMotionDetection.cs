using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class camMotionDetection : MonoBehaviour {

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
	private Color[] pixelColor;
	private float ratio;

	private int screenSizeX;
	private int screenSizeY;
	private int screenResizeX;
	private int screenResizeY;

	private Color colorUpdate;
	private Sprite mySprite;

	public Gradient gradient;
	private bool motion;
	private float differencePixel;
	private float totalDifference;

	public bool audioAlert;
	[Range(0.0f, 1.0f)]
	public float volumeSensibility = 0.1f;

	private RenderTexture myRenderTexture;
	private Texture2D myTexture2D;
	private Texture2D textureUI;
	public Camera cam;

	void Awake() {

		ratio = (float)Screen.width/(float)Screen.height;

		//scale webCam plane
		gameObject.transform.localScale = new Vector3 (1f*ratio,1f, 1f);

		screenSizeX = 1920;
		float newfloatY = screenSizeX/ratio;
		screenSizeY = (int) newfloatY;

		screenResizeX = screenSizeX/10;
		screenResizeY = screenSizeY/10;

		//create colors
		pixelColor = new Color[screenResizeX*screenResizeY];

		//create texture2D
		myTexture2D = new Texture2D (screenResizeX ,screenResizeY, TextureFormat.ARGB32, false);

		//create rendertexture
		myRenderTexture = new RenderTexture(screenResizeX, screenResizeY, 16, RenderTextureFormat.ARGB32);
		myRenderTexture.Create();

		//posem la rendertexture a la camara
		cam.targetTexture = myRenderTexture;
	}

	void Start (){

		InvokeRepeating("FindMotion", updating, updating);

	}

	void FindMotion (){

		Texture2D textureUI = new Texture2D (screenResizeX, screenResizeY);

		RenderTexture.active = myRenderTexture;
		myTexture2D.ReadPixels(new Rect(0, 0, screenResizeX, screenResizeY), 0, 0);
 
		for (int x = 0; x < screenResizeX; x++){
			for (int y = 0; y < screenResizeY; y++){
				textureUI.SetPixel(x, y, Color.clear);
			}
		}

		motionShowUI.GetComponent<Image>().sprite = mySprite;

		//for each pixel of texture 
		for (int x = 0; x < screenResizeX; x++){
			for (int y = 0; y < screenResizeY; y++){

				//order the pixels with number
				int i = x+screenResizeX*y;   

				switch (detectionMode){
					case Mode.contrast:
						float lastPixel = pixelColor[i].grayscale;
					float currentPixel = myTexture2D.GetPixel (x,y).grayscale;
						differencePixel = Mathf.Abs(lastPixel - currentPixel);
						break;
					case Mode.color:
						float lastPixel_R = pixelColor[i].r;
						float currentPixel_R = myTexture2D.GetPixel (x,y).r;
						float lastPixel_G = pixelColor[i].r+pixelColor[i].g;
						float currentPixel_G = myTexture2D.GetPixel (x,y).g;
						float lastPixel_B = pixelColor[i].b;
						float currentPixel_B = myTexture2D.GetPixel (x,y).b;
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
				pixelColor[i] = myTexture2D.GetPixel (x,y);

			}
		}


		textureUI.Apply();
		mySprite = Sprite.Create(textureUI, new Rect(0.0f, 0.0f, screenResizeX, screenResizeY), new Vector2(0.5f, 0.5f), 100.0f);

		if (pixelsAffected > 0){
			print ("MOTION DETECTED");	
			if (audioAlert){
				gameObject.GetComponent<AudioSource>().volume = (totalDifference/sensibility)/200f*volumeSensibility;
				gameObject.GetComponent<AudioSource>().Play();
			}
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