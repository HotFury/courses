// JavaScript source code
function Slider()
{
    var interval = 2000; // interval 2 seconds
    var slideInterval = 1000; // animation interval
    var firstImageNum = 0;
    var curImageNum = 0; // image number
    var images = ["image1.jpg", "image2.jpeg", "image3.jpeg", "image4.jpg", "image5.jpg"];
    var imageWidth = 500;
    var lastImageNum = images.length - 1;
    var $prev = $("#prev");  // previous image
    var $curr = $("#curr");  // current image
    var $next = $("#next");  // next image
    var sliderHandler;
    var slideFinished = true;
    var GetPrevNum = function () {
        if (curImageNum > 0)
            return curImageNum - 1;
        else
            return lastImageNum;
    }
    var GetNextNum = function () {
        if (curImageNum < lastImageNum)
            return curImageNum + 1;
        else
            return firstImageNum;
    }
    var GoNext = function () {
        if (curImageNum < lastImageNum)
            curImageNum++;
        else
            curImageNum = firstImageNum;
    }
    var GoPrev = function () {
        if (curImageNum > firstImageNum)
            curImageNum--;
        else
            curImageNum = lastImageNum;
    }
    var AddAlias = function () {
        $('.alias').empty();
        $('.alias').append((curImageNum + 1) + "/" + (lastImageNum + 1));
    }
    var Init = function () {
        $prev.empty();
        $curr.empty();
        $next.empty();
        $prev.append("<img src='./images/" + images[GetPrevNum()] + "' alt='unavailable'/>");
        $curr.append("<img src='./images/" + images[curImageNum] + "' alt='unavailable'/>");
        $next.append("<img src='./images/" + images[GetNextNum()] + "' alt='unavailable'/>");
        AddAlias();
    }
    var ChangeState = function(prevWidth, currBlockWidth, nextWidth){
        $prev.css('width', prevWidth + "px");
        $curr.css('width', currBlockWidth + "px");
        $next.css('width', nextWidth + "px");
    }
    // offset images after sliding
    var Swap = function () {
        Init();
        ChangeState(0, imageWidth, 0);
    }
    this.Next = function (width) {
        if (!$curr.is(':animated')) {
            if (typeof (width) === "undefined") {
                $curr.animate({ width: '-=' + imageWidth + "px" }, slideInterval);
                $next.animate({ width: '+=' + imageWidth + "px" }, slideInterval, function () {
                    GoNext();
                    Swap();
                    slideFinished = true;
                });
            }
            else {
                $curr.animate({ width: '-=' + width + "px" }, slideInterval);
                $next.animate({ width: '+=' + width + "px" }, slideInterval, function () {
                    if (slideFinished)
                        GoNext();
                    Swap();
                    slideFinished = true;
                });
            }
        }
        else if ($prev.is(':animated')) {
            slideFinished = !slideFinished;
            $curr.stop();
            $prev.stop();
            var prevWidth = $prev.css('width').replace("px", "");
            var width = imageWidth - prevWidth;
            $next.empty();
            $next.append($curr.children('img'));
            $curr.empty();
            $curr.append($prev.children('img'));
            ChangeState(0, prevWidth, width);
            this.Next(prevWidth);
        }
        
    }
    this.Prev = function (width) {
        if (!$curr.is(':animated')) {  // do this if element NOT animating now
            if (typeof (width) === "undefined") {
                $curr.animate({ width: '-=' + imageWidth + "px" }, slideInterval);
                $prev.animate({ width: '+=' + imageWidth + "px" }, slideInterval, function () {
                    GoPrev();
                    Swap();
                    slideFinished = true;
                });
            }
            else {
                $curr.animate({ width: '-=' + width + "px" }, slideInterval);
                $prev.animate({ width: '+=' + width + "px" }, slideInterval, function () {
                    if (slideFinished)
                        GoPrev();
                    Swap();
                    slideFinished = true;
                });
            }
        }
        else if ($next.is(':animated')) {
            slideFinished = !slideFinished;
            $curr.stop();
            $next.stop();
            var nextWidth = $next.css('width').replace("px", "");
            var width = imageWidth - nextWidth;
            $prev.empty();
            $prev.append($curr.children("img"));
            $curr.empty();
            $curr.append($next.children("img"));
            ChangeState(width, nextWidth, 0);
            this.Prev(nextWidth);

        }
    }
    this.PrepareToStart = function () {
        Init();
    }
    this.Start = function () {
        //Init();
        sliderHandler = setInterval(this.Next, interval);
    }
    this.Stop = function () {
        clearInterval(sliderHandler);
    }
}
$(document).ready(function () {
    var slider = new Slider();
    slider.PrepareToStart();
    slider.Start();
    $('#nextbutton').click(function () {
        slider.Stop();
        slider.Next();
        slider.Start();
    });
    $('#prevbutton').click(function () {
        slider.Stop();
        slider.Prev();
        slider.Start();
    });
});