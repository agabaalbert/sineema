$(document).ready(function () {
    VideoLib.init();
});

var VideoLib = VideoLib || function () {
    var init = function () {
        VideoLib.util.init();
        VideoLib.setHeadElement.init();
        VideoLib.switchMoviePresentation.init();
        //VideoLib.changeMe.init();
    };
    return {
        init: init
    };
}();


VideoLib.util = function(){

    function init() {
        ie10ViewportFix();
    }

    function ie10ViewportFix() {
        if (navigator.userAgent.match(/IEMobile\/10\.0/)) {
            var msViewportStyle = document.createElement('style');
            msViewportStyle.appendChild(
                document.createTextNode(
                    '@-ms-viewport{width:auto!important}'
                )
            );
            document.querySelector('head')/*.appendChild(msViewportStyle)*/;
        }
    }

    return {
        init: init
    };
}();

VideoLib.setHeadElement = function () {

    var h1Ele;

    function init() {
        h1Ele = $('h1');

        //don't go further if there is no container
        if (!h1Ele.length) { return }

        privateFunc();

        var GodwinInput = $("#GodwinInput");
        var result = VideoLib.calculateGodwinAge.calculator(GodwinInput.val());
        $(".result").html(result);

        GodwinInput.on('blur', function () {
            var newAge = $(this).val();
            var result2 = VideoLib.calculateGodwinAge.calculator(newAge);
            $(".result").html(result2);
        });
    }

    function privateFunc() {
        h1Ele.html("Dashboard");
    }

    // public function to be called like VideoLib.changeMe.publicFunc();
    function publicFunc() {
        console.log('public');
    }

    return {
        init: init,
        publicFunc: publicFunc
    };
}();


VideoLib.switchMoviePresentation = function () {

    var movieOptions;

    function init() {
        movieOptions = $('.movie-options');

        //don't go further if there is no container
        if (!movieOptions.length) { return }
        
        $('.movies-grid').hide();

        movieOptions.on('click', '.movie-grid', function() {
            $('.movies-list').hide();
            $('.movies-grid').show();
        });

        movieOptions.on('click', '.movie-list', function () {
            $('.movies-grid').hide();
            $('.movies-list').show();
        });

    }

    return {
        init: init
    }
}();

/***************************
* Template for new modules
****************************
VideoLib.changeMe = function(){

    var elem1;

    function init() {
        elem1 = $('#elem1');

        //don't go further if there is no container
        if(!elem1.length){return}

        privateFunc();
    }

    function privateFunc() {
        console.log('private')
    }

    // public function to be called like VideoLib.changeMe.publicFunc();
    function publicFunc() {
        console.log('public')
    }

    return {
        init: init,
        publicFunc: publicFunc
    }
}();
 */





