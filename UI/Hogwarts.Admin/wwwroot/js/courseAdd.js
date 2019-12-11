layui.use(['form', 'layer'], function () {
    var form = layui.form
    layer = parent.layer === undefined ? layui.layer : top.layer,
        $ = layui.jquery;

    form.on("submit(addCourse)", function (data) {
        if ($("#courseIdLabel").text() == "成功!" || $("#courseNameLabel").text() == "成功!" || $("#englishNameLabel").text() == "成功!") {
            //弹出loading
            var index = top.layer.msg('数据提交中，请稍候', { icon: 16, time: false, shade: 0.8 });
            // 实际使用时的提交信息
            $.ajax({
                url: "/Course/AddCourse",
                type: "POST",
                data: {
                    CourseId: data.field.courseId,
                    CourseName: data.field.courseName,
                    EnglishName: data.field.englishName,
                    CourseScore: data.field.courseScore,
                },
                dataType: "json",
                success: function (res) {
                    if (res == "SUCCEED") {
                        top.layer.close(index);
                        top.layer.msg("课程添加成功！");
                        layer.closeAll("iframe");
                        //刷新父页面
                        parent.location.reload();
                    } else {
                        top.layer.close(index);
                        top.layer.msg("课程添加成功！");
                        layer.closeAll("iframe");
                        //刷新父页面
                        parent.location.reload();
                    }

                }
            });
            return false;
        } else {
            alert("课程重复，请重新输入！");
            return false;
        }
    });
    $("input[name='courseId']").change(function () {
        if ($("input[name='courseId']").val() == "") {
            $("#courseIdLabel").text("课程号");
            return false;
        }
        if ($("input[name='courseId']").val() == "0") {
            $("#courseIdLabel").text("课程号不能为0");
            return false;
        }
        $.ajax({
            url: "/Course/GetCourse",
            type: "POST",
            data: {
                CourseInfo: $(this).val(),
            },
            dataType: "json",
            success: function (res) {
                if (res.msg == "SUCCEED") {
                    $("#courseIdLabel").text("已存在该课程号的课程，请重新输入");
                } else {
                    $("#courseIdLabel").text("成功!");
                }
            }
        });
    });
    $("input[name='courseName']").change(function () {
        if ($("input[name='courseName']").val() == "") {
            $("#courseNameLabel").text("课程名");
            return false;
        }
        $.ajax({
            url: "/Course/GetCourse",
            type: "POST",
            data: {
                CourseInfo: $(this).val(),
            },
            dataType: "json",
            success: function (res) {
                if (res.msg == "SUCCEED") {
                    $("#courseNameLabel").text("已存在该课程名的课程，请重新输入");
                } else {
                    $("#courseNameLabel").text("成功!");
                }
            }
        });
    });
    $("input[name='englishName']").change(function () {
        if ($("input[name='englishName']").val() == "") {
            $("#englishNameLabel").text("英文名");
            return false;
        }
        $.ajax({
            url: "/Course/GetCourse",
            type: "POST",
            data: {
                CourseInfo: $(this).val(),
            },
            dataType: "json",
            success: function (res) {
                if (res.msg == "SUCCEED") {
                    $("#englishNameLabel").text("已存在该课程名的课程，请重新输入");
                } else {
                    $("#englishNameLabel").text("成功!");
                }
            }
        });
    });
})