#pragma strict

private var volume : float;
var inputField : UnityEngine.UI.InputField;
var Scroller : UnityEngine.UI.Slider;

function Update () {
	//volume = Scroller.value;
	var volumeText = Scroller.value.ToString();
	inputField.text = volumeText;
}