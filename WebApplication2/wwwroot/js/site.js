// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
/* See related post at
https://codepen.io/Javarome/post/full-page-sliding
*/
window.addEventListener('wheel', function(e) {
    e.preventDefault();
    var one = document.getElementById('one');
    var two = document.getElementById('two');
    var three = document.getElementById('three');
    var four = document.getElementById('four');

    if (e.deltaY < 0) {
        if (two.getBoundingClientRect().x == 0 && two.getBoundingClientRect().y == 0) {
            one.scrollIntoView({ behavior: 'smooth' })
        }
        else if (three.getBoundingClientRect().x == 0 && three.getBoundingClientRect().y == 0) {
            two.scrollIntoView({ behavior: 'smooth' })
        }
        else if (four.getBoundingClientRect().x == 0 && four.getBoundingClientRect().y == 0) {
            three.scrollIntoView({ behavior: 'smooth' })
        }

    }
    if (e.deltaY > 0) {
        if (one.getBoundingClientRect().x == 0 && one.getBoundingClientRect().y == 0) {
            two.scrollIntoView({ behavior: 'smooth' })
        }
        else if (two.getBoundingClientRect().x == 0 && two.getBoundingClientRect().y == 0) {
            three.scrollIntoView({ behavior: 'smooth' })
        }
        else if (three.getBoundingClientRect().x == 0 && three.getBoundingClientRect().y == 0) {
            four.scrollIntoView({ behavior: 'smooth' })
        }
    }
});
