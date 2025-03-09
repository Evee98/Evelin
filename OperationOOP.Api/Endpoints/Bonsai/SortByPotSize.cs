using OperationOOP.Core.Services;

namespace OperationOOP.Api.Endpoints;

public class SortByPotSize : IEndpoint
{
    // Mappar endpointen till en GET-förfrågan
    public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapGet("/bonsais/sorted-by-pot-size", Handle)
        .WithSummary("Sort bonsai trees by pot size");

    // Response-klass för att strukturera svaret
    public record Response(
        int Id,
        string Name,
        double PotSize
    );

    // Hanterar GET-förfrågan
    private static List<Response> Handle(BonsaiManager manager)
    {
        // Använder BonsaiManager för att sortera bonsaiträd
        var bonsais = manager.SortByPotSize();

        // Mappar bonsaiträd till Response-objekt
        return bonsais.Select(b => new Response(
            Id: b.Id,
            Name: b.Name,
            PotSize: b.Pot.Size
        )).ToList();
    }
}