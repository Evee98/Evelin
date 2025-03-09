using OperationOOP.Core.Data;
using OperationOOP.Core.Models;

namespace OperationOOP.Core.Services
{
    public class BonsaiManager
    {
        private readonly IDatabase _db;

        // Konstruktor som tar emot en IDatabase-instans via Dependency Injection
        public BonsaiManager(IDatabase db)
        {
            _db = db;
        }

        // Filtrera bonsaiträd efter art
        public List<Bonsai> FilterBySpecies(string speciesName)
        {
            return _db.Bonsais
                .Where(b => b.Species.Name == speciesName) // Använd LINQ för att filtrera
                .ToList();
        }

        // Sortera bonsaiträd efter kruksstorlek
        public List<Bonsai> SortByPotSize()
        {
            return _db.Bonsais
                .OrderBy(b => b.Pot.Size) // Använd LINQ för att sortera
                .ToList();
        }

        // Beräkna medelstorleken på krukor
        public double CalculateAveragePotSize()
        {
            return _db.Bonsais
                .Average(b => b.Pot.Size); // Använd LINQ för att beräkna medelvärde
        }
    }
}