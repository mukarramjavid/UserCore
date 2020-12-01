
$.getScript("/js/signalr/dist/browser/signalr.js", function () {

    let reconnectWaitTime = 5000;

    var connection = new signalR.HubConnectionBuilder().withUrl("/liveupdatehub"
        , {
            skipNegotiation: true,
            transport: signalR.HttpTransportType.WebSockets
        })
        .configureLogging(signalR.LogLevel.Trace)
        .build();


    connection.start().then(function () {
        console.log("Start Connection")

        console.log("Connection Established");
        connection.serverTimeoutInMilliseconds = 3600000;
        connection.keepAliveIntervalInMilliseconds = 30000;
        //console.clear();
    }).catch(err => console.error('SignalR Connection Error: ', err));

    connection.on("getConnectionId", function (connectionId) {
        console.log("connection.On")
        console.log("connectionId=> ", connectionId)
        if ($(".signalr-txt-connectionId").val() != "") {
            connection.invoke("RemoveFromGroup", $(".signalr-txt-connectionId").val(), "_usersList").catch(err => console.error('SignalR Connection Error: ', err.toString()));
        }
        $(".signalr-txt-connectionId").val("");
        $(".signalr-txt-connectionId").val(connectionId);

        if ($(".signalr-txt-connectionId").val() != "") {
            connection.invoke("NewConnection", $(".signalr-txt-connectionId").val(), "_usersList").catch(err => console.error('SignalR Connection Error: ', err.toString()));

            connection.invoke("AddInGroup", $(".signalr-txt-connectionId").val(), "_usersList").catch(err => console.error('SignalR Connection Error: ', err.toString()));
        }
    });

    connection.onclose(async () => {

        await tryReconnect(connection);

    });

    async function tryReconnect(conn) {
        try {
            //console.clear();
            let started = await conn.start();
            console.log('Reconnected!');
            return started;
        } catch (e) {
            await new Promise(resolve => setTimeout(resolve, reconnectWaitTime));
            return await tryReconnect(conn)
        }
    }

    connection.on("NewUsersList", function (newUsers) {
        //alert("Toggle SignalR")
        console.log("NewUsersList=> ", newUsers);
        console.log("Date=> ", new Date().toLocaleTimeString());
        CreateHTML(newUsers);
        var count = newUsers.length;
        //console.log("Count=> ", count)
        $(".badge").text(count)
    });

})

$(document).ready(function () {
    loadMasterData();

});


function loadMasterData() {
    var loader = $(".lds-spinner").show();
    $.ajax({
        url: "/NewUser/GetMasterUsersLists",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loader.hide();
            CreateHTML(result);
            var count = result.length
            //console.log("loadMasterData Count=> ", count)
            $(".badge").text(count)
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }

    });
    //console.warn("connection Id=> ", $(".signalr-txt-connectionId").val())
}

function CreateHTML(result) {
    //debugger
    var html = '';
    //console.log("result=> ", result)

    $.each(result, function (key, item) {

        //console.log("Item=> ",item)
        html += '<tr>';
        //html += '<td>' + item._userId + '</td>';
        item.IsVerified ? html += '<td> <i class=" fa fa-check-circle"></i> ' + item.userName + '</td>' : html += '<td> ' + item.userName + '</td>'
        html += '<td>' + item.userEmail + '</td>';
        html += '<td>' + item.userPhone + '</td>';
        html += '<td>' + item.userPwd + '</td>';
        html += '<td>' + item.countryName + '</td>';
        html += '<td>' + item.provinceName + '</td>';
        html += '</tr>';
    });
    $('#tMasterbody').html(html);
    

}
function VerifyBadge(result) {
    if (result) {
        $('i .fa').addClass(" fa-check-circle ")
        console.log("item.IsVerified=> ", result)
    }
    //console.log("Badge=> ", result)

}

