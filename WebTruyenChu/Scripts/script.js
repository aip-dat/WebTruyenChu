$('#keyword').keyup(function () {
    var searchField = $('#keyword').val();
    var expression = RegExp(searchField, "i");

    $('.tt-dataset').remove();
    $.ajax({
        type: "GET",
        url: "/Home/Search",
        success: function (response) {
            var data = JSON.parse(response);
            console.log(data);
            if (searchField != ""){
                var html_Body = `<div class="tt-dataset tt-dataset-states">
                                    </div>`;
            } $('.tt-menu').append(html_Body);
            $.each(data, function (key, item) {
                if (item.tentruyen.search(expression) != -1 && searchField != "") {
                    var html_Search = `<div class="man-section tt-suggestion tt-selectable">
                                            <div class="image-section">
                                                <img src="${item.hinh}">
                                            </div>
                                            <div class="description-section">
                                                <h1>${item.tentruyen}</h1><p>${item.mota}</p>
                                                <span>
                                                    <i class="fa fa-clock-o" aria-hidden="true">
                                                    </i> 12:00 PM <i class="fa fa-map-marker" aria-hidden="true"></i> Ha Noi
                                                </span><div class="more-section">
                                                    <a href="#" target="_blank">
                                                        <button>More Info</button>
                                                    </a>
                                                </div>
                                            </div>
                                            <div style="clear:both;">
                                            </div>
                                        </div>`;
                    $('.tt-dataset').append(html_Search);
                }
            })
        }
    })
})