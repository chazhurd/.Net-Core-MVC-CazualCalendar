var direction = "right";
var winWidth = window.innerWidth
    || document.documentElement.clientWidth
    || document.body.clientWidth;

function MoveHeaderLeft() {
    var x = -50;
    var jumboPic = document.getElementById("JumboPic");
 
    var movingImage = setInterval(() => {
        if (winWidth < 600) {
            if (x > 0 && x < 13) {
                direction = "right";
            }
            if (x < -1590) {
                direction = "left";
            }


            if (direction === "right") {
                x = x - 0.4;
                jumboPic.style.left = x + "px";
            } else {
                x = x + 0.4;
                jumboPic.style.left = x + "px";
            }
        } else {
            if (x > 0 && x < 13) {
                direction = "right";
            }
            if (x < -690) {
                direction = "left";
            }


            if (direction === "right") {
                x = x - 0.4;
                jumboPic.style.left = x + "px";
            } else {
                x = x + 0.4;
                jumboPic.style.left = x + "px";
            }}
     
    }, 10);

}