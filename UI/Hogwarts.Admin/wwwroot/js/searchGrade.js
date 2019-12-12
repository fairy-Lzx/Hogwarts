layui.use(['form', 'layer', 'table', 'laytpl'], function () {
    var form = layui.form,
        layer = parent.layer === undefined ? layui.layer : top.layer,
        $ = layui.jquery,
        laytpl = layui.laytpl,
        table = layui.table;

    //用户列表
    var tableIns = table.render({
        elem: '#searchGradeList',
        url: '/Student/SearchStudents',
        cellMinWidth: 95,
        page: true,
        height: "full-125",
        limits: [10, 15, 20, 25],
        limit: 10,
        id: "searchGradeListTable",
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

            { title: '操作', minWidth: 175, templet: '#searchGradeListBar', fixed: "right", align: "center" }
        ]]
    });
    //搜索【此功能需要后台配合，所以暂时没有动态效果演示】
    $(".search_btn").on("click", function () {
        if ($(".searchVal").val() != '') {
            table.render({
                elem: '#searchGradeList',
                url: '/Grade/SearchGradeAccurate?keyWords=' + $(".searchVal").val(),
                cellMinWidth: 95,
                page: true,
                height: "full-125",
                limits: [10, 15, 20, 25],
                limit: 10,
                id: "searchGradeListTable",
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
                ]]
            });
        } else {
            layer.msg("请输入搜索的内容");
        }
    });

    $(".searchVal").keyup(function () {
        var keywords = "";
        if ($(".searchVal").val() != "") {
            keywords = '?keyWords=' + $(".searchVal").val();
        }
        table.render({
            elem: '#searchGradeList',
            url: '/Grade/SearchGradeFuzzy' + keywords,
            cellMinWidth: 95,
            page: true,
            height: "full-125",
            limits: [10, 15, 20, 25],
            limit: 10,
            id: "searchGradeListTable",
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
            ]]
        });
    });

    $(".search_btn_fuzzy").on("click", function () {
        if ($(".searchVal").val() != '') {
            table.render({
                elem: '#searchGradeList',
                url: '/Grade/SearchGradeFuzzy?keyWords=' + $(".searchVal").val(),
                cellMinWidth: 95,
                page: true,
                height: "full-125",
                limits: [10, 15, 20, 25],
                limit: 10,
                id: "searchGradeListTable",
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
                ]]
            });
        } else {
            layer.msg("请输入搜索的内容");
        }
    });

    //批量删除
    $(".delAll_btn").click(function () {
        var checkStatus = table.checkStatus('schoolRollListTable'),
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
            layer.msg("请选择需要删除的用户");
        }
    })

})
