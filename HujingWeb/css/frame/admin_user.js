/**
 * Created by yoking on 2017/5/8.
 */
"use strict";
var toastr = require('../lib/toastr/toastr');
$(document).ready(function () {
    var options = {
        page:1
    }
    var $userAdd = $('#users_add');
    var $tbinfo = $("#tbinfo");
    var $pagination = $('ul.pagination');
    //批量添加用户
    $userAdd.on('click',function (e) {
        e.preventDefault();
        var users = [];
        $tbinfo.find('input[type="checkbox"]').each(function () {
            if ($(this).prop('checked')) {
                var user = $(this).val();
                users.push(user);
            }
        });
        if (users.length === 0) {
            toastr.warning('没有选择用户！', '警告');
            return
        }
        //转为json格式
        users = JSON.stringify(users);
        $.confirm({
            title: '同步用户数据',
            content: '把用户添加到IM数据库',
            type: 'blue',
            buttons: {
                ok: {
                    text: "确定",
                    btnClass: 'btn-primary',
                    keys: ['enter'],
                    action: function(){
                        addUsers(users);
                    }
                },
                cancel: {
                    text:"取消",
                    action: function(){
                        toastr.info('操作被取消了。');
                    }
                }
            }
        });

    });
    //批量更新用户
    $("#users_update").click(function (e) {
        e.preventDefault();
        var users = [];
        $tbinfo.find('input[type="checkbox"]').each(function () {
            if ($(this).prop('checked')) {
                var user = $(this).val();
                users.push(user);
            }
        });
        if (users.length === 0) {
            toastr.warning('没有选择用户！', '警告');
            return
        }
        //转为json格式
        users = JSON.stringify(users);
        $.confirm({
            title: '更新用户数据',
            content: '更新用户信息至IM系统',
            type: 'blue',
            buttons: {
                ok: {
                    text: "确定",
                    btnClass: 'btn-primary',
                    keys: ['enter'],
                    action: function(){
                        updateUsers(users);
                    }
                },
                cancel: {
                    text:"取消",
                    action: function(){
                        toastr.info('操作被取消了。');
                    }
                }
            }
        });

    });
    $("#ckSelectAll").click( function () {
        var $this = $(this);
        if ($this.is(':checked')){
            $tbinfo.find('input[type="checkbox"]').prop('checked',true);
            $("#ckSelectAll2").prop('checked',true);
        }else{
            $tbinfo.find('input[type="checkbox"]').prop('checked',false);
            $("#ckSelectAll2").prop('checked',false);
        }
    });
    $("#ckSelectAll2").click(function () {
        $("#ckSelectAll").click();
    });
    //ajax 加载用户
    $("#loadmoreuser").click(function (e) {
        e.preventDefault();
        var page = options.page + 1;
        options.page = page;
        var url = '/admin/user?page='+page;
        $.ajax({
            url:url,
            method:'GET'
        }).done(function (data) {
            //console.log(data);
            var users = data.users;
            if (users.length === 0 ){
                return toastr.info('没有更多数据了!');
            }
            var htmls = [];
            users.forEach(function (user) {
                user.CreateDate = new Date(user.CreateDate).toLocaleDateString();
                var html = '<tr><td><input type="checkbox" name="ckbox" value="'+ user.Id +'|'+ user.Account +'|'+ user.Password +'|'+user.NickName+'|'+user.UserPortrait +'"></td>';
                    html += '<td>'+user.Id+'</td>';
                    html += '<td>'+user.Account+'</td>';
                    html += '<td>'+user.NickName+'</td>';
                    html += '<td>'+user.UserPortrait+'</td>';
                    html += '<td>'+user.Gender+'</td>';
                    html += '<td>'+user.UserType+'</td>';
                    html += '<td>'+user.CreateDate+'</td></tr>';
                htmls.push(html);
            });
            $('#tbinfo').append(htmls.join(''));
        }).fail(function (err) {
            console.info('get users err!',err);
            toastr.warning('获取用户数据失败！');
        });

    });
    //分页处理(iframe);
    var pagination = function (total,count) {
        var total = parseInt(total,10);
        var count = parseInt(count,10) || 20;
        var pagesize = total/count;
        if (Math.floor(pagesize) !== pagesize) pagesize += 1;
        if (!total) return;



    }($pagination.attr('data-total'),$pagination.attr('data-count'));
    //解析iframe URL
    var getUrlParam = function (name) {
        var search = parent.document.getElementById("#iframe").contentWindow.location.search;
        if (!search || !name ) return null;
        var params = search.substring(1).split('&');
        for (var i = 0;i<params.length;i++){
            if (params[i].indexOf(name) !== -1){
                return params[i].substring(params[i].indexOf('=')+1);
            }
        }
        return null;
    }
    //一键同步
    $("#sync").click(function (e) {        
        $.confirm({
            title: '一键同步用户数据',
            content: '一键同步用户信息至IM系统',
            type: 'blue',
            buttons: {
                ok: {
                    text: "确定",
                    btnClass: 'btn-primary',
                    keys: ['enter'],
                    action: function(){
                        $(".container-body").html('<div class="alert alert-success text-center" role="alert">用户数据同步中...</div>');
                        var url = '/admin/user/sync', beginPage = 1, pageSize = 100;
                        var syncUsers = function (page,size) {
                            $(".container-body").html('<div class="alert alert-success text-center" role="alert">同步前'+ page*size +'名用户数据...</div>');
                            $.ajax({
                                url:url,
                                method:'POST',
                                data:{
                                    page:page,
                                    size:size
                                }
                            }).done(function (data) {
                                $(".container-body").html('<div class="alert alert-success text-center" role="alert">前'+ page*size +'名用户数据同步成功！</div>');
                                if (data !== 'no user') {
                                    beginPage += 1;
                                    setTimeout(function () {
                                        syncUsers(beginPage,pageSize);
                                    },1000);
                                } else if(data === 'no user') {
                                    $(".container-body").html('<div class="alert alert-success text-center" role="alert">所有用户数据同步成功！</div>');
                                }
                            }).fail(function (error) {
                                console.info('更新用户数据失败',error);
                                $(".container-body").html('<div class="alert alert-danger text-center" role="alert">用户数据同步失败！</div>');
                            });
                        };
                        syncUsers(beginPage,pageSize);
                    }
                },
                cancel: {
                    text:"取消",
                    action: function(){
                        toastr.info('操作被取消了。');
                    }
                }
            }
        });
    });
    //一键更新
    $("#sync_update").click(function (e) {
        $.confirm({
            title: '一键更新用户资料',
            content: '一键更新用户头像、昵称等资料至IM系统',
            type: 'blue',
            buttons: {
                ok: {
                    text: "确定",
                    btnClass: 'btn-primary',
                    keys: ['enter'],
                    action: function(){
                        $(".container-body").html('<div class="alert alert-success text-center" role="alert">用户数据同步更新中...</div>');
                        var url = '/admin/user/sync', beginPage = 1, pageSize = 100;
                        var syncUsers = function (page,size) {
                            $(".container-body").html('<div class="alert alert-success text-center" role="alert">更新前'+ page*size +'名用户数据...</div>');
                            $.ajax({
                                url:url,
                                method:'PUT',
                                data:{
                                    page:page,
                                    size:size
                                }
                            }).done(function (data) {
                                //console.log(data);
                                $(".container-body").html('<div class="alert alert-success text-center" role="alert">前'+ page*size +'名用户数据更新成功！</div>');
                                if (data !== 'no user') {
                                    beginPage += 1;
                                    setTimeout(function () {
                                        syncUsers(beginPage,pageSize);
                                    },1000);
                                } else if(data === 'no user') {
                                    $(".container-body").html('<div class="alert alert-success text-center" role="alert">所有用户数据更新成功！</div>');
                                }
                            }).fail(function (error) {
                                console.info('更新用户数据失败',error);
                                $(".container-body").html('<div class="alert alert-danger text-center" role="alert">用户数据更新失败！</div>');
                            });
                        };
                        syncUsers(beginPage,pageSize);
                    }
                },
                cancel: {
                    text:"取消",
                    action: function(){
                        toastr.info('操作被取消了。');
                    }
                }
            }
        });
    });

    var addUsers = function (users) {
        $.ajax({
            url:"/admin/user",
            method:'POST',
            data:{users:users}
        }).done(function (data) {
            //console.log(data);
            toastr.success('用户添加到IM系统成功！', '操作成功！');
        }).fail(function (error) {
            console.log(error);
            toastr.error('用户添加到IM系统失败！', '操作失败！');
        });
    }
    var updateUsers = function (users) {
        $.ajax({
            url:'/admin/user',
            method:'PUT',
            data:{users:users}
        }).done(function (data) {
            //console.log(data);
            toastr.success('用户信息更新成功！', '操作成功！');
        }).fail(function (error) {
            console.log(error);
            toastr.error('用户信息更新成功！', '操作失败！');
        });
    }
});