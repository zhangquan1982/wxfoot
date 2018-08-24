/**
 * Created by yoking on 2017/4/6.
 */
var NProgress = require('./modules/nprogress');
var Swiper = require('./modules/swiper');
NProgress.configure({
    showSpinner: true,
    minimum: 0.22
});
NProgress.start();

$(document).ready(function () {
    "use strict";
    NProgress.done();
    //Navigate
    $(".left-a-nav").click(function (e) {
        var $this = $(this);
        var type = $this.data('type');
        var href = $this.attr('href');
        $(".left-a-nav").removeClass('active');
        $this.addClass('active');
        if (type === 'iframe') {
            e.preventDefault();
            $('#iframe').attr('src',href);
        }
    });
    //日期选择 默认最近一个月内
    var today = function () {
        var now = new Date();
        var year = now.getFullYear()+'';
        var month = now.getMonth()<10?'0'+(now.getMonth()+1):''+(now.getMonth()+1);
        var day = now.getDate()<10?'0'+now.getDate():''+now.getDate();
        return year+'-'+month+'-'+day;
    }
    var preMonth = function () {
        var now = new Date();
        var year = now.getFullYear();
        var preMonth = now.getMonth();
        var day = now.getDate();
        if (preMonth === 0) {
            year = year-1;
            preMonth = 12;
        }
        preMonth = preMonth<10?'0'+preMonth:''+preMonth;
        day = day<10?'0'+day:''+day;
        return year+'-'+preMonth+'-'+day;
    }
    $('#end').val(today());
    $('#beg').val(preMonth());





});