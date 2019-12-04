// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(function () {
    $(".form-login #btn-login").click(function () {
        var t;
        $(".form-login .loading").css("display", "inline-block");
        t = setInterval(function () {
            if ($(".form-login .loading>p").html() == "loading") {
                $(".form-login .loading>p").html("loading.");
            } else if ($(".form-login .loading>p").html() == "loading.") {
                $(".form-login .loading>p").html("loading..");
            } else if ($(".form-login .loading>p").html() == "loading..") {
                $(".form-login .loading>p").html("loading...");
            } else {
                $(".form-login .loading>p").html("loading");
            }
        }, 300);
        $.ajax({
            url: "/Account/Login",
            type: "POST",
            data: {
                UserName: $(".form-login #username").val(),
                Password: $(".form-login #password").val(),
            },
            asycn: false,
            dataType:"json",
            beforeSend: function (res) {
            },
            success: function (res) {
                //if (res.msg == "登陆成功") {
                //    clearInterval(t);
                //    $(".form-login .loading>p").html("登陆成功");
                //} else {
                //    clearInterval(t);
                //    $(".form-login .loading>p").html("登陆失败");
                //}
            }
        });
    })

    $(".form-register #btn-register").click(function () {
        var t;
        $(".form-register .loading").css("display", "inline-block");
        t = setInterval(function () {
            if ($(".form-register .loading>p").html() == "loading") {
                $(".form-register .loading>p").html("loading.");
            } else if ($(".form-register .loading>p").html() == "loading.") {
                $(".form-register .loading>p").html("loading..");
            } else if ($(".form-register .loading>p").html() == "loading..") {
                $(".form-register .loading>p").html("loading...");
            } else {
                $(".form-register .loading>p").html("loading");
            }
        }, 300);
        $.ajax({
            url: "/Account/RegisterApi",
            type: "POST",
            data: {
                UserName: $(".form-register #username").val(),
                Password: $(".form-register #password").val(),
            },
            asycn: false,
            dataType: "text",
            beforeSend: function (res) {
            },
            success: function (res) {
                //window.location.href = "/Home/Index";
                //if (res.msg == "登陆成功") {
                //    clearInterval(t);
                //    $(".form-register .loading>p").html("注册成功");
                //} else {
                //    clearInterval(t);
                //    $(".form-register .loading>p").html("注册失败");
                //}
            }
        });
    })
})