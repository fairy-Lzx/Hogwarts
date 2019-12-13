var form, $,areaData;
layui.config({
    base : "../../js/"
}).extend({
    "address" : "address"
})
layui.use(['form','layer','upload','laydate',"address"],function(){
    form = layui.form;
    $ = layui.jquery;
    var layer = parent.layer === undefined ? layui.layer : top.layer,
        upload = layui.upload,
        laydate = layui.laydate,
        address = layui.address;



    //添加验证规则
    form.verify({
        userBirthday : function(value){
            if(!/^(\d{4})[\u4e00-\u9fa5]|[-\/](\d{1}|0\d{1}|1[0-2])([\u4e00-\u9fa5]|[-\/](\d{1}|0\d{1}|[1-2][0-9]|3[0-1]))*$/.test(value)){
                return "出生日期格式不正确！";
            }
        }
    })
    //选择出生日期
    laydate.render({
        elem: '.userBirthday',
        format: 'yyyy年MM月dd日',
        trigger: 'click',
        max : 0,
        mark : {"0-12-15":"生日"},
        done: function(value, date){
            if(date.month === 12 && date.date === 4){ //点击每年12月4日，弹出提示语
                layer.msg('今天是平元兄的生日，快来送上祝福吧！');
            }
        }
    });

    //获取省信息
    address.provinces();

    //提交个人资料
    form.on("submit(changeSchoolRoll)", function (data) {
        var index = layer.msg('提交中，请稍候', { icon: 16, time: false, shade: 0.8 });

        $.ajax({
            url: "/Student/UpdateSchoolRoll",
            type: "POST",
            data: {
                StudentId: data.field.studentId,
                StudentName: data.field.studentName,
                EnglishName: data.field.englishName,
                Sex:data.field.sex,
                Province:data.field.province,
                City: data.field.city,
                Area: data.field.area,
                Birthday: data.field.birthDay,
                Year: data.field.year,
                ClassId: data.field.classId,
                Character: data.field.character,
                Password: data.field.password,
            },
            dataType: "json",
            success: function (res) {
                top.layer.close(index);
                top.layer.msg("信息修改成功！");
                layer.closeAll("iframe");
                //刷新父页面
                parent.location.reload();
            }
        })
        return false; //阻止表单跳转。如果需要表单跳转，去掉这段即可。
    })

    //修改密码
    form.on("submit(changePwd)",function(data){
        var index = layer.msg('提交中，请稍候',{icon: 16,time:false,shade:0.8});
        setTimeout(function(){
            layer.close(index);
            layer.msg("密码修改成功！");
            $(".pwd").val('');
        },2000);
        return false; //阻止表单跳转。如果需要表单跳转，去掉这段即可。
    })
})