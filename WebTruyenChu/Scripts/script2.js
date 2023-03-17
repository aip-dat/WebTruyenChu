 $(document).ready(function () {
            $("btn_add").click(function () {
                var DataForm = $("#FormData").serialize();

                $.ajax({
                    type: "POST",
                    url: "~/Admin/theloais/Create",
                    data: DataForm,

                    success: function () {
                        window.location.href = '/theloais/Index';
                    }
                })
            })
        })
