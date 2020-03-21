$(document).ready(function () {
    RoomCount();
    RoomCountEvent(3, 2020);
});
debugger;
function RoomCount() {
    $.ajax({
        type: 'GET',
        url: '/Dashboard/CountRoom/',
        success: function (data) {
            debugger;
            Morris.Bar({
                element: 'rooms-chart',
                data: $.each(JSON.parse(data), function (index, val) {
                    [{
                        label: val.label,
                        value: val.value
                    }]
                }),
                xkey: 'label',
                ykeys: ['value'],
                labels: ['Quantity'],
                resize: true
            });
        }
    });
}
function RoomCountEvent(mth, yrs) {
    $.ajax({
        type: 'GET',
        url: '/Dashboard/CountRoomEvent/' + mth + '&' + yrs,
        dataType: 'json',
        data: { Mth: mth, Yrs: yrs }
    }).then((data) => {
        debugger;
        Morris.Bar({
            element: 'rooms-event-chart',
            data: $.each(JSON.parse(data), function (index, val) {
                [{
                    label: val.label,
                    value: val.value
                }]
            }),
            xkey: 'label',
            ykeys: ['value'],
            labels: ['Quantity'],
            resize: true
        });
    });
}