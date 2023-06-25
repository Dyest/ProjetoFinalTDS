using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using delivery.Data;
using delivery.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace delivery.Pages.Cliente
{
    public class Listar : PageModel
    {

        private readonly AppDbContext _context;

        [BindProperty]
        public IList<ClienteModel>  Clientes { get; set; }
        
        public Listar(AppDbContext context){
            _context = context;
        }
        public async Task OnGetAsync()
        {
            Clientes = await _context.Cliente.ToListAsync();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Cliente.FindAsync(id);

            if (cliente != null)
            {
                _context.Cliente.Remove(cliente);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Listar");
        }
    }
}