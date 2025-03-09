using OperationOOP.Core.Services;

namespace OperationOOP.Api.Endpoints;

public class AveragePotSize : IEndpoint
{
    // Mappar endpointen till en GET-förfrågan
    public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapGet("/bonsais/average-pot-size", Handle)
        .WithSummary("Calculate average pot size of bonsai trees");

    // Response-klass för att strukturera svaret
    public record Response(double AveragePotSize);

    // Hanterar GET-förfrågan
    private static Response Handle(BonsaiManager manager)
    {
        // Använder BonsaiManager för att beräkna medelstorleken på krukor
        var averageSize = manager.CalculateAveragePotSize();
        return new Response(averageSize);
    }
}s