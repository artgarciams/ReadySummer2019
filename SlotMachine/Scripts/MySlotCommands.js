//
// best practice is to put all functions here, having trouble so i will finish this part later
//


// image list for spinner
var images = [
    '<img src="/Content/Images/seven.png">',
    '<img src="/Content/Images/3bar.png">',
    '<img src="/Content/Images/2bar.png">',
    '<img src="/Content/Images/2bar.png">',
    '<img src="/Content/Images/bar.png">',
    '<img src="/Content/Images/bar.png">',
    '<img src="/Content/Images/bar.png">',
    '<img src="/Content/Images/cherry.png">',
    '<img src="/Content/Images/blank.png">',
    '<img src="/Content/Images/blank.png">',
    '<img src="/Content/Images/blank.png">',
    '<img src="/Content/Images/blank.png">',
    '<img src="/Content/Images/blank.png">',
    '<img src="/Content/Images/blank.png">',
    '<img src="/Content/Images/blank.png">',
    '<img src="/Content/Images/blank.png">',
    '<img src="/Content/Images/blank.png">'];



function Togglebutton(onoff) {

    document.getElementById('playbutton').disabled = onoff;
    document.getElementById('maxbetbutton').disabled = onoff;
    document.getElementById('addcreditbutton').disabled = onoff;
    document.getElementById('Winbutton').disabled = onoff;
    document.getElementById('payoutbutton').disabled = onoff;
};




