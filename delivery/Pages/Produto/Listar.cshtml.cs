using delivery.Data;
using delivery.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.Linq;

namespace delivery.Pages.Produto
{
    public class Listar : PageModel
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment1;

        public Listar(AppDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment1 = webHostEnvironment;

        }

        public IList<ProdutoModel> Produtos { get; set; }

        public async Task OnGetAsync()
        {
            Produtos = await _context.Produto.OrderBy(p => p.Nome).ToListAsync();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produto.FindAsync(id);

            if (produto != null)
            {
                _context.Produto.Remove(produto);
                    if  (await _context.SaveChangesAsync() >0 )
                    {
                        var caminhoArquivoImagem = Path.Combine(_webHostEnvironment1.WebRootPath, "img\\produto", produto.IdProduto.ToString("D6") + ".jpg");
                        if (System.IO.File.Exists(caminhoArquivoImagem))
                        {
                            System.IO.File.Delete(caminhoArquivoImagem);
                        }
                    }
            }

            return RedirectToPage("./Listar");
        }
    }
}