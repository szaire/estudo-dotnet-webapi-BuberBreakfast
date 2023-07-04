using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuberBreakfast.Contracts.Breakfast;
using BuberBreakfast.Models;
using Microsoft.AspNetCore.Mvc;

namespace BuberBreakfast.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class BreakfastsController : ControllerBase
	{
		[HttpPost]
		public  IActionResult CreateBreakfast(CreateBreakfastRequest request)
		{
			var breakfast = new Breakfast(
				Guid.NewGuid(),
				request.Name,
				request.Description,
				request.StartDateTime,
				request.EndDateTime,
				DateTime.UtcNow,
				request.Savory,
				request.Sweet);

			var response = new BreakfastResponse(
				breakfast.Id,
				breakfast.Name,
				breakfast.Description,
				breakfast.StartDateTime,
				breakfast.EndDateTime,
				breakfast.LastModifiedDateTime,
				breakfast.Savory,
				breakfast.Sweet);

			return CreatedAtAction(
				nameof(CreateBreakfast), // Indica a ação da API que criou o novo item
				new {id = breakfast.Id}, // Cria um objeto de mesmo id do objeto "breakfast" criado
				response);				 // Passa a resposta para o servidor
		}

		[HttpGet("{id:guid}")]
		public  IActionResult GetBreakfast(Guid id)
		{
			return Ok(id);
		}

		[HttpPut("{id:guid}")]
		public  IActionResult GetBreakfast(Guid id, UpsertBreakfastRequest request)
		{
			return Ok(request);
		}

		[HttpDelete("{id:guid}")]
		public  IActionResult DeleteBreakfast(Guid id)
		{
			return Ok(id);
		}
	}
}