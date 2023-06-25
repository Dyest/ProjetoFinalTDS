using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using delivery.Data;
using delivery.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace delivery.Pages.Cliente
{
    public class Incluir : PageModel
    {
        private AppDbContext _context;

        [BindProperty]
        public ClienteModel Cliente { get; set; }

        public Incluir (AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

       public async Task<IActionResult> OnPostAsync()
        {
            var cliente = new ClienteModel();
            cliente.Endereco = new EnderecoModel();
            //novos clientes sempre iniciam com essa situação
            cliente.Situacao = ClienteModel.SituacaoCliente.Cadastrado;
            
                _context.Cliente.Add(Cliente);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Listar");

        }
    }
}