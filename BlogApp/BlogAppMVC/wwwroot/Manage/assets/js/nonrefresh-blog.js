blogHardDelete()
blogDelete()
blogRecover()

function blogDelete() {
    document.querySelectorAll(".deleteBlog").forEach(btn => {
        btn.addEventListener("click", () => {
            let id = btn.getAttribute("id")
            fetch("/Manage/Blog/Delete/" + id)
                .then(resp => resp.json())
                .then(text => {
                    if (text === 404) {
                        const Toast = Swal.mixin({
                            toast: true,
                            position: 'top-end',
                            showConfirmButton: false,
                            timer: 3000,
                            timerProgressBar: true,
                            didOpen: (toast) => {
                                toast.addEventListener('mouseenter', Swal.stopTimer)
                                toast.addEventListener('mouseleave', Swal.resumeTimer)
                            }
                        })

                        Toast.fire({
                            icon: 'error',
                            title: 'Something went wrong'
                        })
                    }
                    else if (text === 200) {
                        // status deyismesi
                        btn.parentElement.parentElement.parentElement.parentElement.children[7].children[0].setAttribute("class", "badge rounded-pill alert-danger")
                        btn.parentElement.parentElement.parentElement.parentElement.children[7].children[0].innerHTML = "InActive"
                        // detallarin deyismesi
                        btn.parentElement.innerHTML =
                            `
                        <a class="dropdown-item" href="/manage/blog/get/` + id + `">View Detail</a>
                        <a class="dropdown-item recoverBlog" id="`+ id + `">Recover</a>
                        <a class="dropdown-item text-danger hardDeleteBlog" id="`+ id + `">Permamently Delete</a>
                        `
                        blogHardDelete()
                        blogRecover()
                    }
                })
        })
    })
}

function blogHardDelete() {
    document.querySelectorAll(".hardDeleteBlog").forEach(btn => {
        btn.addEventListener("click", () => {
            let id = btn.getAttribute("id");
            // confirm modulu
            Swal.fire({
                title: 'Are you sure?',
                icon: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                confirmButtonText: 'Yes, delete it!'
            }).then((result) => {
                if (result.isConfirmed) {
                    // silindiyini tesdiqleyir
                    Swal.fire(
                        'Blog has been deleted!',
                        '',
                        'success',
                    )
                    fetch("/manage/blog/harddelete/" + id).then(resp => resp.json())
                        .then(text => {
                            console.log(text);
                            if (text === 404) {
                                const Toast = Swal.mixin({
                                    toast: true,
                                    position: 'top-end',
                                    showConfirmButton: false,
                                    timer: 3000,
                                    timerProgressBar: true,
                                    didOpen: (toast) => {
                                        toast.addEventListener('mouseenter', Swal.stopTimer)
                                        toast.addEventListener('mouseleave', Swal.resumeTimer)
                                    }
                                })

                                Toast.fire({
                                    icon: 'error',
                                    title: 'Something went wrong'
                                })
                            }
                            else if (text === 200) {
                                // siradan silir
                                btn.parentElement.parentElement.parentElement.parentElement.remove()
                            }
                        })
                }
            })
        })
    })
}

function blogRecover() {
    document.querySelectorAll(".recoverBlog").forEach(btn => {
        btn.addEventListener("click", () => {
            let id = btn.getAttribute("id")
            fetch("/Manage/Blog/recover/" + id)
                .then(resp => resp.json())
                .then(text => {
                    if (text === 404) {
                        const Toast = Swal.mixin({
                            toast: true,
                            position: 'top-end',
                            showConfirmButton: false,
                            timer: 3000,
                            timerProgressBar: true,
                            didOpen: (toast) => {
                                toast.addEventListener('mouseenter', Swal.stopTimer)
                                toast.addEventListener('mouseleave', Swal.resumeTimer)
                            }
                        })

                        Toast.fire({
                            icon: 'error',
                            title: 'Something went wrong'
                        })
                    }
                    else if (text === 200) {
                        // status deyismesi
                        btn.parentElement.parentElement.parentElement.parentElement.children[7].children[0].setAttribute("class", "badge rounded-pill alert-success")
                        btn.parentElement.parentElement.parentElement.parentElement.children[7].children[0].innerHTML = "Active"
                        // detallarin deyismesi
                        btn.parentElement.innerHTML =
                            `
                        <a class="dropdown-item" href="/manage/blog/get/` + id + `">View Detail</a>
                        <a class="dropdown-item" href="/manage/blog/update/` + id + `">Edit info</a>
                        <a class="dropdown-item text-danger deleteBlog" id="`+ id + `">Delete</a>
                        `
                        blogDelete()
                    }
                })
        })
    })
}