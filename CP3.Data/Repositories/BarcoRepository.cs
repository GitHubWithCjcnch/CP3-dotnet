using CP3.Data.AppData;
using CP3.Domain.Entities;
using CP3.Domain.Interfaces;

namespace CP3.Data.Repositories
{
    public class BarcoRepository : IBarcoRepository
    {
        private readonly ApplicationContext _context;

        public BarcoRepository(ApplicationContext context)
        {
            _context = context;
        }

        public BarcoEntity? ObterPorId(int id)
        {
            return _context.Set<BarcoEntity>().FirstOrDefault(b => b.Id == id);
        }

        public IEnumerable<BarcoEntity>? ObterTodos()
        {
            return _context.Set<BarcoEntity>().ToList();
        }

        public BarcoEntity? Adicionar(BarcoEntity barco)
        {
            _context.Set<BarcoEntity>().Add(barco);
            _context.SaveChanges();
            return barco;
        }
        
        public BarcoEntity? Editar(BarcoEntity barco)
        {
            _context.Set<BarcoEntity>().Update(barco);
            _context.SaveChanges();
            return barco;
        }

        public BarcoEntity? Remover(int id)
        {
            var barco = _context.Set<BarcoEntity>().FirstOrDefault(b => b.Id == id);
            if (barco != null)
            {
                _context.Set<BarcoEntity>().Remove(barco);
                _context.SaveChanges();
            }
            return barco;
        }
    }
}
