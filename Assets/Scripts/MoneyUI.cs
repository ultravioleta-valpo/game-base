using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MoneyUI : MonoBehaviour {

	public Text moneyText;

	// Update is called once per frame
	void Update () {
        // la moneda funciona como toneladas de materia
		moneyText.text = "[Hidrogeno]" + PlayerStats.Money.ToString();
	}
}
