// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
/* See related post at
https://codepen.io/Javarome/post/full-page-sliding
*/
function ScrollHandler(pageId) {
    var page = document.getElementById(pageId);
    var pageStart = page.offsetTop;
    var pageJump = false;
    var viewStart;
    var duration = 1000;
    var scrolled = document.getElementById("scroll");

    function scrollToPage() {
        pageJump = true;

        // Calculate how far to scroll
        var startLocation = viewStart;
        var endLocation = pageStart;
        var distance = endLocation - startLocation;

        var runAnimation;

        // Set the animation variables to 0/undefined.
        var timeLapsed = 0;
        var percentage, position;

        var easing = function (progress) {
            return progress < 0.5
                ? 4 * progress * progress * progress
                : (progress - 1) * (2 * progress - 2) * (2 * progress - 2) + 1; // acceleration until halfway, then deceleration
        };

        function stopAnimationIfRequired(pos) {
            if (pos == endLocation) {
                cancelAnimationFrame(runAnimation);
                setTimeout(function () {
                    pageJump = false;
                }, 500);
            }
        }

        var animate = function () {
            timeLapsed += 16;
            percentage = timeLapsed / duration;
            if (percentage > 1) {
                percentage = 1;
                position = endLocation;
            } else {
                position = startLocation + distance * easing(percentage);
            }
            scrolled.scrollTop = position;
            runAnimation = requestAnimationFrame(animate);
            stopAnimationIfRequired(position);
            console.log("position=" + scrolled.scrollTop + "(" + percentage + ")");
        };
        // Loop the animation function
        runAnimation = requestAnimationFrame(animate);
    }

    window.addEventListener("wheel", function (event) {
        viewStart = scrolled.scrollTop;
        if (!pageJump) {
            var pageHeight = page.scrollHeight;
            var pageStopPortion = pageHeight / 2;
            var viewHeight = window.innerHeight;

            var viewEnd = viewStart + viewHeight;
            var pageStartPart = viewEnd - pageStart;
            var pageEndPart = pageStart + pageHeight - viewStart;

            var canJumpDown = pageStartPart >= 0;
            var stopJumpDown = pageStartPart > pageStopPortion;

            var canJumpUp = pageEndPart >= 0;
            var stopJumpUp = pageEndPart > pageStopPortion;

            var scrollingForward = event.deltaY > 0;
            if (
                (scrollingForward && canJumpDown && !stopJumpDown) ||
                (!scrollingForward && canJumpUp && !stopJumpUp)
            ) {
                event.preventDefault();
                scrollToPage();
            }
            false; //
        } else {
            event.preventDefault();
        }
    });
}
new ScrollHandler("one");
new ScrollHandler("two");
new ScrollHandler("three");
new ScrollHandler("four");

function credsToggle() {
    $("#credentials").toggle();
}