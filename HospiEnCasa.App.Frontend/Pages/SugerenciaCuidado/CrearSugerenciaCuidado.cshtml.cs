using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HospiEnCasa.App.Dominio;
using HospiEnCasa.App.Persistencia;

namespace HospiEnCasa.Frontend.Pages
{
    public class CrearSugerenciaCuidadoModel : PageModel
    {
        private static IRepositorioSugerenciaCuidado _repositorioSugerenciaCuidado = new RepositorioSugerenciaCuidado(new HospiEnCasa.App.Persistencia.AppContext());

        public SugerenciaCuidado SugerenciaCuidado { get; set; }

        public CrearSugerenciaCuidadoModel()
        { }


        public ActionResult OnGet()
        {
            return Page();
        }

        public ActionResult OnPost()
        {
            try
            {
                SugerenciaCuidado sugerenciaCuidadoAdicionado = _repositorioSugerenciaCuidado.AddSugerenciaCuidado(SugerenciaCuidado);
                return RedirectToPage("./DescripcionSugerenciaCuidado");
            }
            catch (System.Exception e)
            {
                ViewData["Error"] = "Error: " + e.Message;
                return Page();
            }
        }

    }
}

