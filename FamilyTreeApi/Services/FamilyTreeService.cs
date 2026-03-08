using FamilyTreeApi.Models;
using System.Text.Json;

namespace FamilyTreeApi.Services;

public class FamilyTreeService
{
      private readonly string _dataFile;
      private FamilyTree _tree;

      public FamilyTreeService(IWebHostEnvironment env)
      {
                _dataFile = Path.Combine(env.ContentRootPath, "familytree.json");
                _tree = Load();
      }

      private FamilyTree Load()
      {
                if (!File.Exists(_dataFile)) return new FamilyTree();
                var json = File.ReadAllText(_dataFile);
                return JsonSerializer.Deserialize<FamilyTree>(json) ?? new FamilyTree();
      }

      private void Save()
      {
                var json = JsonSerializer.Serialize(_tree, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(_dataFile, json);
      }

      public FamilyTree GetTree() => _tree;

      public FamilyMember AddMember(FamilyMember member)
      {
                member.Id = Guid.NewGuid().ToString();
                _tree.Members.Add(member);
                Save();
                return member;
      }

      public FamilyMember? UpdateMember(string id, FamilyMember updated)
      {
                var existing = _tree.Members.FirstOrDefault(m => m.Id == id);
                if (existing == null) return null;
                updated.Id = id;
                var idx = _tree.Members.IndexOf(existing);
                _tree.Members[idx] = updated;
                Save();
                return updated;
      }

      public bool DeleteMember(string id)
      {
                var member = _tree.Members.FirstOrDefault(m => m.Id == id);
                if (member == null) return false;
                _tree.Members.Remove(member);
                _tree.Relationships.RemoveAll(r => r.Person1Id == id || r.Person2Id == id);
                Save();
                return true;
      }

      public Relationship AddRelationship(Relationship rel)
      {
                rel.Id = Guid.NewGuid().ToString();
                _tree.Relationships.Add(rel);
                Save();
                return rel;
      }

      public bool DeleteRelationship(string id)
      {
                var rel = _tree.Relationships.FirstOrDefault(r => r.Id == id);
                if (rel == null) return false;
                _tree.Relationships.Remove(rel);
                Save();
                return true;
      }
}
