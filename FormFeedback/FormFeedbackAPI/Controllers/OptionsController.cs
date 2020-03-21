using FormFeedbackAPI.Bases;
using FormFeedbackAPI.Models;
using FormFeedbackAPI.Repositories.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace FormFeedbackAPI.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    //public class OptionsController : ControllerBase
    //{
    //    IOptionService _optionsService;

    //    public OptionsController(IOptionService optionService)
    //    {
    //        _optionsService = optionService;
    //    }

    //    [HttpGet]
    //    public IEnumerable<Option> GetOptions()
    //    {
    //        return _optionsService.Get();
    //    }

    //    [HttpGet("{Id}")]
    //    public ActionResult GetOptions(string id)
    //    {
    //        var options = _optionsService.Get(id);
    //        return Ok(options);
    //    }

    //    [HttpPost]
    //    public ActionResult PostOptions(OptionVM optionVM)
    //    {
    //        var post = _optionsService.Add(optionVM);
    //        if (post > 0)
    //        {
    //            return Ok(post);
    //        }
    //        return BadRequest();
    //    }

    //    [HttpPut("{Id}")]
    //    public ActionResult PutOptions(string id, OptionVM optionVM)
    //    {
    //        var put = _optionsService.Edit(id, optionVM);
    //        if (put > 0)
    //        {
    //            return Ok(put);
    //        }
    //        return BadRequest();
    //    }

    //    [HttpDelete("{Id}")]
    //    public ActionResult Delete(string id)
    //    {
    //        var delete = _optionsService.Delete(id);
    //        if (delete)
    //        {
    //            return Ok(delete);
    //        }
    //        return BadRequest();
    //    }
    //}

    [Route("api/[controller]")]
    [ApiController]
    public class OptionsController : BasesController<Option, OptionRepository>
    {
        public OptionsController(OptionRepository optionRepository) : base(optionRepository)
        {
            
        }
    }
}