$(function () {
    $(".select2").select2({
        selectOnClose: true
    });

    $("#reservation").daterangepicker({
        singleDatePicker: true,
        showDropdowns: true,
        minYear: 1901,
        locale: {
            format: "DD/MM/YYYY",
            daysOfWeek: ["Paz", "Pzt", "Sal", "Çar", "Per", "Cum", "Cmt"],
            monthNames: ["Ocak", "Şubat", "Mart", "Nisan", "Mayıs", "Haziran", "Temmuz", "Ağustos", "Eylül", "Ekim", "Kasım", "Aralık"],
            firstDay: 1,
        },
    });
});