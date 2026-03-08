namespace FamilyTreeApi.Models;

public class FamilyMember
{
      public string Id { get; set; } = Guid.NewGuid().ToString();
      public string GivenNames { get; set; } = string.Empty;
      public string SurnameNow { get; set; } = string.Empty;
      public string SurnameAtBirth { get; set; } = string.Empty;
      public string Gender { get; set; } = "Other";
      public string? BirthDay { get; set; }
      public string? BirthMonth { get; set; }
      public string? BirthYear { get; set; }
      public bool IsLiving { get; set; } = true;
      public string? Email { get; set; }
      public string? Phone { get; set; }
      public string? Notes { get; set; }
      public double X { get; set; } = 400;
      public double Y { get; set; } = 300;
}

public class Relationship
{
      public string Id { get; set; } = Guid.NewGuid().ToString();
      public string Person1Id { get; set; } = string.Empty;
      public string Person2Id { get; set; } = string.Empty;
      public string Type { get; set; } = "parent"; // parent, spouse
}

public class FamilyTree
{
      public List<FamilyMember> Members { get; set; } = new();
      public List<Relationship> Relationships { get; set; } = new();
}
