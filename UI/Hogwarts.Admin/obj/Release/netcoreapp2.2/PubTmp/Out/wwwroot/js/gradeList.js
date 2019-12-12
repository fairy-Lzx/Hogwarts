layui.use(['form', 'layer', 'table', 'laytpl'], function () {
    var form = layui.form,
        layer = parent.layer === undefined ? layui.layer : top.layer,
        $ = layui.jquery,
        laytpl = layui.laytpl,
        table = layui.table;

    //用户列表
    var tableIns = table.render({
        elem: '#gradeList',
        url: '/Grade/Grades',
        cellMinWidth: 95,
        page: true,
        height: "full-125",
        limits: [10, 15, 20, 25],
        limit: 10,
        id: "gradeListTable",
        cols: [[
            { type: "checkbox", fixed: "left", width: 50 },
            { field: "rowId", title: 'ID', width: 60, fixed: "left", sort: "true", align: 'center', edit: 'text' },
            //{field: 'nickName', title: '昵称', minWidth:100, align:"center"},
            { field: 'studentId', title: '学号', minWidth: 100, align: "center" },
            //{field: 'userEmail', title: '用户邮箱', minWidth:200, align:'center',templet:function(d){
            //    return '<a class="layui-blue" href="mailto:'+d.userEmail+'">'+d.userEmail+'</a>';
            { field: 'studentName', title: '学生名', minWidth: 100, align: "center" },
            { field: 'englishName', title: '英文名', minWidth: 100, align: "center" },
            { field: 'courseId', title: '课程号', minWidth: 100, align: "center" },
            //{ field: 'birthday', title: '生日', minWidth: 100, align: "center" },
            { field: 'courseName', title: '课程名', minWidth: 100, align: "center" },
            { field: 'courseCredit', title: '课程学分', minWidth: 100, align: "center" },
            { field: 'score', title: '成绩', minWidth: 100, align: "center" },
            //{ field: 'courseClass', title: '开课院系', minWidth: 100, align: "center" },
            //{ field: 'courseName', title: '课程名', minWidth: 100, align: "center" },
            //}
            //{ field: 'realName', title: '名字', minWidth: 100, align: "center" },
            //{ field: 'englishName', title: '英文名', minWidth: 100, align: "center" },
            //{
            //    field: 'sex', title: '用户性别', width: 120, align: 'center', templet: function (d) {
            //        if (d.sex == null) return "就不告诉你";
            //        return d.sex;
            //    }
            //},
            //{
            //    field: 'userStatus', title: '用户状态', align: 'center', templet: function (d) {
            //        return d.userStatus == true ? "正常使用" : "限制使用";
            //    }
            //},
            //{ field: 'roleName', title: '职位', align: 'center' },
            //{field: 'userEndTime', title: '最后登录时间', align:'center',minWidth:150},
            { title: '操作', minWidth: 175, templet: '#gradeListBar', fixed: "right", align: "center" }
        ]]
    });


    form.on('select(courseId)', function (data) {
        console.log(data.value); //得到被选中的值
        $("#scoreLabel").text("分数");
        $.ajax({
            url: "/Grade/GetGrade",
            data: {
                StudentId: $("#studentId").val(),
                CourseId: data.value,
            },
            type: "POST",
            dataType: "json",
            success: function (res) {
                if (res.code == 0) {
                    $("#score").val(res.data.score);
                    $("#scoreLabel").text("改学生，改科目已录入过了，若再次点击录入，会起到修改的效果");
                }
            }
        });
        tableIns = table.render({
            elem: '#gradeList',
            url: '/Grade/Grades?courseId=' + data.value,
            cellMinWidth: 95,
            page: true,
            height: "full-125",
            limits: [10, 15, 20, 25],
            limit: 10,
            id: "gradeListTable",
            cols: [[
                { type: "checkbox", fixed: "left", width: 50 },
                { field: "rowId", title: 'ID', width: 60, fixed: "left", sort: "true", align: 'center', edit: 'text' },
                //{field: 'nickName', title: '昵称', minWidth:100, align:"center"},
                { field: 'studentId', title: '学号', minWidth: 100, align: "center" },
                //{field: 'userEmail', title: '用户邮箱', minWidth:200, align:'center',templet:function(d){
                //    return '<a class="layui-blue" href="mailto:'+d.userEmail+'">'+d.userEmail+'</a>';
                { field: 'studentName', title: '学生名', minWidth: 100, align: "center" },
                { field: 'englishName', title: '英文名', minWidth: 100, align: "center" },
                { field: 'courseId', title: '课程号', minWidth: 100, align: "center" },
                //{ field: 'birthday', title: '生日', minWidth: 100, align: "center" },
                { field: 'courseName', title: '课程名', minWidth: 100, align: "center" },
                { field: 'courseCredit', title: '课程学分', minWidth: 100, align: "center" },
                { field: 'score', title: '成绩', minWidth: 100, align: "center" },
                //{ field: 'courseClass', title: '开课院系', minWidth: 100, align: "center" },
                //{ field: 'courseName', title: '课程名', minWidth: 100, align: "center" },
                //}
                //{ field: 'realName', title: '名字', minWidth: 100, align: "center" },
                //{ field: 'englishName', title: '英文名', minWidth: 100, align: "center" },
                //{
                //    field: 'sex', title: '用户性别', width: 120, align: 'center', templet: function (d) {
                //        if (d.sex == null) return "就不告诉你";
                //        return d.sex;
                //    }
                //},
                //{
                //    field: 'userStatus', title: '用户状态', align: 'center', templet: function (d) {
                //        return d.userStatus == true ? "正常使用" : "限制使用";
                //    }
                //},
                //{ field: 'roleName', title: '职位', align: 'center' },
                //{field: 'userEndTime', title: '最后登录时间', align:'center',minWidth:150},
                { title: '操作', minWidth: 175, templet: '#gradeListBar', fixed: "right", align: "center" }
            ]]
        });
    });

    $("#courseId").change(function () {
        alert("ok");
    })

    form.on("submit(addStudent-btn)", function (data) {
        //弹出loading
        if ($("#studentName").val() == "自动识别学生名字") {
            alert("无该学生，请重新输入");
            return false;
        }
        var index = top.layer.msg('数据提交中，请稍候', { icon: 16, time: false, shade: 0.8 });
        // 实际使用时的提交信息
        $.ajax({
            url: "/Grade/AddGrade",
            type: "POST",
            data: {
                Sno: data.field.studentId,
                Cno: data.field.courseId,
                Score: data.field.score,
            },
            dataType: "json",
            success: function (res) {
                if (res.msg == "SUCCEED") {
                    top.layer.close(index);
                    top.layer.msg("成绩录入或修改成功！");
                    //layer.closeAll("iframe");
                    //刷新父页面
                    tableIns.reload();
                } else {
                    top.layer.close(index);
                    top.layer.msg("成绩录入或修改失败！");
                    //layer.closeAll("iframe");
                    //刷新父页面
                    //parent.location.reload();
                }
            }
        });
        return false;
    })

    table.on('tool(gradeList)', function (obj) {
        var layEvent = obj.event,
            data = obj.data;

        if (layEvent === 'edit') { //编辑
            EditStudent(data);
        } else if (layEvent === 'usable') { //启用禁用
            var _this = $(this),
                usableText = "是否确定禁用此用户？",
                btnText = "已禁用";
            if (_this.text() == "已禁用") {
                usableText = "是否确定启用此用户？",
                    btnText = "已启用";
            }
            layer.confirm(usableText, {
                icon: 3,
                title: '系统提示',
                cancel: function (index) {
                    layer.close(index);
                }
            }, function (index) {
                _this.text(btnText);
                layer.close(index);
            }, function (index) {
                layer.close(index);
            });
        } else if (layEvent === 'del') { //删除
            layer.confirm('确定删除此成绩？', { icon: 3, title: '提示信息' }, function (index) {
                //$.get("/Account/DeleteUser",{
                //    newsId : data.newsId  //将需要删除的newsId作为参数传入
                //},function(data){
                //   tableIns.reload();
                //   layer.close(index);
                // })
                var index = top.layer.msg('数据提交中，请稍候', { icon: 16, time: false, shade: 0.8 });
                $.ajax({
                    url: "/Grade/DeleteGrade",
                    type: "POST",
                    data: {
                        StudentId: data.studentId,
                        CourseId: data.courseId,
                    },
                    dataType: "json",
                    success: function (res) {
                        tableIns.reload();
                        layer.close(index);
                    }
                })
            });
        }
    });

    //搜索【此功能需要后台配合，所以暂时没有动态效果演示】
    $(".search_btn").on("click", function () {
        if ($(".searchVal").val() != '') {

            table.reload("newStudentListTable", {
                page: {
                    curr: 1 //重新从第 1 页开始
                },
                where: {
                    key: $(".searchVal").val()  //搜索的关键字
                }
            })
        } else {
            layer.msg("请输入搜索的内容");
        }
    });

    //添加用户
    function EditStudent(edit) {
        var para = "";
        if (typeof (edit) != "undefined") {
            para = "?StudentId=" + edit.studentId;
        }
        var index = layui.layer.open({
            title: "添加用户",
            type: 2,
            content: "/Student/EditSchoolRoll" + para,
            success: function (layero, index) {
                var body = layui.layer.getChildFrame('body', index);
                //if (edit) {
                //    body.find(".nickName").val(edit.nickName);
                //    body.find(".userName").val(edit.userName);  //登录名
                //    body.find(".userEmail").val(edit.userEmail);  //邮箱
                //    body.find(".userSex input[value=" + edit.userSex + "]").attr("checked", "checked");  //性别
                //    body.find(".userGrade").val(edit.userGrade);  //会员等级
                //    body.find(".userStatus").val(edit.userStatus);    //用户状态
                //    body.find(".userDesc").text(edit.userDesc);    //用户简介
                //    form.render();
                //}
                setTimeout(function () {
                    layui.layer.tips('点击此处返回用户列表', '.layui-layer-setwin .layui-layer-close', {
                        tips: 3
                    });
                }, 500)
            }
        })
        layui.layer.full(index);
        window.sessionStorage.setItem("index", index);
        //改变窗口大小时，重置弹窗的宽高，防止超出可视区域（如F12调出debug的操作）
        $(window).on("resize", function () {
            layui.layer.full(window.sessionStorage.getItem("index"));
        })
    }
    $(".addNews_btn").click(function () {
        addUser();
    })

    //批量删除
    $(".delAll_btn").click(function () {
        var checkStatus = table.checkStatus('courseListTable'),
            data = checkStatus.data,
            newsId = [];
        if (data.length > 0) {
            for (var i in data) {
                newsId.push(data[i].newsId);
            }
            layer.confirm('确定删除选中的用户？', { icon: 3, title: '提示信息' }, function (index) {
                // $.get("删除文章接口",{
                //     newsId : newsId  //将需要删除的newsId作为参数传入
                // },function(data){
                tableIns.reload();
                layer.close(index);
                // })
            })
        } else {
            layer.msg("请选择需要删除的用户");
        }
    })

    $("#studentId").keyup(function (data) {
        if ($("#studentId").val().length == 0) {
            $("#studentIdLabel").text("学号");
            $("#studentNameLabel").text("学生名字");
            $("#scoreLabel").text("分数");
            return false
        }
        if ($("#studentId").val().length < 8) {
            $("#studentIdLabel").text("学号不存在");
            $("#studentNameLabel").text("学生不存在");
            $("#scoreLabel").text("分数");
            return false;
        }
        $.ajax({
            url: "/Student/GetStudent",
            data: {
                StudentId: $("#studentId").val(),
            },
            dataType: "json",
            success: function (res) {
                if (res.code == 0) {
                    $("#studentName").val(res.data.studentName);
                    $("#studentIdLabel").text("成功");
                    $("#studentNameLabel").text("成功");
                }
                else {
                    $("#studentName").val("自动识别学生名字");
                    $("#studentIdLabel").text("学号不存在");
                    $("#studentNameLabel").text("学生不存在");
                }
            }
        });
        $("#scoreLabel").text("分数");
        $.ajax({
            url: "/Grade/GetGrade",
            data: {
                StudentId: $("#studentId").val(),
                CourseId: $("#courseId").val(),
            },
            type: "POST",
            dataType: "json",
            success: function (res) {
                if (res.code == 0) {
                    $("#score").val(res.data.score);
                    $("#scoreLabel").text("该学生，该科目已录入过了，若再次点击录入，会起到修改的效果");
                }
            }
        });
    });
})
