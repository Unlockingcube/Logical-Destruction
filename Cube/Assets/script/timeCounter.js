
var timer;
timer = 0.0;


function Start () {

}

function Update () {
    timer += Time.deltaTime;

}
function OnGUI(){
    GUI.Box(new Rect(10,10,50,20), "" + timer.ToString("0.0"));
}