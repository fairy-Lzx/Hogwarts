layui.use(['form', 'layer'], function () {
    var form = layui.form
    layer = parent.layer === undefined ? layui.layer : top.layer,
        $ = layui.jquery;

    form.on("submit(addClass)", function (data) {
        //弹出loading
        var index = top.layer.msg('数据提交中，请稍候', { icon: 16, time: false, shade: 0.8 });
        // 实际使用时的提交信息
        $.ajax({
            url: "/Class/AddClass",
            type: "POST",
            data: {
                ClassId: data.field.classId,
                ClassName: data.field.className,
                ClassDean: data.field.classDean,
            },
            dataType: "json",
            success: function (res) {
                if (res == "SUCCESS") {
                    top.layer.close(index);
                    top.layer.msg("学院添加或修改成功！");
                    layer.closeAll("iframe");
                    //刷新父页面
                    parent.location.reload();
                } else {
                    top.layer.close(index);
                    top.layer.msg("学院添加或修改失败！");
                    layer.closeAll("iframe");
                    //刷新父页面
                    parent.location.reload();
                }

            }
        });
        return false;
    });
})