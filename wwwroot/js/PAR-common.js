$(document).ready(function() {
  // Popover functions
  $("[data-toggle=popover]").each(function(i, obj) {
    $(this).popover({
      html: true,

      content: function() {
        var id = $(this).attr("id");
        return $("#popover-content-" + id).html();
      }
    });
  });
  $(".popover-dismiss").popover({
    trigger: "focus"
  });
});
function findObjectByKey(array, key, value) {
  for (var i = 0; i < array.length; i++) {
    if (array[i][key] === value) {
      return array[i];
    }
  }
  return null;
}
