using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using ProjetoWebMvc.Models;
using ProjetoWebMvc.Services.Exceptions;

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
            
        public Seller FindById(int id)
        {
            return _context.Seller.Include(obj => obj.Department).FirstOrDefault(obj => obj.Id == id);
        }

        public void Remove(int id)
        {
            var obj = _context.Seller.Find(id);
            _context.Seller.Remove(obj);
            _context.SaveChanges();
        }

        public void Upadate(Seller obj)
        {
            if (!_context.Seller.Any(x => x.Id == obj.Id))
            {
                throw new NotFoundException("Id not found");
            }
            try
            {
                _context.Update(obj);
                _context.SaveChanges();
            }
            catch (DbConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
            
            
        }
    }
}
