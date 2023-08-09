using Microsoft.AspNetCore.Mvc;
using Mongodb.RestaurantStore.IServices;
using Mongodb.RestaurantStore.Models;

namespace WebApi.Controllers.Mongodb;

[ApiController]
[Route("api/[controller]")]
public class RestaurantController : ControllerBase
{
    private readonly IInsertServcie _insertServcie;
    private readonly IFindService _findService;
    private readonly IUpdateService _updateService;

    public RestaurantController(
        IInsertServcie insertServcie,
        IFindService findService,
        IUpdateService updateService
    )
    {
        _insertServcie = insertServcie;
        _findService = findService;
        _updateService = updateService;

    }

    [ActionName(nameof(GetOneRestaurantAsyncUsingBuilders))]
    [HttpGet("GetOneRestaurantAsyncUsingBuilders/{id}")]
    public async Task<IActionResult> GetOneRestaurantAsyncUsingBuilders(Guid id)
    {
        var restaurantModel = await _findService.FindOneAsyncUsingBuilders(id);

        if (restaurantModel is null)
            return NotFound();

        return Ok(restaurantModel);
    }

    [ActionName(nameof(GetOneRestaurantAsyncUsingLinq))]
    [HttpGet("GetOneRestaurantAsyncUsingLinq/{id}")]
    public async Task<IActionResult> GetOneRestaurantAsyncUsingLinq(Guid id)
    {
        var restaurantModel = await _findService.FindOneAsyncUsingLinq(id);

        if (restaurantModel is null)
            return NotFound();

        return Ok(restaurantModel);
    }

    [ActionName(nameof(GetManyRestaurantAsyncUsingBuilders))]
    [HttpPost("GetManyRestaurantAsyncUsingBuilders")]
    public async Task<IActionResult> GetManyRestaurantAsyncUsingBuilders([FromBody] IEnumerable<Guid> ids)
    {
        var restaurantModels = await _findService.FindManyAsyncUsingBuilders(ids);

        if (!restaurantModels.Any())
            return NotFound();

        return Ok(restaurantModels);
    }

    [ActionName(nameof(GetManyRestaurantAsyncUsingLinq))]
    [HttpPost("GetManyRestaurantAsyncUsingLinq")]
    public async Task<IActionResult> GetManyRestaurantAsyncUsingLinq([FromBody] IEnumerable<Guid> ids)
    {
        var restaurantModels = await _findService.FindManyAsyncUsingLinq(ids);

         if (!restaurantModels.Any())
            return NotFound();

        return Ok(restaurantModels);
    }

    [HttpPost("CreateOneRestaurantAsync")]
    public async Task<IActionResult> CreateOneRestaurantAsync([FromBody] RestaurantModel restaurantModel)
    {
        await _insertServcie.InsertOneAsync(restaurantModel);
        
        return CreatedAtAction(nameof(GetOneRestaurantAsyncUsingBuilders), new { id = restaurantModel.RestaurantId }, restaurantModel);
    }

    [HttpPost("CreateManyRestaurantsAsync")]
    public async Task<IActionResult> CreateManyRestaurantsAsync([FromBody] IEnumerable<RestaurantModel> restaurantModels)
    {
        await _insertServcie.InsertManyAsync(restaurantModels);
        var ids = restaurantModels.Select(p => p.RestaurantId);

        return CreatedAtAction(nameof(GetManyRestaurantAsyncUsingBuilders), new { ids = ids }, restaurantModels);
    }

    [HttpPut("UpdateOneRestaurantAsync/{id}")]
    public async Task<IActionResult> UpdateOneRestaurantAsync(Guid id, [FromBody] RestaurantModel restaurantModel){
        var result = await _updateService.UpdateOneAsync(id, restaurantModel);
        return Ok(result);
    }
}