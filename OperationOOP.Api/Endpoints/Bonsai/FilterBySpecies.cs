using OperationOOP.Core.Services;

namespace OperationOOP.Api.Endpoints;

public class FilterBySpecies : IEndpoint
{
    // Mappar endpointen till en GET-förfrågan
    public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapGet("/bonsais/species/{speciesName}", Handle)
        .WithSummary("Filter bonsai trees by species");

    // Request-klass för att hantera inkommande parametrar
    public record Request(string SpeciesName);

    // Response-klass för att strukturera svaret
    public record Response(
        int Id,
        string Name,
        string Species,
        int AgeYears,
        DateTime LastWatered,
        DateTime LastPruned,
        BonsaiStyle Style,
        CareLevel CareLevel
    );

    // Hanterar GET-förfrågan
    private static List<Response> Handle([AsParameters] Request request, BonsaiManager manager)
    {
        // Använder BonsaiManager för att filtrera bonsaiträd
        var bonsais = manager.FilterBySpecies(request.SpeciesName);

        // Mappar bonsaiträd till Response-objekt
        return bonsais.Select(b => new Response(
            Id: b.Id,
            Name: b.Name,
            Species: b.Species.Name,
            AgeYears: b.AgeYears,
            LastWatered: b.LastWatered,
            LastPruned: b.LastPruned,
            Style: b.Style,
            CareLevel: b.CareLevel
        )).ToList();
    }
}