using UnityEngine;
using System.Collections;
 
public class PlayerScript : MonoBehaviour {
 
	private int turn = 1;  
	private int[,] state = new int[3,3];
	public Texture2D img;
	public Texture2D img1;
	public Texture2D img2;

	void Start () {
		Reset ();
	}
 
	void OnGUI() {
		GUIStyle fontStyle = new GUIStyle ();
		GUIStyle fontStyle1 = new GUIStyle ();
		GUIStyle fontStyle2 = new GUIStyle ();
		fontStyle.fontSize = 40;
		fontStyle1.normal.background = img;
		fontStyle2.fontSize = 30;
		fontStyle2.normal.textColor = new Color (255, 255, 255);
 
		GUI.Label (new Rect (0, 0, 1024, 781), "", fontStyle1);
		GUI.Label (new Rect (300, 60, 100, 100), "Welcome", fontStyle);
 
		if (GUI.Button (new Rect (330, 340, 100, 50), "RESET"))
			Reset ();
		int result = check ();  
		if (result == 1) {  
			GUI.Label (new Rect (50, 250, 100, 50), "PlayerO wins!", fontStyle2);  
		} else if (result == 2) {  
			GUI.Label (new Rect (50, 250, 100, 50), "Player1 wins!", fontStyle2);  
		} 
		for (int i=0; i<3; ++i) {  
			for (int j=0; j<3; ++j) {  
				if (state [i, j] == 1)  
					GUI.Button (new Rect (290 + i * 60, 120 + j * 60, 60, 60), img1);
				if (state [i, j] == 2)
					GUI.Button (new Rect (290 + i * 60, 120 + j * 60, 60, 60), img2);
				if (GUI.Button (new Rect (290 + i * 60, 120 + j * 60, 60, 60), "")) {  
					if (result == 0) {  
						if (turn == 1)  
							state [i, j] = 1;
						else  
							state [i, j] = 2;  
						turn = -turn;  
					}  
				}  
			}
		}
	}
	void Reset() {
		turn = 1;  
		for (int i=0; i<3; ++i) {  
			for (int j=0; j<3; ++j) {  
				state[i,j] = 0;  
			}  
		}
	}
 
	int check() {  
		for (int i=0; i<3; ++i) {  
			if (state[i,0]!=0 && state[i,0]==state[i,1] && state[i,1]==state[i,2]) {  
				return state[i,0];  
			}  
		}  
		for (int j=0; j<3; ++j) {  
			if (state[0,j]!=0 && state[0,j]==state[1,j] && state[1,j]==state[2,j]) {  
				return state[0,j];  
			}  
		}  
		if (state[1,1]!=0 &&  
		    state[0,0]==state[1,1] && state[1,1]==state[2,2] ||  
		    state[0,2]==state[1,1] && state[1,1]==state[2,0]) {  
			return state[1,1];  
		}  
		return 0;  
	}  
}