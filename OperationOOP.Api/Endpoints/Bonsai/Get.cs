namespace OperationOOP.Api.Endpoints;

public class GetBonsai : IEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapGet("/bonsais/{id}", Handle)
        .WithSummary("Get a specific bonsai tree");

    public record Request(int Id);

    public record Response(
        int Id,
        string Name,
        string Species, // Uppdaterat: Tar emot artens namn som en sträng
        int AgeYears,
        DateTime LastWatered,
        DateTime LastPruned,
        BonsaiStyle Style,
        CareLevel CareLevel
    );

    private static Response Handle([AsParameters] Request request, IDatabase db)
    {
        var bonsai = db.Bonsais.Find(bonsai => bonsai.Id == request.Id);

        if (bonsai == null)
        {
            throw new Exception("Bonsai not found"); // Hantera fall där bonsaiträdet inte hittas
        }

        // Mappa bonsai till response DTO
        var response = new Response(
            Id: bonsai.Id,
            Name: bonsai.Name,
            Species: bonsai.Species.Name, // Hämta artens namn från TreeSpecies-objektet
            AgeYears: bonsai.AgeYears,
            LastWatered: bonsai.LastWatered,
            LastPruned: bonsai.LastPruned,
            Style: bonsai.Style,
            CareLevel: bonsai.CareLevel
        );

        return response;
    }
}