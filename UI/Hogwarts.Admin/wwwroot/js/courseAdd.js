layui.use(['form', 'layer'], function () {
    var form = layui.form
    layer = parent.layer === undefined ? layui.layer : top.layer,
        $ = layui.jquery;

    form.on("submit(addCourse)", function (data) {
        //弹出loading
        var index = top.layer.msg('数据提交中，请稍候', { icon: 16, time: false, shade: 0.8 });
        // 实际使用时的提交信息
        $.ajax({
            url: "/Course/AddCourse",
            type: "POST",
            data: {
                CourseId: data.field.courseId,
                CourseName: data.field.courseName,
                CourseScore: data.field.courseScore,
            },
            dataType: "json",
            success: function (res) {
                if (res == "SUCCEED") {
                    top.layer.close(index);
                    top.layer.msg("学院添加成功！");
                    layer.closeAll("iframe");
                    //刷新父页面
                    parent.location.reload();
                } else {
                    top.layer.close(index);
                    top.layer.msg("学院添加成功！");
                    layer.closeAll("iframe");
                    //刷新父页面
                    parent.location.reload();
                }

            }
        });
        return false;
    });
})