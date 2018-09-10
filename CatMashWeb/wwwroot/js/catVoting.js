
$(document).ready(function () {
    InitEvents();
});

function InitEvents() {
    $(".js-catcandidate").on("click", function () {
        CatVoting(this);
    });
}

function CatVoting(obj) {
    $("#CatIdSelected").val(obj.id);
    $("#formCatVoting").submit();
}