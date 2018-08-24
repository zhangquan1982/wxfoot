/**
 * Created by yoking on 2017/6/4.
 */
var toastr = require('../lib/toastr/toastr');
$(document).ready(function () {
    'use strict';
    var $user = $('#login-userid');
    var $psw = $('#login-password');
    var $submit = $("#login-submit");
    var $logout = $("#logout");
    $submit.click(function (e) {
        var user = $user.val();
        var psw = $psw.val();
        if (!user || !psw) {
            $user.parent().addClass('has-error');
            $psw.parent().addClass('has-error');
            return toastr.warning("请输入用户或者密码");
        }
        $.ajax({
            url:'/login',
            method:'POST',
            data:{
                user:user,
                password:psw
            }
        }).done(function (data) {
            console.log(data);
            toastr.success('登录成功！');
            window.location.href = '/admin';
        }).fail(function (err) {
            console.log(err);
            $user.parent().addClass('has-error');
            $psw.parent().addClass('has-error');
            toastr.warning('登录失败，请重试。');
        });
    });
    $logout.click(function (e) {
        $.ajax({
            url:'/logout',
            method:'POST'
        }).done(function (data) {
            window.location.href = '/login';
        }).fail(function (err) {
            console.log(err);
            toastr.warning('退出失败!');
        })
    });
});