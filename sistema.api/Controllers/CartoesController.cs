using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sistema.api.Data;
using sistema.api.Models;

namespace sistema.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartoesController : Controller
    {
        private readonly CartaoDbContext cartaoDbContext;

        public CartoesController(CartaoDbContext cartaoDbContext)
        {
            this.cartaoDbContext = cartaoDbContext; //isso é a create da controller metodo contrutor 
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCartoes()
        {
            var cartao = await cartaoDbContext.Cartoes.ToListAsync();
            return Ok(cartao);

        }

        // get 1 cartoes 
        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetCartao")]
        public async Task<IActionResult> GetCartao([FromRoute] Guid id)
        {
            var cartao = await cartaoDbContext.Cartoes.FirstOrDefaultAsync(x => x.Id == id);
            if (cartao != null)
            {
                return Ok(cartao);
            }
            return NotFound("cartão não encontrado !");
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarCartao([FromBody] Cartao cartao)
        {
            cartao.Id = Guid.NewGuid();

            await cartaoDbContext.Cartoes.AddAsync(cartao);
            await cartaoDbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCartao), new { id = cartao.Id }, cartao);


        }


        [HttpPut]
        [Route("{id:guid}")]
        public async Task<ActionResult> AtualizarCartao([FromRoute] Guid id, [FromBody] Cartao cartao)
        {

            var cartaoExistente = await cartaoDbContext.Cartoes.FirstOrDefaultAsync(x => x.Id == id);
            if (cartaoExistente != null)
            {
                cartaoExistente.NomeCartao = cartao.NomeCartao;
                cartaoExistente.NumeroDoCartao = cartao.NumeroDoCartao;
                cartaoExistente.AnoDeExpiracao = cartao.AnoDeExpiracao;
                cartaoExistente.MesDeExpiracao = cartao.MesDeExpiracao;
                cartaoExistente.CVC = cartao.CVC;
                await cartaoDbContext.SaveChangesAsync();
                return Ok(cartaoExistente); 
            }
            return NotFound("Cartão não encontrado para atualizar");
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<ActionResult> DeletarCartao([FromBody] Guid id)
        {

            var cartaoExistente = await cartaoDbContext.Cartoes.FirstOrDefaultAsync(x => x.Id == id);
            if (cartaoExistente != null)
            {
                cartaoDbContext.Remove(cartaoExistente);
                await cartaoDbContext.SaveChangesAsync();
                return Ok(cartaoExistente);
            }
            return NotFound("Cartão não encontrado para Exclusão");
        }



    }
}
