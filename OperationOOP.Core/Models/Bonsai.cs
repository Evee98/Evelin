namespace OperationOOP.Core.Models;

public class Bonsai
{
    public int Id { get; set; } // Unikt ID för bonsaiträdet
    public string Name { get; set; } // Namn på bonsaiträdet
    public TreeSpecies Species { get; set; } // Trädart (komposition)
    public int AgeYears { get; set; } // Ålder på bonsaiträdet i år
    public DateTime LastWatered { get; set; } // Senaste gången bonsaiträdet vattnades
    public DateTime LastPruned { get; set; } // Senaste gången bonsaiträdet beskärdes
    public BonsaiStyle Style { get; set; } // Stil på bonsaiträdet (enum)
    public CareLevel CareLevel { get; set; } // Svårighetsgrad för vård (enum)
    public BonsaiPot Pot { get; set; } // Kruka för bonsaiträdet (komposition)
    public CareGuide Guide { get; set; } // Vårdinstruktioner (komposition)
}

public enum BonsaiStyle
{
    Chokkan,    // Formal Upright
    Moyogi,     // Informal Upright
    Shakan,     // Slanting
    Kengai,     // Cascade
    HanKengai   // Semi-cascade
}

public enum CareLevel
{
    Beginner,
    Intermediate,
    Advanced,
    Master
}

// Ny klass för att representera trädarter
public class TreeSpecies
{
    public int Id { get; set; } // Unikt ID för trädarten
    public string Name { get; set; } // Namn på trädarten (t.ex. "Ficus")
    public string Description { get; set; } // Beskrivning av trädarten
}

// Ny klass för att representera vårdinstruktioner
public class CareGuide
{
    public int Id { get; set; } // Unikt ID för vårdinstruktionen
    public string WateringInstructions { get; set; } // Instruktioner för vattning
    public string PruningInstructions { get; set; } // Instruktioner för beskärning
}

// Ny klass för att representera krukor
public class BonsaiPot
{
    public int Id { get; set; } // Unikt ID för krukan
    public string Material { get; set; } // Material för krukan (t.ex. "Keramik")
    public double Size { get; set; } // Storlek på krukan (t.ex. 15.5)
}