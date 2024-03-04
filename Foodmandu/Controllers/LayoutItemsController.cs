using Foodmandu.Model;
using Foodmandu.Service;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Net;

namespace Foodmandu.Controllers
{
    [Route("api")]
    [ApiController]
    [EnableCors("AllowAnyOrigin")]
    public class LayoutItemsController : ControllerBase
    {
        private readonly FoodmanduDbContext _foodmanduDbContext;
        private readonly ILayoutService _layoutService;
        private readonly IFileServices _fileServices;

        public LayoutItemsController(FoodmanduDbContext foodmanduDbContext,ILayoutService layoutService,IFileServices fileServices)
        {
            _foodmanduDbContext = foodmanduDbContext;
            _layoutService = layoutService;
            _fileServices = fileServices;
        }
        [HttpGet]
        [Route("layout/list")]
        public async Task<dynamic> LayoutDetails()
        {
            var layoutDetails = _layoutService.GetLayoutDetails(); 
            return HttpResponse((int)HttpStatusCode.OK, "Layout data", layoutDetails);
        }

        [HttpGet]
        [Route("layout/items/{id}")]
        public async Task<dynamic> LayoutItems(int id)
        {
            try
            {
                var layoutItemDetails = _layoutService.GetLayoutItemDetails(id);
                //var layoutItemDetails =  _foodmanduDbContext.LayoutItems.Where(x => x.layoutId == id).ToList();
                return HttpResponse((int)HttpStatusCode.OK, "Layout items data", layoutItemDetails);
            }
            catch(Exception e)
            {
                return HttpResponse((int)HttpStatusCode.InternalServerError, "Validation error","");
            }
        }

        [HttpGet]
        [Route("layout/items/list")]
        public async Task<dynamic> LayoutItemsIndex()
        {
            try
            {
                var layoutItemDetails = _layoutService.GetLayout_Item_Index_Details();
                //var layoutItemDetails =  _foodmanduDbContext.LayoutItems.Where(x => x.layoutId == id).ToList();
                return HttpResponse((int)HttpStatusCode.OK, "Layout items data", layoutItemDetails);
            }
            catch(Exception e)
            {
                return HttpResponse((int)HttpStatusCode.InternalServerError, "Validation error","");
            }
        }

        [HttpPost]
        [Route("layout/items/new")]
        public async Task<dynamic> New([FromBody] LayoutItems model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //if (model.imagefile != null)
                    //{
                    //    model.image = _fileServices.Save("Image", model.imagefile);

                    //}
                    //if (model.logoFile != null)
                    //{
                    //    model.logo = _fileServices.Save("Image", model.logoFile);

                    //}

                    _foodmanduDbContext.LayoutItems.Add(model);
                    await _foodmanduDbContext.SaveChangesAsync();
                    return HttpResponse((int)HttpStatusCode.OK, "LayoutItem Added Successfully", model);

                }
                return HttpResponse((int)HttpStatusCode.InternalServerError, "Validation Error!", "");

            }
            catch (Exception e)
            {
                return HttpResponse((int)HttpStatusCode.InternalServerError, "Validataadsasdion Error!", "");
            }
        }
 

        [HttpPost]
        [Route("layout/items/edit")]
        public async Task<dynamic> Edit(LayoutItems model)
        {
            if (ModelState.IsValid)
            {
                //if (model.imagefile != null)
                //{
                //    model.image = _fileServices.Save("Image", model.imagefile);

                //}
                //if (model.logoFile != null)
                //{
                //    model.logo = _fileServices.Save("Image", model.logoFile);

                //}
                _foodmanduDbContext.LayoutItems.Update(model);
                await _foodmanduDbContext.SaveChangesAsync();
                return HttpResponse((int)HttpStatusCode.OK, "LayoutItem Updated Successfully", model);

            }
            return HttpResponse((int)HttpStatusCode.InternalServerError, "Validation Error!", "");
        }


        [HttpPost]
        [Route("layout/items/delete")]
        public async Task<dynamic> Delete(int layoutItemId)
        {
            if (ModelState.IsValid)
            {
                var layout = await _foodmanduDbContext.LayoutItems.FindAsync(layoutItemId);
                if (layout != null)
                {
                    _foodmanduDbContext.LayoutItems.Remove(layout);
                    await _foodmanduDbContext.SaveChangesAsync();
                    return HttpResponse((int)HttpStatusCode.OK, "Layout Items Delete Successfully", layout);
                }
                else
                {
                    return HttpResponse((int)HttpStatusCode.OK, "Layout Items Not Found", layout);
                }
            }
            return StatusCode((int)HttpStatusCode.InternalServerError, new { Message = "Validation Error!" });
        }

        private async Task<object> HttpResponse(int statusCode, string msg, object data)
        {
            return new
            {
                Code = statusCode,
                Message = msg,
                Data = data
            };
        }


    }
}
