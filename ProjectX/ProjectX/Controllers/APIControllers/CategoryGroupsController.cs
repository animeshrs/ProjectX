using ProjectX.Persistence;
using ProjectX.Services;
using ProjectX.Services.ShardServices;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Resource = ProjectX.Resources.CategoryGroup.Common;

namespace ProjectX.Controllers.APIControllers
{
    public class CategoryGroupsController : ApiController
    {
        private readonly CategoryGroupService _categoryGroupService;

        public CategoryGroupsController(ServiceFactory serviceFactory)
        {
            _categoryGroupService = serviceFactory.GetCategoryGroupService();
        }

        public async Task<IHttpActionResult> GetAllCategoryGroups()
        {
            try
            {
                var categoryGroups = await _categoryGroupService.GetAllCategoryGroups();
                return Ok(categoryGroups);
            }
            catch (HttpRequestException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public async Task<HttpResponseMessage> CreateCategoryGroup(CategoryGroup categoryGroup)
        {
            if (!ModelState.IsValid)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, Resource.InvalidModelState);

            _categoryGroupService.AddCategoryGroup(categoryGroup);
            await _categoryGroupService.SaveChangesAsync();

            return Request.CreateResponse(HttpStatusCode.OK, new { id = categoryGroup.CategoryGroupId });
        }
    }
}