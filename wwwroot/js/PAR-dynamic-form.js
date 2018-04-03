function getPermissions(val,controller,action) {
    var action = controller + "/" + action + "/" + val ;
    var url = window.location.href + action;
    $.ajax({
                type: "GET",
                url: url,
                contentType: "application/json; charset=utf-8",
                data: { value: val },
                dataType: "json",
                success: function(result) { 
                        result.forEach((data, index) => {
                            console.log(data.permissionID + " " + data.permissionParameterValue);
                            $("input[name='"+data.permissionID+"'][value='"+data.permissionParameterValue+"']").prop('checked', true);
                        }); 
                    },
                error: function() { alert('Error'); }
            });
}