using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HospiEnCasa.App.Dominio;
using HospiEnCasa.App.Persistencia;

namespace HospiEnCasa.Frontend.Pages
{
    public class EditarSugerenciaCuidadoModel : PageModel
    {private static IRepositorioSugerenciaCuidado _repositorioSugerenciaCuidado = new RepositorioSugerenciaCuidado(new HospiEnCasa.App.Persistencia.AppContext());
        [BindProperty]
         public SugerenciaCuidado SugerenciaCuidado { get; set; }

        public EditarSugerenciaCuidadoModel()
        { }


        public ActionResult OnGet(int id)
        {
            this.SugerenciaCuidado= _repositorioSugerenciaCuidado.GetSugerenciaCuidado(id);
            return Page();
        }

        public ActionResult OnPost()
        {
            try
            {
                SugerenciaCuidado sugerenciasCuidadosActualizado = _repositorioSugerenciaCuidado.UpdateSugerenciaCuidado(SugerenciaCuidado);
                return RedirectToPage("./ListaSignosVitales");
            }
            catch (System.Exception e)
            {
                ViewData["Error"] = "Error: " + e.Message;
                return Page();
            }
        }
    }
}
