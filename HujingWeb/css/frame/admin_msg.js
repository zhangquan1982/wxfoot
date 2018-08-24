/**
 * Created by yoking on 2017/5/25.
 */
"use strict";
var toastr = require('../lib/toastr/toastr');
$(document).ready(function () {
    var $send = $("#pushMsg");
    $send.click(function () {
        var fromUid = $("#from-userid").val();
        var toUid = $("#to-userid").val();
        var msg = $("#inputPushMsg").val();
        if (!msg) return toastr.warning('请输入消息内容！');
        if (!fromUid) return toastr.warning('发送人信息不正确！');
        if (!toUid) return toastr.warning('接收人信息不正确！');
        $.ajax({
            url:'/admin/msg',
            method:'POST',
            data:{
                'msg':msg,
                'fromUser':fromUid,
                'toUser':toUid
            }
        }).done(function (data) {
            console.info('推送成功:',data);
            toastr.success('消息推送成功！');
        }).fail(function (err) {
            console.info('推送错误:',err);
            toastr.warning('消息推送失败！');
        })
    });


});