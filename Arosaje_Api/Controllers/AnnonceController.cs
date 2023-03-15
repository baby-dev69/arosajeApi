using Arosaje_Api.DTO;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Arosaje_Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Arosaje_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnnonceController : ControllerBase
    {
        private readonly ArosajeContext ArosajeContext;

        public AnnonceController(ArosajeContext ArosajeContext)
        {
            this.ArosajeContext = ArosajeContext;
        }

        [HttpGet("GetAnnonces")]
        public async Task<ActionResult<List<AnnonceDTO>>> Get()
        {
            var List = await ArosajeContext.Annonces.Select(
                s => new AnnonceDTO
                {
                     id_annonce = s.id_annonce,
                     titre_annonce = s.titre_annonce,
                     description_annonce = s.description_annonce,
                     accepter = s.accepter,
                     id_gardien = s.id_gardien
                }
            ).ToListAsync();

            return List;

        }

        [HttpGet("GetAnnonce/{id}")]
        public async Task<ActionResult<AnnonceDTO>> Get(int id)
        {
            var annonce = await ArosajeContext.Annonces.Where(p => p.id_annonce == id)
                .Select(s => new AnnonceDTO
                {
                    id_annonce = s.id_annonce,
                    titre_annonce = s.titre_annonce,
                    description_annonce = s.description_annonce,
                    accepter = s.accepter,
                    id_gardien = s.id_gardien
                })
                .FirstOrDefaultAsync();

            if (annonce == null)
            {
                return NotFound();
            }

            return annonce;
        }

    }

}

