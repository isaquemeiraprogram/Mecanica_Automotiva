﻿using Mecanica_Automotiva.Dtos.DtosDadosVeiculo;
using Mecanica_Automotiva.Models.DadosVeiculo;
using Mecanica_Automotiva.Services.DadosVeiculoService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mecanica_Automotiva.Controllers.DadosVeiculoController
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcaController : ControllerBase
    {
        private readonly MarcaService _service;

        public MarcaController(MarcaService _service)
        {
            this._service = _service;
        }

        [HttpGet]
        public async Task<ActionResult<List<Marca>>> GetAllAsync()
        {
            var marcaList = await _service.GetAllAsync();
            return Ok(marcaList);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Marca>> GetByIdAsync(Guid id)
        {
            var marca = await _service.GetByIdAsync(id);
            if (marca == null) return NotFound("Marca Não Encontrada"); 

            return Ok(marca);
        }

        [HttpPost]
        public async Task<ActionResult<Marca>> AddAsync([FromBody] MarcaDto dto)
        {
            var marca = await _service.AddAsync(dto);
            return Ok(marca);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Marca>> UpdateAsync([FromBody] MarcaDto dto, Guid id)
        {
            var marca = await _service.UpdateAsync(dto, id);
            if (marca == null) return NotFound("Marca Não Encontrada");

            return Ok(marca);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteAsync(Guid id)
        {
            var marca = await _service.DeleteAsync(id);
            if (marca == false) return NotFound("Marca Não Encontrada");

            return true;
        }
    }
}
