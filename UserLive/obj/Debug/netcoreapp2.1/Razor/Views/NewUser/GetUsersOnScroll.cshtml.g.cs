#pragma checksum "E:\Angular_Projects\_coreUSerCopy\UserLive\Views\NewUser\GetUsersOnScroll.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "756a161b4f634a8f39286b0d950a438c6a8d1ac7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_NewUser_GetUsersOnScroll), @"mvc.1.0.view", @"/Views/NewUser/GetUsersOnScroll.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/NewUser/GetUsersOnScroll.cshtml", typeof(AspNetCore.Views_NewUser_GetUsersOnScroll))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "E:\Angular_Projects\_coreUSerCopy\UserLive\Views\_ViewImports.cshtml"
using UserLive;

#line default
#line hidden
#line 2 "E:\Angular_Projects\_coreUSerCopy\UserLive\Views\_ViewImports.cshtml"
using UserLive.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"756a161b4f634a8f39286b0d950a438c6a8d1ac7", @"/Views/NewUser/GetUsersOnScroll.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fc3a3262aaca43f72383e090e6438ed720a4e2bd", @"/Views/_ViewImports.cshtml")]
    public class Views_NewUser_GetUsersOnScroll : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "E:\Angular_Projects\_coreUSerCopy\UserLive\Views\NewUser\GetUsersOnScroll.cshtml"
  
    ViewData["Title"] = "GetUsersOnScroll";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(101, 2669, true);
            WriteLiteral(@"<style>
    .btn-success {
        display: block;
    }

    #checkboxeslist, #checkboxeslistEdit {
        display: flex;
        /*justify-content:center;*/
        justify-content: space-between;
    }

    .lds-spinner {
        color: official;
        display: inline-block;
        position: relative;
        width: 80px;
        height: 80px;
        left: 50%;
        right: 50%;
    }

        .lds-spinner div {
            transform-origin: 40px 40px;
            animation: lds-spinner 1.2s linear infinite;
        }

            .lds-spinner div:after {
                content: "" "";
                display: block;
                position: absolute;
                top: 3px;
                left: 37px;
                width: 6px;
                height: 18px;
                border-radius: 20%;
                background: #000000;
            }

            .lds-spinner div:nth-child(1) {
                transform: rotate(0deg);
                animation-del");
            WriteLiteral(@"ay: -1.1s;
            }

            .lds-spinner div:nth-child(2) {
                transform: rotate(30deg);
                animation-delay: -1s;
            }

            .lds-spinner div:nth-child(3) {
                transform: rotate(60deg);
                animation-delay: -0.9s;
            }

            .lds-spinner div:nth-child(4) {
                transform: rotate(90deg);
                animation-delay: -0.8s;
            }

            .lds-spinner div:nth-child(5) {
                transform: rotate(120deg);
                animation-delay: -0.7s;
            }

            .lds-spinner div:nth-child(6) {
                transform: rotate(150deg);
                animation-delay: -0.6s;
            }

            .lds-spinner div:nth-child(7) {
                transform: rotate(180deg);
                animation-delay: -0.5s;
            }

            .lds-spinner div:nth-child(8) {
                transform: rotate(210deg);
                animation-del");
            WriteLiteral(@"ay: -0.4s;
            }

            .lds-spinner div:nth-child(9) {
                transform: rotate(240deg);
                animation-delay: -0.3s;
            }

            .lds-spinner div:nth-child(10) {
                transform: rotate(270deg);
                animation-delay: -0.2s;
            }

            .lds-spinner div:nth-child(11) {
                transform: rotate(300deg);
                animation-delay: -0.1s;
            }

            .lds-spinner div:nth-child(12) {
                transform: rotate(330deg);
                animation-delay: 0s;
            }

    ");
            EndContext();
            BeginContext(2771, 423, true);
            WriteLiteral(@"@keyframes lds-spinner {
        0% {
            opacity: 1;
        }

        100% {
            opacity: 0;
        }
    }

    .load_master {
        border: 16px solid #f3f3f3; /*Light gre*/
        border-top: 16px solid #3498db; /*Blue*/
        border-radius: 50%;
        width: 120px;
        height: 120px;
        animation: spin 2s linear infinite;
        text-align: center;
    }

    ");
            EndContext();
            BeginContext(3195, 2761, true);
            WriteLiteral(@"@keyframes spin {
        0% {
            transform: rotate(0deg)
        }

        100% {
            transform: rotate(360deg);
        }
    }

    .fa-check-circle {
        color: #1877F2;
    }

    .badge {
        background-color: #5cb85c;
    }

    {
        box-sizing: border-box;
    }

    /* Button used to open the chat form - fixed at the bottom of the page */
    .open-button {
        background-color: #555;
        color: white;
        padding: 16px 20px;
        border: none;
        cursor: pointer;
        opacity: 0.8;
        position: fixed;
        bottom: 23px;
        right: 28px;
        width: 280px;
    }

    /* The popup chat - hidden by default */
    .chat-popup {
        display: none;
        position: fixed;
        bottom: 0;
        right: 15px;
        border: 3px solid #f1f1f1;
        z-index: 9;
    }

    /* Add styles to the form container */
    .form-container {
        max-width: 300px;
        padding: 10px;");
            WriteLiteral(@"
        background-color: white;
    }

        /* Full-width textarea */
        .form-container textarea {
            width: 100%;
            padding: 15px;
            margin: 5px 0 22px 0;
            border: none;
            background: #f1f1f1;
            resize: none;
            min-height: 200px;
        }

            /* When the textarea gets focus, do something */
            .form-container textarea:focus {
                background-color: #ddd;
                outline: none;
            }

        /* Set a style for the submit/send button */
        .form-container .btn {
            background-color: #4CAF50;
            color: white;
            padding: 16px 20px;
            border: none;
            cursor: pointer;
            width: 100%;
            margin-bottom: 10px;
            opacity: 0.8;
        }

        /* Add a red background color to the cancel button */
        .form-container .cancel {
            background-color: red;
        }
");
            WriteLiteral(@"
        /* Add some hover effects to buttons */
        .form-container .btn:hover, .open-button:hover {
            opacity: 1;
        }

    .basket_icon:hover {
        cursor: pointer
    }

    .addedData {
        /*        width: 110px;
        height: 110px;*/
        height: 50rem;
        width: 50rem;
        overflow: hidden auto;
    }
</style>
<h2>Get Users OnScroll</h2>

<hr />
<div class=""container"">
    <div class=""row"">
        <!--*********************************************************show user list***************************************************************-->

        <div class=""col-lg-12"">
            <h1 class=""alert alert-info"">Users List OnScroll ");
            EndContext();
            BeginContext(6004, 121, true);
            WriteLiteral("</h1>\r\n\r\n            <table class=\"table table-hover table-striped\">\r\n                <thead>\r\n                    <tr>\r\n");
            EndContext();
            BeginContext(6166, 617, true);
            WriteLiteral(@"                        <th>UserName</th>
                        <th>Email</th>
                        <th>Password</th>
                        <th>Phone</th>
                        <th>Country</th>
                        <th>Province</th>
                        <th>Add</th>
                    </tr>
                </thead>
                <tbody id=""tMasterbodyOnScroll"">
                </tbody>
            </table>
            <div class=""lds-spinner""><div></div><div></div><div></div><div></div><div></div><div></div><div></div><div></div><div></div><div></div><div></div><div></div></div>
");
            EndContext();
            BeginContext(6873, 7248, true);
            WriteLiteral(@"
        </div>
    </div>
    <button class=""open-button"" onclick=""openForm()"">Users <span class=""badge""></span></button>
    <div class=""chat-popup"" id=""myForm"">
        <div class=""form-container"">
            <label for=""msg""><b>Data</b></label>
            <div class=""addedData""> </div>
            <button type=""button"" class=""btn cancel"" onclick=""closeForm()"">Close</button>
        </div>
    </div>
</div>
<script src=""https://code.jquery.com/jquery-3.5.1.min.js""></script>
<script>
    $(document).ready(function () {
        loadMasterData();
        loadMore();
        addToBasket();
        displayBasket()
        //removeToBasket();
    });


    function loadMasterData() {
        var loader = $("".lds-spinner"").show();
        $.ajax({
            url: ""/NewUser/GetMasterUsersListsOnScroll"",
            type: ""GET"",
            contentType: ""application/json;charset=utf-8"",
            dataType: ""json"",
            success: function (result) {
                loader.hi");
            WriteLiteral(@"de();
                CreateHTML(result);
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }

        });
    }

    function CreateHTML(result) {
        //debugger
        var html = '';
        //console.log(""result=> "", result)

        $.each(result, function (key, item) {

            //console.log(""Item=> "",item)
            html += '<tr>';
            //html += '<td>' + item._userId + '</td>';
            item.IsVerified ? html += '<td> <i class="" fa fa-check-circle""></i> ' + item.userName + '</td>' : html += '<td> ' + item.userName + '</td>'
            html += '<td>' + item.userEmail + '</td>';
            html += '<td>' + item.userPhone + '</td>';
            html += '<td>' + item.userPwd + '</td>';
            html += '<td>' + item.countryName + '</td>';
            html += '<td>' + item.provinceName + '</td>';
            html += '<td> <span class=""basket_icon basket_' + item.userId + ' basket_' + i");
            WriteLiteral(@"tem.userId + '_' + item.userName + '""data-name=""' + item.userName + '""data-email=""' + item.userEmail + '""data-isverified=""' + item.IsVerified + '""data-id=""' + item.userId + '""><img src=""/images/plus.png"" id=""plusImg"" alt=""add_to_basket""/></span></td>'
            html += '</tr>';
        });
        $('#tMasterbodyOnScroll').append(html);


    }
    function loadMore() {
        $(window).scroll(function () {

            if (($(window).scrollTop() >= $("".footer_area"").offset().top + $('.footer_area').outerHeight() - window.innerHeight)) {
                console.log(""if=> "", $(window).scrollTop() + $(window).height());
                console.log(""if=> "", $(document).height());
                loadMasterData();
            }

            //$(""#btnMore"").click(function () {
            //    loadMasterData();
            //})
        })
    }
    function addToBasket() {

        $('body').on('click', '.basket_icon', function () {
            //debugger
            var userid = $(thi");
            WriteLiteral(@"s).data('id');
            var name = $(this).data(""name"");
            var email = $(this).data(""email"");
            var isverified = $(this).data(""isverified"");
            var currentClass = $("".basket_"" + userid);
            $('img', currentClass).attr('src', ""/images/plus_cross.png"")
            AppendData(userid, name, email, isverified)

            console.log(""Id=> "" + userid + "" | "" + ""Name=> "" + "" | "" + name + "" | "" + ""Email=> "" + email + "" | "" + ""IsVerified=> "" + isverified)
            addMatchInfoInLocalStorage(userid, name, email, isverified)
            loadCurrentLocation();

        })

    }
    function AppendData(userid, name, email, isverified) {
        var appendHtml = ''
        appendHtml += '<div id=""cartItems_' + userid + '"" class=""cartCount container"">'
        appendHtml += '<h5> Id: ' + userid + '</h5>'
        appendHtml += '<h5> Name: ' + name + '</h5>'
        appendHtml += '<h5> Email: ' + email + '</h5>'
        appendHtml += '<h5> Is Verified: ' + is");
            WriteLiteral(@"verified + '</h5>'
        appendHtml += '</div>'
        appendHtml += '---------------------------------------'
        var usersData = JSON.parse(localStorage.getItem('basket-users'));
        //debugger
        if (usersData.length > 0) {
            //debugger
            usersData = $.grep(usersData, function (m) {
                //debugger

                return m.userid != userid;
            });
            $('.addedData').append(appendHtml)

        }
        ////else {

        ////}
        $("".badge"").html($('.cartCount').length);

    }

    function displayBasket() {

        var usersData = JSON.parse(localStorage.getItem('basket-users'));
        console.log(""displayBasket usersData=> "", usersData)
        usersData = usersData != null ? usersData : [];

        if (usersData.length > 0) {
            usersData = $.grep(usersData, function (m) {
                AppendData(m.userid, m.name, m.email, m.isverified)

            });
        }
    }
    functio");
            WriteLiteral(@"n addMatchInfoInLocalStorage(userid, name, email, isverified) {
        //debugger;
        var usersData = JSON.parse(localStorage.getItem('basket-users'));

        usersData = usersData != null ? usersData : [];

        if (usersData.length > 0) {
            usersData = $.grep(usersData, function (m) {

                return m.userid != userid;

            });
            usersData.push({ userid: userid, name: $.trim(name), email: $.trim(email), isverified: isverified });
        }
        else {
            usersData.push({ userid: userid, name: $.trim(name), email: $.trim(email), isverified: isverified });
        }

        localStorage.setItem('basket-users', JSON.stringify(usersData));

    }

    function loadCurrentLocation() {
        var retrievedObject = localStorage.getItem('UserLive_GeoLocation');
        if (retrievedObject == null || retrievedObject == undefined || retrievedObject == """") {
            $.ajax({
                type: ""get"",
                async: ");
            WriteLiteral(@"false,
                url: ""https://freegeoip.app/json/""
            }).done(function (json) {
                console.log(""Location=> "", json)
                localStorage.setItem('UserLive_GeoLocation', JSON.stringify(json));

            });
        }
    }
    function removeToBasket() {
        $('body').on('click', '.basket_icon', function () {
            debugger
            var userid = $(this).data('id');
            //var name = $(this).data(""name"");
            //var email = $(this).data(""email"");
            //var isverified = $(this).data(""isverified"");
            var currentClass = $("".basket_"" + userid);
            $('img', currentClass).attr('src', ""/images/plus.png"")

            console.log(""removeToBasket"")
            //console.log(""Id=> "" + userid + "" | "" + ""Name=> "" + "" | "" + name + "" | "" + ""Email=> "" + email + "" | "" + ""IsVerified=> "" + isverified)


        })
    }
    function openForm() {
        $(""#myForm"").css(""display"", ""block"");
    }

    functi");
            WriteLiteral("on closeForm() {\r\n        $(\"#myForm\").css(\"display\", \"none\");\r\n    }\r\n</script>");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
