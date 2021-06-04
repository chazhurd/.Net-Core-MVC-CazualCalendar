
var winWidth = window.innerWidth
    || document.documentElement.clientWidth
    || document.body.clientWidth;

function MoveStudioRight() {

    var JumboPic = document.getElementById("JumboPic");
    var moveStudio = new TimelineMax();
    if (winWidth < 600) {
        moveStudio.fromTo(JumboPic, 20, { left: "-1590px" }, { left: "-100px" })
            .fromTo(JumboPic, 20, { left: "-100px" }, { left: "-1590px" });
           
        var switchStudio = setInterval(function () {
            var moveStudio2 = new TimelineMax();
            moveStudio2.fromTo(JumboPic, 20, { left: "-1590px" }, { left: "-100px" })
                .fromTo(JumboPic, 20, { left: "-100px" }, { left: "-1590px" });
        }, 41000);
    } else {
        moveStudio.fromTo(JumboPic, 20, { left: "-590px" }, { left: "-100px" })
            .fromTo(JumboPic, 20, { left: "-100px" }, { left: "-590px" });
        var switchStudio = setInterval(function () {
            var moveStudio2 = new TimelineMax();
            moveStudio2.fromTo(JumboPic, 20, { left: "-590px" }, { left: "-100px" })
                .fromTo(JumboPic, 20, { left: "-100px" }, { left: "-590px" });
        }, 41000);
    }

}
function MovePartyLeft() {
    var PartyPic = document.getElementById("PartyPic");
    console.log(winWidth);
    var moveParty = new TimelineMax();
    if (winWidth < 600) {
        moveParty.fromTo(PartyPic, 20, { left: "-70px" }, { left: "-1590px" })
            .fromTo(PartyPic, 20, { left: "-1590px" }, { left: "-70px" });
        var switcher = setInterval(function () {
            var moveParty2 = new TimelineMax();
            moveParty2.fromTo(PartyPic, 20, { left: "-70px" }, { left: "-1590px" })
                .fromTo(PartyPic, 20, { left: "-1590px" }, { left: "-70px" });
        }, 41000);
    } else {
        moveParty.fromTo(PartyPic, 20, { left: "-70px" }, { left: "-590px" })
            .fromTo(PartyPic, 20, { left: "-590px" }, { left: "-70px" });
        var switcher = setInterval(function () {
            var moveParty2 = new TimelineMax();
            moveParty2.fromTo(PartyPic, 20, { left: "-70px" }, { left: "-590px" })
                .fromTo(PartyPic, 20, { left: "-590px" }, { left: "-70px" });
        }, 41000);
    }
}


function itemAdded() {
    console.log("itemAdded init");
    var cartImage = document.getElementById("CartImage");
    cartImage.src = "/Imgs/addedItem.png";
    setTimeout(() => {
        cartImage.src = "/Imgs/addToCart.png"
    }, 1300);
}