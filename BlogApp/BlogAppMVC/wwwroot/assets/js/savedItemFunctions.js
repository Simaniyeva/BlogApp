//  saveItem button
let savedItembtn = document.querySelectorAll(".savedItembtn")
let save = document.querySelectorAll(".save");

savedItembtn.forEach(btn => {
    btn.addEventListener("click", (e) => {
        let tags = e.currentTarget.children
        console.log(tags);
        Array.from(tags).forEach(i => {
            i.classList.toggle("show")
        })
    })
})
function AddToSavedItem(e) {
    var blogId = e.getAttribute('data-id');
    console.log($(e).siblings(".remove-from-savedItem"))
    $.ajax({
        url: '/Blog/AddToSaved',
        method: 'POST',
        data: { id: blogId },
        success: function (result) {
            if (result.success) {
                console.log(result)
                $(".remove-from-savedItem").attr("data-id", result.data.id)
                $(".remove-from-savedItem").attr("data-blog-id", blogId)
                $(".remove-from-savedItem").css("pointer-events", "auto")
                $(".add-to-savedItem").css("pointer-events", "none")
            }
        },
        error: function (jqXHR, textStatus, errorThrown) {
            if (jqXHR.status === 404) {
                window.location.href = '/Account/Login';
            }
        }
    });
}
function RemoveFromFav(e) {
    var removeId = e.getAttribute('data-id');
    var blogId = e.getAttribute('data-blog-id');
    $.ajax({
        url: '/Blog/RemoveFromSavedItem',
        method: 'POST',
        data: { id: removeId },
        success: function (result) {
            if (result.success) {
                console.log(result);
                $(".add-to-savedItem").attr("data-id", blogId)
                //$(".remove-from-savedItem").css("pointer-events", "none")
                $(".add-to-savedItem").css("pointer-events", "auto")
            }
        },
        error: function (jqXHR, textStatus, errorThrown) {
            if (jqXHR.status === 404) {
                window.location.href = '/Account/Login';
            }
        }
    });
}