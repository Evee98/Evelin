namespace OperationOOP.Core.Models;

public class Bonsai
{
    public int Id { get; set; } // Unikt ID f�r bonsaitr�det
    public string Name { get; set; } // Namn p� bonsaitr�det
    public TreeSpecies Species { get; set; } // Tr�dart (komposition)
    public int AgeYears { get; set; } // �lder p� bonsaitr�det i �r
    public DateTime LastWatered { get; set; } // Senaste g�ngen bonsaitr�det vattnades
    public DateTime LastPruned { get; set; } // Senaste g�ngen bonsaitr�det besk�rdes
    public BonsaiStyle Style { get; set; } // Stil p� bonsaitr�det (enum)
    public CareLevel CareLevel { get; set; } // Sv�righetsgrad f�r v�rd (enum)
    public BonsaiPot Pot { get; set; } // Kruka f�r bonsaitr�det (komposition)
    public CareGuide Guide { get; set; } // V�rdinstruktioner (komposition)
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

// Ny klass f�r att representera tr�darter
public class TreeSpecies
{
    public int Id { get; set; } // Unikt ID f�r tr�darten
    public string Name { get; set; } // Namn p� tr�darten (t.ex. "Ficus")
    public string Description { get; set; } // Beskrivning av tr�darten
}

// Ny klass f�r att representera v�rdinstruktioner
public class CareGuide
{
    public int Id { get; set; } // Unikt ID f�r v�rdinstruktionen
    public string WateringInstructions { get; set; } // Instruktioner f�r vattning
    public string PruningInstructions { get; set; } // Instruktioner f�r besk�rning
}

// Ny klass f�r att representera krukor
public class BonsaiPot
{
    public int Id { get; set; } // Unikt ID f�r krukan
    public string Material { get; set; } // Material f�r krukan (t.ex. "Keramik")
    public double Size { get; set; } // Storlek p� krukan (t.ex. 15.5)
}