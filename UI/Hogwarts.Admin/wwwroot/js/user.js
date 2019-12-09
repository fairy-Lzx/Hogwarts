layui.use(['form','layer','laydate','table','laytpl'],function(){
    var form = layui.form,
        layer = parent.layer === undefined ? layui.layer : top.layer,
        $ = layui.jquery,
        laydate = layui.laydate,
        laytpl = layui.laytpl,
        table = layui.table;

    //添加验证规则
    form.verify({
        oldPwd : function(value, item){
            if(value != "123456"){
                return "密码错误，请重新输入！";
            }
        },
        newPwd : function(value, item){
            if(value.length < 6){
                return "密码长度不能小于6位";
            }
        },
        confirmPwd : function(value, item){
            if(!new RegExp($("#oldPwd").val()).test(value)){
                return "两次输入密码不一致，请重新输入！";
            }
        }
    })

    //用户等级
    var tableRoles=table.render({
        elem: '#userGrade',
        url : '/Role/Roles',
        cellMinWidth : 95,
        cols : [[
            { field:"rowId", title: 'ID', width: 60, fixed:"left",sort:"true", align:'center', edit: 'text'},
            { field: "roleId", title: '等级', minWidth: 100, fixed: "left", sort: "false", align: "center" },
            {field: 'gradeIcon', title: '图标展示', templet:'#gradeIcon', align:'center'},
            { field: 'roleName', title: '等级名称', edit: 'text', align: 'center' },
            //{field: 'gradeValue', title: '等级值', edit: 'text',sort:"true", align:'center'},
            //{field: 'gradeGold', title: '默认金币', edit: 'text',sort:"true", align:'center'},
            //{field: 'gradePoint', title: '默认积分', edit: 'text',sort:"true", align:'center'},
            { title: '当前状态', minWidth: 100, templet: '#gradeBar', fixed: "right", align: "center" },
            { title: '操作', minWidth: 175, templet: '#roleOperateBar', fixed: "right", align: "center" }
        ]]
    });

    form.on('switch(gradeStatus)', function(data){
        var tipText = '确定禁用当前会员等级？';
        if(data.elem.checked){
            tipText = '确定启用当前会员等级？'
        }
        layer.confirm(tipText,{
            icon: 3,
            title:'系统提示',
            cancel : function(index){
                data.elem.checked = !data.elem.checked;
                form.render();
                layer.close(index);
            }
        },function(index){
            layer.close(index);
        },function(index){
            data.elem.checked = !data.elem.checked;
            form.render();
            layer.close(index);
        });
    });

    table.on('tool(userGrade)', function (obj) {
        var layEvent = obj.event,
            listdata = obj.data;
        //删除角色
        if (layEvent === 'del') { //删除
            layer.confirm('确定删除此用户？', { icon: 3, title: '提示信息' }, function (index) {
                //$.get("删除文章接口",{
                //    newsId : data.newsId  //将需要删除的newsId作为参数传入
                //},function(data){
                var index = top.layer.msg('数据提交中，请稍候', { icon: 16, time: false, shade: 0.8 });

                $.ajax({
                    url: "/Role/RoleDelete",
                    type: "POST",
                    data: {
                        roleId: listdata.roleId,
                        roleName: listdata.roleName
                    },
                    dataType: "json",
                    success: function (res) {
                        if (res == "FALSE") {
                            tableIns.reload();
                            layer.close(index);
                            return false;
                        }
                        tableRoles.reload();
                        layer.close(index);
                    }
                })
            });
        }

    });

    //新增等级
    $(".addRole").click(function(){
        addRole();
    });

    //添加角色
    function addRole(edit) {
        var index = layui.layer.open({
            title: "添加角色",
            type: 2,
            content: "/Role/RoleAdd",
            success: function (layero, index) {
                var body = layui.layer.getChildFrame('body', index);
                if (edit) {
                    form.render();
                }
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

    //控制表格编辑时文本的位置【跟随渲染时的位置】
    $("body").on("click",".layui-table-body.layui-table-main tbody tr td",function(){
        $(this).find(".layui-table-edit").addClass("layui-"+$(this).attr("align"));
    });

})