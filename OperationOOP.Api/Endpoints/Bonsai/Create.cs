namespace OperationOOP.Api.Endpoints;

public class CreateBonsai : IEndpoint
{
    // Mappar endpointen till en POST-förfrågan
    public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapPost("/bonsais", Handle)
        .WithSummary("Create a new bonsai tree");

    // Request-klass för att hantera inkommande data
    public record Request(
        string Name,
        string SpeciesName, // Namn på trädarten
        int AgeYears,
        DateTime LastWatered,
        DateTime LastPruned,
        BonsaiStyle Style,
        CareLevel CareLevel,
        string PotMaterial, // Material för krukan
        double PotSize // Storlek på krukan
    );

    // Response-klass för att strukturera svaret
    public record Response(int Id);

    // Hanterar POST-förfrågan
    private static Ok<Response> Handle(Request request, IDatabase db)
    {
        // Skapar en ny TreeSpecies-instans
        var species = new TreeSpecies
        {
            Id = db.Bonsais.Any() ? db.Bonsais.Max(b => b.Id) + 1 : 1, // Temporärt ID
            Name = request.SpeciesName,
            Description = "Beskrivning saknas" // Kan utökas med mer information
        };

        // Skapar en ny BonsaiPot-instans
        var pot = new BonsaiPot
        {
            Id = db.Bonsais.Any() ? db.Bonsais.Max(b => b.Id) + 1 : 1, // Temporärt ID
            Material = request.PotMaterial,
            Size = request.PotSize
        };

        // Skapar en ny Bonsai-instans
        var bonsai = new Bonsai
        {
            Id = db.Bonsais.Any() ? db.Bonsais.Max(b => b.Id) + 1 : 1,
            Name = request.Name,
            Species = species, // Tilldelar TreeSpecies-instansen
            AgeYears = request.AgeYears,
            LastWatered = request.LastWatered,
            LastPruned = request.LastPruned,
            Style = request.Style,
            CareLevel = request.CareLevel,
            Pot = pot // Tilldelar BonsaiPot-instansen
        };

        // Lägger till det nya bonsaiträdet i databasen
        db.Bonsais.Add(bonsai);

        // Returnerar ID:t för det skapade bonsaiträdet
        return TypedResults.Ok(new Response(bonsai.Id));
    }
}