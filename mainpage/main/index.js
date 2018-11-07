/**
 * Created by Administrator on 2018/10/29.
 */
var username;
var password;
var tips = $("#tips");
$("#btn-login").click(function(){
    username = $.trim($("#username").val());
    password = $.trim($("#password").val());
    if(username == ""){
        tips.html("请输入账号");
        return false;
    }else if(password == ""){
        tips.html("请输入密码");
        return false;
    }
    $.ajax({
        type:"POST",
        url:"http://localhost:8080/User/login?phone="+username+"&password="+password,
        dataType:'json',
        success:function(data){
            console.log(data);
            if(data.operate){
            $("#login").html(data.id);
            $("#modal-login").attr("data-dismiss","modal");
            }else{
                $("#tip").html("账号或密码错误");
            } },
        error:function(data){

        }
    });
});
