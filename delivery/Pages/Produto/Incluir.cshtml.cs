using System.Threading.Tasks;
using delivery.Data;
using delivery.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Hosting;


namespace delivery.Pages.Produto
{
    public class Incluir : PageModel
    {
        [BindProperty]
        public ProdutoModel Produto { get; set; }

        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public string CaminhoImagem { get; set;}

        [BindProperty]
        [Display(Name = "Imagem do Produto")]
        [Required(ErrorMessage = "O campo \"{0}\" é de preenchimento obrigatorio")]
        public IFormFile ImagemProduto { get; set;}

        public Incluir(AppDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            CaminhoImagem = "~/img/produto/sem_imagem.jpg";
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ImagemProduto == null)
            {
                return Page();
            }

            var produto = new ProdutoModel();

            if (await TryUpdateModelAsync(produto, Produto.GetType(), nameof(Produto)))
            {
                _context.Produto.Add(produto);
                await _context.SaveChangesAsync();
                await AppUtils.ProcessarArquivoDeImagem(produto.IdProduto, 
                ImagemProduto, _webHostEnvironment);
                return RedirectToPage("./Listar");
               
            }

            return Page();
             
        }
    }
}