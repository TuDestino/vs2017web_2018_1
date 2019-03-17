(function (cibertec) {
    cibertec.helpers
    {
        replaceAll : function (string, find, replace) {
            var result = string.replace(
                new RegExpr(find, 'g'), replace
            );

            return result;
        },
        getAniosArray: function(anioInicio) {
                var hoy = new Date();
                var anios = [];
                for (i = anioInicio; i <= hoy.getFullYear(); i++) {
                    anios.push(i);
                }

                return anios;
        },
        BloquearControls : function()
        {
            $("input,select,button,textarea").attr("disabled", "disabled");
        },
        DesbloquearControls: function() {
            $("input,select,button,textarea").removeAttr("disabled");
        }

    }
})(window.cibertec = window.cibertec || {});