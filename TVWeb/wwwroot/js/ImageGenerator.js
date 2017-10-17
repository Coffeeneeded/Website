

function random() {
    var i = Math.floor(Math.random() * 20) % 4;
    if (i <= 0) return random();
    return i;
}
function execute() {
    var i = random();
    eval('func' + i + '()');
}

function func1() {
    var myArray = ["red", "blue", "green", "pink", "gray", "black", "Yellow", "Lime", "Navy", "Purple", "gold", "aqua", "peru", "brown"];
    var canvas = document.getElementById("myCanvas");
    var ctx = canvas.getContext("2d");
    ctx.font = "70px Comic Sans MS";
    ctx.save();
    ctx.fillStyle = myArray[Math.floor(Math.random() * myArray.length)];
    ctx.textAlign = "center";
    ctx.rotate(15 * (Math.PI / 180));
    ctx.fillText("um", 350, -40);
    ctx.restore();


    ctx.save();
    ctx.fillStyle = myArray[Math.floor(Math.random() * myArray.length)];
    ctx.textAlign = "center";
    ctx.fillText("tres", 250, 200);
    ctx.restore();



    ctx.fillStyle = myArray[Math.floor(Math.random() * myArray.length)];
    ctx.rotate(45 * (Math.PI / 180));
    ctx.fillText("cinco", 250, 131);
}

function func2() {
    var myArray = ["red", "blue", "green", "pink", "gray", "black", "Yellow", "Lime", "Navy", "Purple", "gold", "aqua", "peru", "brown"];
    var canvas = document.getElementById("myCanvas");
    var ctx = canvas.getContext("2d");
    ctx.font = "70px Comic Sans MS";
    ctx.save();
    ctx.fillStyle = myArray[Math.floor(Math.random() * myArray.length)];

    ctx.textAlign = "end";

    ctx.fillText("um", 400, 380);

    ctx.restore();





    ctx.save();

    ctx.rotate(65 * (Math.PI / 180));

    ctx.fillStyle = myArray[Math.floor(Math.random() * myArray.length)];

    ctx.textAlign = "left";

    ctx.fillText("tres", 200, -80);

    ctx.restore();





    ctx.fillStyle = myArray[Math.floor(Math.random() * myArray.length)];

    ctx.textAlign = "Left";

    ctx.fillText("cinco", 0, 61);

}

function func3() {
    var myArray = ["red", "blue", "green", "pink", "gray", "black", "Yellow", "Lime", "Navy", "Purple", "gold", "aqua", "peru", "brown"];
    var canvas = document.getElementById("myCanvas");
    var ctx = canvas.getContext("2d");
    ctx.font = "70px Comic Sans MS";
    ctx.save();
    ctx.fillStyle = myArray[Math.floor(Math.random() * myArray.length)];

    ctx.textAlign = "center";

    ctx.fillText("um", 240, 380);

    ctx.restore();





    ctx.save();

    ctx.rotate(65 * (Math.PI / 180));

    ctx.fillStyle = myArray[Math.floor(Math.random() * myArray.length)];

    ctx.textAlign = "left";

    ctx.fillText("tres", 150, -20);

    ctx.restore();







    ctx.fillStyle = myArray[Math.floor(Math.random() * myArray.length)];

    ctx.textAlign = "Left";

    ctx.rotate(15 * (Math.PI / 180));

    ctx.fillText("cinco", 250, 31);
}

function func4() {
    var myArray = ["red", "blue", "green", "pink", "gray", "black", "Yellow", "Lime", "Navy", "Purple", "gold", "aqua", "peru", "brown"];
    var canvas = document.getElementById("myCanvas");
    var ctx = canvas.getContext("2d");
    ctx.font = "70px Comic Sans MS";
    ctx.save();
    ctx.fillStyle = myArray[Math.floor(Math.random() * myArray.length)];

    ctx.textAlign = "left";

    ctx.fillText("um", 0, 50);

    ctx.restore();





    ctx.save();

    ctx.fillStyle = myArray[Math.floor(Math.random() * myArray.length)];

    ctx.textAlign = "left";

    ctx.fillText("tres", 150, 200);

    ctx.restore();







    ctx.fillStyle = myArray[Math.floor(Math.random() * myArray.length)];

    ctx.textAlign = "end";

    ctx.fillText("cinco", 450, 380);
}



execute();