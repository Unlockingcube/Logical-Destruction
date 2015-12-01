#pragma strict

function QuitGame() {
    Debug.Log("game is exiting");
    Application.Quit();
}
function Level1() {
    Application.LoadLevel ("scene1");
}
function Level2() {
    Application.LoadLevel ("scene2");
}
function Level3() {
    Application.LoadLevel ("scene3");
}
function FunTimesAllTimes() {
    Application.LoadLevel ("scene5");
}

