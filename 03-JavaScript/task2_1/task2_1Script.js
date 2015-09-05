// JavaScript source code
function Timer(increment)
{
    var incValue = 1;         // value of increment
    var incInterval = 2000;   // interval for increment
    var decInterval = 1000;   // interval for decrement
    var minValue = 1;         // range from 1
    var maxValue = 10;        //  to 10
    var timerTimeOut = 40000; // script working time
    var incTimeOut = 25000;   // increment time
    var decTimeOut = 15000;   // decrement time
    var timerCurValue = 1;    // current value of timer
    var incHandler = 0;       // handler for increment interval
    var decHandler = 0;       // handler for decrement interval
    var timerHandler = 0;     // handler for timer
    var reverseHandle = 0;    // handler for decrement timeout

    var Increment = function ()
    {
        // overflow?
        if (timerCurValue < maxValue)
            timerCurValue += incValue;
		else // reset if overflow
            timerCurValue = minValue;
        // display on html page
        Display();
    }
    var Decrement = function ()
    {
        // overflow?
        if (timerCurValue > minValue)
            timerCurValue -= incValue;
        else // reset if overflow
            timerCurValue = maxValue;
        // display on html page
        Display();
        
    }
    var Display = function ()
    {
        var timerDisplay = document.getElementById("timer");
        if (timerDisplay.hasChildNodes()) // check if text exist
        {
            // remove old timer value
            timerDisplay.removeChild(timerDisplay.firstChild);
        }
        // insert new timer value
        timerDisplay.appendChild(document.createTextNode(timerCurValue));
    }
    // stop incrementing
    var stopIncrement = function ()
    {
        clearInterval(incHandler); 
    }
    // stop decrementing
    var stopDecrement = function ()
    {
        clearInterval(decHandler); 
    }
    // timer go forward
    var forward = function ()
    {
        incHandler = setInterval(Increment, incInterval);
    }
    // timer go backwards
    var reverse = function ()
    {
        decHandler = setInterval(Decrement, decInterval);
    }
    // stop timer
    var stopTimer = function ()
    {
        clearInterval(timerHandler); // stop timer interval
        clearTimeout(reverseHandle); // cancel postpone decrement
        stopDecrement();
        stopIncrement();
    }
    var TimerWork = function ()
    {
        forward();
        setTimeout(stopIncrement, incTimeOut);
        reverseHandle = setTimeout(reverse, incTimeOut);    // postpone decrement on increment timeout
        setTimeout(stopDecrement, incTimeOut + decTimeOut);
    }
    this.Start = function ()
    {
        Display();
        TimerWork();
        var timerCycle = incTimeOut + decTimeOut;
        // check if timer timeout is bigger than timer cycle
        if (timerTimeOut > timerCycle)
        {
            // start function again
            timerHandler = setInterval(TimerWork, timerCycle);
            setTimeout(stopTimer, timerTimeOut);
        }
    }
}
window.onload = function ()
{
    var timer = new Timer();
    timer.Start();
}