using Arosaje_Api.DTO;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Arosaje_Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Arosaje_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlanteController :ControllerBase
    {
        private readonly ArosajeContext ArosajeContext;

        public PlanteController(ArosajeContext ArosajeContext)
        {
            this.ArosajeContext = ArosajeContext;
        }



        [HttpGet("GetPlantes")]
        public async Task<ActionResult<List<PlanteDTO>>> Get()
        {
            var List = await ArosajeContext.Plantes.Select(
                s => new PlanteDTO
                {
                    id_plante = s.id_plante,
                    nom_plante = s.nom_plante,
                    espece_plante = s.espece_plante,
                    adresse_plante = s.adresse_plante,
                }
            ).ToListAsync();

             return List;
            
        }

        [HttpGet("GetPlante/{id}")]
        public async Task<ActionResult<PlanteDTO>> Get(int id)
        {
            var plante = await ArosajeContext.Plantes.Where(p => p.id_plante == id)
                .Select(s => new PlanteDTO
                {
                    id_plante = s.id_plante,
                    nom_plante = s.nom_plante,
                    espece_plante = s.espece_plante,
                    adresse_plante = s.adresse_plante,
                })
                .FirstOrDefaultAsync();

            if (plante == null)
            {
                return NotFound();
            }

            return plante;
        }

    }

}
