using Parcial2_AriasRoldanNatalia.DAL.Entities;
using System.Diagnostics.Metrics;

namespace Parcial2_AriasRoldanNatalia.DAL
{
    public class SeederDb
    {
        private readonly DataBaseContext _context;


        public SeederDb(DataBaseContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await PopulateEntranceAsync();
            await PopulateTicketAsync();
            await _context.SaveChangesAsync();
        }

        private async Task PopulateTicketAsync()
        {
            if (!_context.Entrances.Any())
                for (int i = 0; i == 50000; i++)
                {
                    _context.Tickets.Add(new Ticket
                    {
                        id = new Guid(),
                        CreatedDate = DateTime.Now,
                        ModifiedDate = null,
                        IsUsed = false,
                        EntranceGate= null,
                        UseDate= null
                    });
                }             
        }

        private async Task PopulateEntranceAsync()
        {
            if (!_context.Entrances.Any())
            {
                _context.Entrances.Add(new Entrance
                {
                    id = new Guid(),
                    CreatedDate = DateTime.Now,
                    ModifiedDate = null,
                    Name = "Norte"
                });
                _context.Entrances.Add(new Entrance
                {
                    id = new Guid(),
                    CreatedDate = DateTime.Now,
                    ModifiedDate = null,
                    Name = "Sur"
                });
                _context.Entrances.Add(new Entrance
                {
                    id = new Guid(),
                    CreatedDate = DateTime.Now,
                    ModifiedDate = null,
                    Name = "Occidental"
                });
                _context.Entrances.Add(new Entrance
                {
                    id = new Guid(),
                    CreatedDate = DateTime.Now,
                    ModifiedDate = null,
                    Name = "Oriental"
                });
            }
        }
    }
}
