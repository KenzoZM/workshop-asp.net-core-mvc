using ProjetoWebMvc.Models;
namespace ProjetoWebMvc.Services
{
    public class SellerService
    {
        // declarando uma dependencia para o DBcontext - ProjetoWebMvcContext
        private readonly ProjetoWebMvcContext _context;

        public SellerService(ProjetoWebMvcContext context)
        {
            _context = context;
        }

        // operação que retorna do banco de dados todos os vendedores
        public List<Seller> FindAll() 
        {
            return _context.Seller.ToList();
        }

        public void Insert(Seller obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }
    }
}
