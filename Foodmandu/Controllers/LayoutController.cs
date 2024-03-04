using Foodmandu.Model;
using Foodmandu.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Foodmandu.Controllers
{ 
    [Route("api")]
    [ApiController]
    [EnableCors("AllowAnyOrigin")]
    public class LayoutController : ControllerBase
    {
        private readonly FoodmanduDbContext _foodmanduDbContext;
        private readonly ILayoutService _layoutService;

        public LayoutController(FoodmanduDbContext foodmanduDbContext,ILayoutService layoutService)
        {
            _foodmanduDbContext = foodmanduDbContext;
            _layoutService = layoutService;
        }

        [HttpGet]
        [Route("layout")]
        public async Task<dynamic> Layout()
        {
            try
            {
                // var layoutDetails=_layoutService.GetLayoutDetails();
                var layoutDetails = _foodmanduDbContext.Layouts.ToList();
                return HttpResponse((int)HttpStatusCode.OK, "Layout data", layoutDetails);
            }
            catch(Exception ex)
            {
                return HttpResponse((int)HttpStatusCode.OK, "Validation Error!","");

            }
        }
         

        [HttpGet]
        [Route("layout/edit/get")]
        public async Task<dynamic> EditGet(int layoutId)
        {
            if (ModelState.IsValid)
            {
                var layoutdetails = _foodmanduDbContext.Layouts.Where(x => x.layoutId == layoutId).FirstOrDefault();
                return HttpResponse((int)HttpStatusCode.OK, "Layout Data", layoutdetails);

            }
            return HttpResponse((int)HttpStatusCode.InternalServerError, "Validation Error!","");
        }

        [HttpPost]
        [Route("layout/new")]
        public async Task<dynamic> New(Layouts model)
        {
            if (ModelState.IsValid)
            {

                _foodmanduDbContext.Layouts.Add(model);
                await _foodmanduDbContext.SaveChangesAsync();
                return HttpResponse((int)HttpStatusCode.OK, "Layout Added Successfully",model);

            }
            return HttpResponse((int)HttpStatusCode.InternalServerError, "Validation Error!","");
        }
         
        [HttpPost]
        [Route("layout/edit")]
        [AllowAnonymous]
        public async Task<dynamic> Edit(Layouts model)
        {
            if (ModelState.IsValid)
            {

                _foodmanduDbContext.Layouts.Update(model);
                await _foodmanduDbContext.SaveChangesAsync();
                return HttpResponse((int)HttpStatusCode.OK, "Layout Updated Successfully",model);

            }
            return HttpResponse((int)HttpStatusCode.InternalServerError, "Validation Error!","");
        }


        [HttpPost]
        [Route("layout/delete")]
        public async Task<dynamic> Delete(int layoutId)
        {
            if (ModelState.IsValid)
            {
                var layout = _foodmanduDbContext.Layouts.Where(x => x.layoutId == layoutId).FirstOrDefault();
                if (layout != null)
                {
                    _foodmanduDbContext.Layouts.Remove(layout);
                    await _foodmanduDbContext.SaveChangesAsync();
                    return HttpResponse((int)HttpStatusCode.OK, "Layout Delete Successfully", layout);
                }
                else
                {
                    return HttpResponse((int)HttpStatusCode.OK, "Layout Not Found", layout);
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
