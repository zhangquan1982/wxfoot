/**
 * Created by yoking on 2017/5/7.
 */
'use strict';
$(document).ready(function () {
    $(".leftbar-fold").unbind('click').click(function (e) {
        e.preventDefault();
        $(this).toggleClass("leftbar-unfold");
        $(".main-body").toggleClass("leftbar-full");
    });
    var $leftbarTit = $(".leftbar-title");
    $leftbarTit.unbind('click').click(function (e) {
        //$(".leftbar-nav").removeClass("leftbar-nav-active");
        //$("ul.leftbar-trans").removeClass("open");
        $("ul.leftbar-trans").height(0);
        e.preventDefault();
        $(".leftbar-title").css("background-color", "black");
        if ($(this).parent().hasClass("leftbar-nav-active")) {
            //do nothing
            //$("ul.leftbar-trans").removeClass("open");
            //$("ul.leftbar-trans").height(0);
            $(this).parent().removeClass("leftbar-nav-active");
            $(this).parent().children("ul.leftbar-trans").removeClass("open");
            $(this).parent().children("ul.leftbar-trans").height(0);
            //$(this).parent().addClass("leftbar-nav-active");
            //$(this).next().addClass('open').height($(this).next().find('li').length * 40);
        } else {

            $("ul.leftbar-trans").removeClass("leftbar-nav-active");
            $("ul.leftbar-trans").children("ul.leftbar-trans").removeClass("open");
            $("ul.leftbar-trans").height(0);
      
            $(this).parent().addClass("leftbar-nav-active");
            $(this).next().addClass('open').height($(this).next().find('li').length * 40);

            $(this).parent().children(".leftbar-nav").addClass("open");
            $(this).parent().children("ul.leftbar-trans").addClass("open");
            $(this).css("background-color", "#009933");

            //$(this).parent().children(".leftbar-nav").addClass("open");
            //$(this).parent().children("ul.leftbar-trans").addClass("open");
            //$(this).parent().children("ul.leftbar-trans").height($(this).next().find('li').length * 40);

   
        }
    });
    //默认打开菜单
    $("ul.leftbar-trans.open").height($("ul.leftbar-trans.open").find('li').length*40);

});