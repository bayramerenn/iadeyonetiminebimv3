using Microsoft.AspNetCore.Builder;
using Smidge;

namespace CivilManagement.UI.CustomExtention
{
    public static class SmidgeCustom
    {
        public static void UseSmidgeCustom(this IApplicationBuilder app)
        {
            app.UseSmidge(bundle =>
            {
                bundle.CreateJs("my-js-bundle",
                    "~/jquery/jquery.min.js",
                    "~/AdminLTE/plugins/bootstrap/js/bootstrap.bundle.min.js",
                    "~/jquery-validate/jquery.validate.min.js",
                     "~/jquery-validation-unobtrusive/jquery.validate.unobtrusive.min.js",
                    "~/AdminLTE/plugins/select2/js/select2.full.min.js",
                    "~/sweetalert2/dist/sweetalert2.all.min.js",
                    "~/AdminLTE/plugins/moment/moment.min.js",
                    "~/AdminLTE/plugins/inputmask/min/jquery.inputmask.bundle.min.js",
                    "~/AdminLTE/plugins/daterangepicker/daterangepicker.js",
                    "~/AdminLTE/dist/js/adminlte.min.js",
                    "~/lib/js/product.js",
                    "~/lib/js/request.js",
                    "~/lib/js/ui.js",
                    "~/lib/js/app.js",
                    "~/lib/js/datepickercustomer.js"
                    );

                bundle.CreateCss("my-css-bundle",
                        "~/AdminLTE/plugins/fontawesome-free/css/all.min.css",
                        "~/AdminLTE/plugins/daterangepicker/daterangepicker.css",
                        "~/AdminLTE/plugins/bootstrap-colorpicker/css/bootstrap-colorpicker.min.css",
                        "~/sweetalert2/dist/sweetalert2.min.css",
                        "~/AdminLTE/plugins/select2/css/select2.min.css",
                        "~/AdminLTE/dist/css/adminlte.min.css",
                        "~/lib/css/googleapis.css"
                        );
            });
        }
    }
}