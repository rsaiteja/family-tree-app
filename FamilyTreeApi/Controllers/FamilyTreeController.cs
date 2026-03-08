using FamilyTreeApi.Models;
using FamilyTreeApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace FamilyTreeApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FamilyTreeController : ControllerBase
{
    private readonly FamilyTreeService _service;

        public FamilyTreeController(FamilyTreeService service)
            {
                    _service = service;
                        }

                            [HttpGet]
                                public IActionResult GetTree() => Ok(_service.GetTree());

                                    [HttpGet("members")]
                                        public IActionResult GetMembers() => Ok(_service.GetTree().Members);

                                            [HttpPost("members")]
                                                public IActionResult AddMember([FromBody] FamilyMember member)
                                                    {
                                                            var created = _service.AddMember(member);
                                                                    return CreatedAtAction(nameof(GetMembers), new { id = created.Id }, created);
                                                                        }

                                                                            [HttpPut("members/{id}")]
                                                                                public IActionResult UpdateMember(string id, [FromBody] FamilyMember member)
                                                                                    {
                                                                                            var updated = _service.UpdateMember(id, member);
                                                                                                    if (updated == null) return NotFound();
                                                                                                            return Ok(updated);
                                                                                                                }
                                                                                                                
                                                                                                                    [HttpDelete("members/{id}")]
                                                                                                                        public IActionResult DeleteMember(string id)
                                                                                                                            {
                                                                                                                                    if (!_service.DeleteMember(id)) return NotFound();
                                                                                                                                            return NoContent();
                                                                                                                                                }
                                                                                                                                                
                                                                                                                                                    [HttpGet("relationships")]
                                                                                                                                                        public IActionResult GetRelationships() => Ok(_service.GetTree().Relationships);
                                                                                                                                                        
                                                                                                                                                            [HttpPost("relationships")]
                                                                                                                                                                public IActionResult AddRelationship([FromBody] Relationship rel)
                                                                                                                                                                    {
                                                                                                                                                                            var created = _service.AddRelationship(rel);
                                                                                                                                                                                    return CreatedAtAction(nameof(GetRelationships), new { id = created.Id }, created);
                                                                                                                                                                                        }
                                                                                                                                                                                        
                                                                                                                                                                                            [HttpDelete("relationships/{id}")]
                                                                                                                                                                                                public IActionResult DeleteRelationship(string id)
                                                                                                                                                                                                    {
                                                                                                                                                                                                            if (!_service.DeleteRelationship(id)) return NotFound();
                                                                                                                                                                                                                    return NoContent();
                                                                                                                                                                                                                        }
                                                                                                                                                                                                                        }
