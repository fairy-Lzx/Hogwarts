layui.use(['form', 'layer', 'table', 'laytpl'], function () {
    var form = layui.form,
        layer = parent.layer === undefined ? layui.layer : top.layer,
        $ = layui.jquery,
        laytpl = layui.laytpl,
        table = layui.table;

    //用户列表
    var tableIns = table.render({
        elem: '#newStudentList',
        url: '/Student/newStudents',
        cellMinWidth: 95,
        page: true,
        height: "full-125",
        limits: [10, 15, 20, 25],
        limit: 10,
        id: "newStudentListTable",
        cols: [[
            { type: "checkbox", fixed: "left", width: 50 },
            { field: "rowId", title: 'ID', width: 60, fixed: "left", sort: "true", align: 'center', edit: 'text' },
            //{field: 'nickName', title: '昵称', minWidth:100, align:"center"},
            { field: 'studentId', title: '学号', minWidth: 100, align: "center" },
            //{field: 'userEmail', title: '用户邮箱', minWidth:200, align:'center',templet:function(d){
            //    return '<a class="layui-blue" href="mailto:'+d.userEmail+'">'+d.userEmail+'</a>';
            { field: 'studentName', title: '学生名', minWidth: 100, align: "center" },
            { field: 'englishName', title: '英文名', minWidth: 100, align: "center" },
            { field: 'sex', title: '性别', minWidth: 100, align: "center" },
            //{ field: 'birthday', title: '生日', minWidth: 100, align: "center" },
            { field: 'year', title: '入学年份', minWidth: 100, align: "center" },
            { field: 'className', title: '学院名', minWidth: 100, align: "center" },
            { field: 'character', title: '特性', minWidth: 100, align: "center" },

            { title: '操作', minWidth: 175, templet: '#newStudentListBar', fixed: "right", align: "center" }
        ]]
    });

    form.on('select(character)', function (data) {
        if ($("#classId").val() != "") {
            $("#characterLabel").text("即将去往" + $("#classId option[value='" + $("#classId").val() + "']").text());
            return false;
        }
        if (data.value == "") {
            $("#characterLabel").text("按属性分配学院");
            return false;
        }
        $.ajax({
            url: "/Student/Allocate",
            type: "POST",
            data: {
                Character: data.value,
            },
            dataType: "json",
            success: function (res) {
                if (res.msg == "SUCCEED") {
                    $("#characterLabel").text("即将去往" + res.data.className);
                } else {
                    $("#characterLabel").text("没有对应学院，请添加更多学院，或从下方选择");
                }
            }
        });
    });

    form.on('select(classId)', function (data) {
        if ($("#classId").val() != "") {
            $("#characterLabel").text("即将去往" + $("#classId option[value='" + $("#classId").val() + "']").text());
            return false;
        }
        if ($("#character").val() == "") {
            $("#characterLabel").text("按属性分配学院");
            return false;
        }
        $.ajax({
            url: "/Student/Allocate",
            type: "POST",
            data: {
                Character: $("#character").val(),
            },
            dataType: "json",
            success: function (res) {
                if (res.msg == "SUCCEED") {
                    $("#characterLabel").text("即将去往" + res.data.className);
                } else {
                    $("#characterLabel").text("没有对应学院，请添加更多学院，或从下方选择");
                }
            }
        });
    });

    form.on("submit(addStudent-btn)", function (data) {
        if ($("#characterLabel").text() == "没有对应学院，请添加更多学院，或从下方选择" || $("#characterLabel").text() == "按属性分配学院") {
            alert("请重新选择学院或者属性");
            return false;
        }
        //弹出loading
        var index = top.layer.msg('数据提交中，请稍候', { icon: 16, time: false, shade: 0.8 });
        // 实际使用时的提交信息
        var classId;
        if ($("#classId").val() != "") {
            classId = $("#classId").val();
            console.log(classId);
        } else {
            $.ajax({
                url: "/Student/Allocate",
                type: "POST",
                async: false,
                data: {
                    Character: $("#character").val(),
                },
                dataType: "json",
                success: function (res) {
                    if (res.msg == "SUCCEED") {
                        classId = res.data.classId;
                        console.log(classId);
                    } else {
                        alert("出错");
                    }
                }
            });
        }
        $.ajax({
            url: "/Student/AddStudent",
            type: "POST",
            data: {
                StudentName: data.field.studentName,
                EnglishName: data.field.englishName,
                Character: data.field.character,
                Sex: data.field.sex,
                ClassId: classId,
                Year: data.field.year,
            },
            dataType: "json",
            success: function (res) {
                if (res == "SUCCEED") {
                    $(".btn-reset").click();
                    top.layer.close(index);
                    top.layer.msg("学生添加成功！");
                    layer.closeAll("iframe");
                    //刷新父页面
                    tableIns.reload();
                } else {
                    top.layer.close(index);
                    top.layer.msg("学生添加失败！");
                    layer.closeAll("iframe");
                    //刷新父页面
                    //parent.location.reload();
                }
            }
        });
        return false;
    })

    table.on('tool(newStudentList)', function (obj) {
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
            layer.confirm('确定删除此学生？', { icon: 3, title: '提示信息' }, function (index) {
                //$.get("/Account/DeleteUser",{
                //    newsId : data.newsId  //将需要删除的newsId作为参数传入
                //},function(data){
                //   tableIns.reload();
                //   layer.close(index);
                // })
                var index = top.layer.msg('数据提交中，请稍候', { icon: 16, time: false, shade: 0.8 });
                $.ajax({
                    url: "/Student/DeleteStudent",
                    type: "POST",
                    data: {
                        StudentId: data.studentId
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

    $(".searchVal").keyup(function () {
        var keywords = "";
        if ($(".searchVal").val() != "") {
            keywords = '?keyWords=' + $(".searchVal").val();
        } else {
            table.render({
                elem: '#newStudentList',
                url: '/Student/newStudents',
                cellMinWidth: 95,
                page: true,
                height: "full-125",
                limits: [10, 15, 20, 25],
                limit: 10,
                id: "newStudentListTable",
                cols: [[
                    { type: "checkbox", fixed: "left", width: 50 },
                    { field: "rowId", title: 'ID', width: 60, fixed: "left", sort: "true", align: 'center', edit: 'text' },
                    //{field: 'nickName', title: '昵称', minWidth:100, align:"center"},
                    { field: 'studentId', title: '学号', minWidth: 100, align: "center" },
                    //{field: 'userEmail', title: '用户邮箱', minWidth:200, align:'center',templet:function(d){
                    //    return '<a class="layui-blue" href="mailto:'+d.userEmail+'">'+d.userEmail+'</a>';
                    { field: 'studentName', title: '学生名', minWidth: 100, align: "center" },
                    { field: 'englishName', title: '英文名', minWidth: 100, align: "center" },
                    { field: 'sex', title: '性别', minWidth: 100, align: "center" },
                    //{ field: 'birthday', title: '生日', minWidth: 100, align: "center" },
                    { field: 'year', title: '入学年份', minWidth: 100, align: "center" },
                    { field: 'className', title: '学院名', minWidth: 100, align: "center" },
                    { field: 'character', title: '特性', minWidth: 100, align: "center" },

                    { title: '操作', minWidth: 175, templet: '#newStudentListBar', fixed: "right", align: "center" }
                ]]
            });
            return false;
        }
        table.render({
            elem: '#newStudentList',
            url: '/Student/FuzzySearchStudents' + keywords,
            cellMinWidth: 95,
            page: true,
            height: "full-125",
            limits: [10, 15, 20, 25],
            limit: 10,
            id: "newStudentListTable",
            cols: [[
                { type: "checkbox", fixed: "left", width: 50 },
                { field: "rowId", title: 'ID', width: 60, fixed: "left", sort: "true", align: 'center', edit: 'text' },
                //{field: 'nickName', title: '昵称', minWidth:100, align:"center"},
                { field: 'studentId', title: '学号', minWidth: 100, align: "center" },
                //{field: 'userEmail', title: '用户邮箱', minWidth:200, align:'center',templet:function(d){
                //    return '<a class="layui-blue" href="mailto:'+d.userEmail+'">'+d.userEmail+'</a>';
                { field: 'studentName', title: '学生名', minWidth: 100, align: "center" },
                { field: 'englishName', title: '英文名', minWidth: 100, align: "center" },
                { field: 'sex', title: '性别', minWidth: 100, align: "center" },
                //{ field: 'birthday', title: '生日', minWidth: 100, align: "center" },
                { field: 'year', title: '入学年份', minWidth: 100, align: "center" },
                { field: 'className', title: '学院名', minWidth: 100, align: "center" },
                { field: 'character', title: '特性', minWidth: 100, align: "center" },

                { title: '操作', minWidth: 175, templet: '#newStudentListBar', fixed: "right", align: "center" }
            ]]
        });
    });
    //搜索【此功能需要后台配合，所以暂时没有动态效果演示】
    $(".search_btn").on("click", function () {
        if ($(".searchVal").val() != '') {
            table.render({
                elem: '#newStudentList',
                url: '/Student/SearchStudents?keyWords=' + $(".searchVal").val(),
                cellMinWidth: 95,
                page: true,
                height: "full-125",
                limits: [10, 15, 20, 25],
                limit: 10,
                id: "newStudentListTable",
                cols: [[
                    { type: "checkbox", fixed: "left", width: 50 },
                    { field: "rowId", title: 'ID', width: 60, fixed: "left", sort: "true", align: 'center', edit: 'text' },
                    //{field: 'nickName', title: '昵称', minWidth:100, align:"center"},
                    { field: 'studentId', title: '学号', minWidth: 100, align: "center" },
                    //{field: 'userEmail', title: '用户邮箱', minWidth:200, align:'center',templet:function(d){
                    //    return '<a class="layui-blue" href="mailto:'+d.userEmail+'">'+d.userEmail+'</a>';
                    { field: 'studentName', title: '学生名', minWidth: 100, align: "center" },
                    { field: 'englishName', title: '英文名', minWidth: 100, align: "center" },
                    { field: 'sex', title: '性别', minWidth: 100, align: "center" },
                    //{ field: 'birthday', title: '生日', minWidth: 100, align: "center" },
                    { field: 'year', title: '入学年份', minWidth: 100, align: "center" },
                    { field: 'className', title: '学院名', minWidth: 100, align: "center" },
                    { field: 'character', title: '特性', minWidth: 100, align: "center" },

                    { title: '操作', minWidth: 175, templet: '#newStudentListBar', fixed: "right", align: "center" }
                ]]
            });
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
        var checkStatus = table.checkStatus('newStudentListTable'),
            data = checkStatus.data,
            StudentId = [];
        if (data.length > 0) {
            for (var i in data) {
                StudentId.push(data[i].studentId);
                console.log(data[i].studentId);
            }
            layer.confirm('确定删除选中的用户？', { icon: 3, title: '提示信息' }, function (index) {
                $.ajax({
                    url: "/Student/DeleteStudents",
                    type: "POST",
                    data: {
                        StudentIds: StudentId,
                    },
                    success: function (res) {
                        if (res.count == StudentId.length) {
                            layer.msg("已成功删除" + res.count + "条数据");
                            tableIns.reload();
                            layer.close(index);
                        } else if (0 < res.count < StudentId.length) {
                            layer.msg("只删除部分数据，删除了" + res.count + "条数据");
                            tableIns.reload();
                            layer.close(index);
                        } else {
                            layer.msg("删除失败");
                            tableIns.reload();
                            layer.close(index);
                        }
                    }
                })

                // })
            })
        } else {
            layer.msg("请选择需要删除的数据");
        }
    })


    $("input[name='studentName']").change(function () {
        if ($("input[name='studentName']").val() == "") {
            $("#studentNameLabel").text("中文名");
            return false;
        }
        $.ajax({
            url: "/Student/GetStudentByNane",
            type: "POST",
            data: {
                StudentName: $(this).val(),
            },
            dataType: "json",
            success: function (res) {
                if (res.msg == "SUCCEED") {
                    $("#studentNameLabel").text("已存在该名字的学生，是否是同名不同人，是则继续，否则请重新输入");
                } else{
                    $("#studentNameLabel").text("成功!");
                }
            }
        });
    });

    $("input[name='englishName']").change(function () {
        if ($("input[name='englishName']").val() == "") {
            $("#englishNameLabel").text("EnglishName");
            return false;
        }
        $.ajax({
            url: "/Student/GetStudentByNane",
            type: "POST",
            data: {
                StudentName: $(this).val(),
            },
            dataType: "json",
            success: function (res) {
                if (res.msg == "SUCCEED") {
                    $("#englishNameLabel").text("已存在该名字的学生，是否是同名不同人，是则继续，否则请重新输入");
                } else {
                    $("#englishNameLabel").text("SUCCEED");
                }
            }
        });
    });
})
