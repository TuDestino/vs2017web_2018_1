(function (app) {
    app.CategoriaView =
        {
            
        RefreshLista: function () {
                $(".Buscar").click();
                app.helpers.closeModal("CategoriaCreatePopup");
            }

        }
})(window.app = window.app || {});