layui.use(['form','layer'],function(){
    var form = layui.form
        layer = parent.layer === undefined ? layui.layer : top.layer,
        $ = layui.jquery;

    form.on("submit(addUser)", function (data) {
        //弹出loading
        var index = top.layer.msg('数据提交中，请稍候', { icon: 16, time: false, shade: 0.8 });
        // 实际使用时的提交信息
        $.ajax({
            url: "/Account/AddUser",
            type: "POST",
            data: {
                RoleId: document.getElementById("usergrade").selectedIndex,
                UserName: data.field.username,
                Sex: data.field.sex,
                //NickName: data.field.nickname,
                Password: data.field.password,
                RoleName: data.field.usergrade,
                //Email: data.field.useremail,
                IsInUsing: data.field.userStatus,
                UserDescription: data.field.userdescription,
                CourseId: data.field.courseId,
            },
            dataType: "json",
            success: function (res) {
                if (res == "SUCCEED") {
                    top.layer.close(index);
                    top.layer.msg("用户添加或修改成功！");
                    layer.closeAll("iframe");
                    //刷新父页面
                    parent.location.reload();
                } else {
                    top.layer.close(index);
                    top.layer.msg("用户添加或修改成功！");
                    layer.closeAll("iframe");
                    //刷新父页面
                    parent.location.reload();
                }
                
            }
        });
        return false;
    })

    //格式化时间
    function filterTime(val){
        if(val < 10){
            return "0" + val;
        }else{
            return val;
        }
    }
    //定时发布
    var time = new Date();
    var submitTime = time.getFullYear()+'-'+filterTime(time.getMonth()+1)+'-'+filterTime(time.getDate())+' '+filterTime(time.getHours())+':'+filterTime(time.getMinutes())+':'+filterTime(time.getSeconds());

})