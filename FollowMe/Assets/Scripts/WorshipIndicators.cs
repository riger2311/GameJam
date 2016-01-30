using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WorshipIndicators : MonoBehaviour {

	public GameObject progressA;
	public GameObject progressB;
	private Slider SliderA;
	private Slider SliderB;

	public void Start() {
		SliderA = progressA.GetComponent<Slider> ();
		SliderB = progressB.GetComponent<Slider> ();

	}

	public void givePointsToA(float percent){
		if ( percent < 0.0f || percent > 1.0f) {
			return;
		}

		if (SliderA.value + percent > 1.0f) {
			SliderA.value = 1.0f;
			SliderB.value = 0.0f;
			//Debug.Log ("You Won!!!");

			// TODO trigger win
		}

		SliderA.value += percent;
		SliderB.value -= percent;
	}

	public void givePointsToB(float percent){
		if ( percent < 0.0f || percent > 1.0f) {
			return;
		}

		if (SliderB.value + percent > 1.0f) {
			SliderB.value = 1.0f;
			SliderA.value = 0.0f;
			//Debug.Log ("You Won!!!");

			// TODO trigger win
		}

		SliderB.value += percent;
		SliderA.value -= percent;
	}

}
