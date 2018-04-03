$(document).ready(function () {

     $.tablesorter.addParser({
        id: 'last-name',
        is: function(s) {
        return false;
        },
        format: function(str) {
        var parts = (str || '').split(/\s+/),
            last = parts.pop();
        parts.unshift(last);
        return parts.join(' ');
        },
        // set type, either numeric or text
        type: 'text'
    });
    $(".sortable").tablesorter();


    $(".search-input").keyup(function () {

        var value = this.value;
        searchTables(value);
    });

    $(".firstLastToggle").click(function(e){
        $(".name-header").toggleClass("sorter-last-name");
        $(".tablesorter").trigger("update");
        if($(".name-header").hasClass("sorter-last-name")){
            $(".first").text("L");
            $(".last").text("F");
        }
        else{
            $(".first").text("F");
            $(".last").text("L"); 
        }
    });
    $(".searchToggle").click(function(e){
            $(".search-toggle").toggle();
    });


    $( "#assessment-table-completed .filter" ).change(function() {
        filterTable("assessment-table-completed");
    });
    $( "#assessment-table-pending .filter" ).change(function() {
        filterTable("assessment-table-pending");
    });
    $( "#assessment-table-completed .search" ).keyup(function() {
        filterTable("assessment-table-completed");
    });
    $( "#assessment-table-pending .search" ).keyup(function() {
        filterTable("assessment-table-pending");
    });
    $(".clinicianCheckbox").click(function(e){
        var classId = $(this).val();
        $("." + classId).removeClass("d-none");
        $("." + classId).toggle(this.checked);
    });
    $(".groupCheckbox").click(function(e){
            var classId = $(this).val();
            $("." + classId).removeClass("d-none");
            $("." + classId).toggle(this.checked);
    });
    $("#clientCheckAll").click(function(e){
    if($(this).is(':checked'))
        $(".clientCheck").prop('checked', true);
    else
        $(".clientCheck").prop('checked', false);
    });

    setup();
}
);
function setup() {
    rePopulateSelectList('assessment-table-pending', true);
    rePopulateSelectList('assessment-table-completed', true);
    //cleanupSelectedLists();
}
function populateSelectList(table, columnIndex, select) {

    var selectSelector = '#' + table + ' .' + select + ' option';
    $(selectSelector).remove();
    var control = $('#' + table + ' .' + select), values = [];
    var rowCount = 0;
    $('#' + table + ' tr').each(function () {
        if($(this).is(":visible")){
            var cell = $(this).find('td:eq(' + columnIndex + ')'),
                text = cell.text();
            if (values.indexOf(text) == -1) {
                values.push(text);
            }
        }
    });
    //var arrayLength = myStringArray.length;
    values.sort();
    control.append('<option value="All">All</option>');
    for (var i = 0; i < values.length; i++) {
        control.append('<option value="' + values[i] + '">' + values[i] + '</option>');
    }
}
function rePopulateSelectList(table, init) {
    var tableSelector = "#" + table;
    var filterCols = $(tableSelector + ' thead').find(".filter").parents('th');
    var rowCount = 0;
    filterCols.each(function(index, elem) {
        var colList = [];
        $(tableSelector + ' tbody tr').each(function () {
            var row = $(this);
            if(row.is(":visible") || init){
                var cell = row.find('td').eq(elem.column).text().trim();     
                if (colList.indexOf(cell) == -1) {
                    colList.push(cell);
                }
            }
        });
        var control = $(this).find(".filter");
        if(control.val()){                        
                var selected = control.val().trim();
        }  
        var options = control.find("option");
        if(colList.length > 0){
                options.remove();
                control.append('<option value="All">All</option>');
                for (var i = 0; i < colList.length; i++) {
                        if(colList[i] === selected)
                            control.append('<option value="' + colList[i] + '" selected>' + colList[i] + '</option>');
                        else
                            control.append('<option value="' + colList[i] + '">' + colList[i] + '</option>');                                                                                                             
                }
        } 
    });   
}
function cleanupSelectedLists() {
    $('select option')
        .filter(function() {
            return !this.value || $.trim(this.value).length == 0;
        })
    .remove();

    $('select option')
        .first()
        .prop('selected', true);
}
function searchTables(value) {

    $(".searchable").find("tr").each(function (index) { 
        
        if (value && value.toUpperCase() === "ALL") {
                $(this).show();
        } 
        else {
            var rowMatch = false;
            $(this).find("td").each(function (index) {
                   if ($(this).text().toUpperCase().indexOf(value.toUpperCase()) !== -1)
                        rowMatch = true;
            });
            $(this).toggle(rowMatch);  
        }                
    });
}
function findObjectByKey(array, key, value) {
    for (var i = 0; i < array.length; i++) {
        if (array[i][key] === value) {
            return array[i];
        }
    }
    return null;
}
function filterTable(table) {
    if(table){   
        tableSelector = "#" + table;  // + " .searchable";
        var filters = [];
        $(tableSelector + " thead").find("th").each(function (index) {
                if($(this).find(".filter")[0]){
                    if($(this).find(".filter").val().trim().toUpperCase() !== 'ALL'){
                        filters.push({
                            key: index,
                            value: $(this).find(".filter").val().trim().toUpperCase()
                        });
                    }
                }  
                if($(this).find(".search")[0]){
                    if($(this).find(".search").val().trim().toUpperCase() !== ''){
                        filters.push({
                            key: index,
                            value: $(this).find(".search").val().trim().toUpperCase()
                        });
                    }
                }       
         });
         
         $(tableSelector + " tbody").find("tr").each(function (rIndex) { 
            var rowMatchCount = 0;
            var row = $(this);
            filters.forEach(function(element, index) {
                if(row.find('td').eq(element.key).text().trim().toUpperCase().indexOf(element.value) !== -1){
                    rowMatchCount++;
                    //console.log(element.key + ": " + element.value);   
                }
            });
            if(rowMatchCount === filters.length)
                $(this).show();  
            else
                $(this).hide();
        });
    rePopulateSelectList(table);  
    }
}
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