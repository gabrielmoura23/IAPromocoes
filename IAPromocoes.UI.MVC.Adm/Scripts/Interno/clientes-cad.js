var ClientesCadastro = function () {

    var initComponents = function () {
        //init datepickers
        $('.date-picker').datepicker({
            rtl: Metronic.isRTL(),
            autoclose: true
        });

        //$('.time-picker').timepicker({
        //    showSeconds: false,
        //    showMeridian: false,
        //    minuteStep: 5
        //});

        //$('.time-picker').datetimepicker({
        //    isRTL: Metronic.isRTL(),
        //    format: 'HH:mm',
        //    autoclose: true,
        //    todayBtn: false,
        //    // todayHighlight: true,
        //    showMeridian: false,
        //    startView:0,
        //    maxView:0,
        //    minView: 0,
        //    locale: 'pt'
        //});

        

    }

    return {

        //main function to initiate the module
        init: function () {
            initComponents();
        }

    };

}();