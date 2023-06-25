using Microsoft.EntityFrameworkCore;
using delivery.Models;


namespace delivery.Data
{
    public class AppDbContext : DbContext
    {
       public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ClienteModel>(entity =>
            {
                entity.OwnsOne(c => c.Endereco);
            });

            modelBuilder.Entity<ItemPedidoModel>()
                .HasKey(e => new { e.IdPedido, e.IdProduto});
            modelBuilder.Entity<Favorito>()
                .HasKey(e => new { e.IdCliente, e.IdProduto});
            modelBuilder.Entity<Visitado>()
                .HasKey(e => new { e.IdCliente, e.IdProduto});
        }

        public DbSet<ProdutoModel>? Produto {get; set;}
        public DbSet<ClienteModel>? Cliente {get; set;}
        public DbSet<PedidoModel>? Pedido {get; set;}
        public DbSet<ItemPedidoModel>? ItemPedido {get; set;}
        public DbSet<Favorito>? Favorito {get; set; }
        public DbSet<Visitado>? Visitado {get; set;}

        static readonly string connectionString = "Server=db_mysql;Port=3306;Database=delivery;Uid=root;Pwd=delivery;";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            optionsBuilder.UseMySql(connectionString,
                                    ServerVersion.AutoDetect(connectionString));
        }
    }
}