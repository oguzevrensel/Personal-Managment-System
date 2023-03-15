// A $( document ).ready() block.
$(document).ready(function () {

    $("#tblDept").on("click", ".btnDel", function () {
        var btn = $(this);
        bootbox.confirm('Departmanı silmek istediğinizden emin misiniz ? ', function (result) {

            if (result) {
                var id = btn.data('id');


                $.ajax({
                    type: 'GET',
                    url: 'departman/delete/' + id,
                    success: function () {
                        btn.parent().parent().remove();
                    },
                    error: function () {
                        console.log("Hata oldu")
                    }
                });
            }

            
        });
        
    })
});


















