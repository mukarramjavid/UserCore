//// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
//// for details on configuring this project to bundle and minify static web assets.

//// Write your JavaScript code.
$(document).ready(function () {
    //Upload & Browse picture
    $("#UserImage,.upload_photo").click(function () {
        $("#BrowseImage").trigger('click');
        //alert('click')
    });
    //Select & upload Image
    $("#BrowseImage").change(function () {
        var File = this.files;
        if (File && File[0]) {
            var fileReader = new FileReader();
            fileReader.readAsDataURL(File[0]);
            fileReader.onload = function (img) {
                //Load img and control dimensions
                var image = new Image();
                image.src = img.target.result;
                image.onload = function () {
                    //var width = this.width;
                    //var height = this.height;
                    var type = File[0].type;
                    if ((type == "image/jpg" || type == "image/png" || type == "image/jpeg")) {
                        $("#UserImage").attr('src', img.target.result);
                        //$(".img-desc").css("color", "black");
                    }
                    else {
                        alert("Only specfied dimensions are allowed. 178 x 156");
                        //$(".img-desc").css("color", "red");
                    }
                    //alert("width: " + width + "height: " + height); 
                }
                //$("#UserImage").attr('src', img.target.result);
            }
        }
    });
    $(".remove_photo").click(function () {
        $("#UserImage").attr('src', "/images/no_image_available_male.png");
        $(".ImagePath").val("/images/no_image_available_male.png");
    });
    $("#blah").click(function () {
        $("#imgInput").trigger('click');
    })
    $("#imgInput").change(function () {
        console.log("Changed")
        debugger
        if (this.files && this.files[0]) {
            var reader = new FileReader();

            reader.onload = function (e) {
                $('#blah').attr('src', e.target.result)
                //console.log("src=> ", e.target.result)
            }

            reader.readAsDataURL(this.files[0]);
            console.log("reader=> ", reader)
        }
    })
}
);