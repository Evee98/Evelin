namespace OperationOOP.Api.Endpoints;

public class CareGuideEndpoints : IEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app)
    {
        // POST för att skapa en ny CareGuide
        app.MapPost("/careguides", HandleCreateCareGuide)
           .WithSummary("Create a new care guide");

        // GET för att hämta en CareGuide baserat på ID
        app.MapGet("/careguides/{id}", HandleGetCareGuide)
           .WithSummary("Get a specific care guide");
    }

    // Request-klass för POST
    public record CreateCareGuideRequest(
        string WateringInstructions,
        string PruningInstructions
    );

    // Response-klass för POST
    public record CreateCareGuideResponse(int Id);

    // Hanterar POST-förfrågan
    private static IResult HandleCreateCareGuide(
        CreateCareGuideRequest request,
        IDatabase db)
    {
        // Skapa en ny CareGuide-instans
        var careGuide = new CareGuide
        {
            Id = db.Bonsais.Any() ? db.Bonsais.Max(b => b.Id) + 1 : 1, // Temporärt ID
            WateringInstructions = request.WateringInstructions,
            PruningInstructions = request.PruningInstructions
        };

        // Lägg till den nya CareGuide-instansen i databasen
        db.Bonsais.Add(new Bonsai { Guide = careGuide }); // Temporär lösning för att spara CareGuide

        // Returnera ID:t för den skapade CareGuide-instansen
        return Results.Ok(new CreateCareGuideResponse(careGuide.Id));
    }

    // Response-klass för GET
    public record GetCareGuideResponse(
        int Id,
        string WateringInstructions,
        string PruningInstructions
    );

    // Hanterar GET-förfrågan
    private static IResult HandleGetCareGuide(
        int id,
        IDatabase db)
    {
        // Hitta CareGuide-instansen baserat på ID
        var careGuide = db.Bonsais
            .Select(b => b.Guide)
            .FirstOrDefault(g => g?.Id == id);

        if (careGuide == null)
        {
            return Results.NotFound("Care guide not found"); // Returnera 404 om inte hittad
        }

        // Mappa CareGuide-instansen till ett Response-objekt
        var response = new GetCareGuideResponse(
            Id: careGuide.Id,
            WateringInstructions: careGuide.WateringInstructions,
            PruningInstructions: careGuide.PruningInstructions
        );

        return Results.Ok(response);
    }
}

