using AzureWebApp.Data.Storage.Interfaces;
using AzureWebApp.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AzureWebApp.Controllers
{
    public class FileController : Controller
    {
        private readonly IBlobStorage _blobService;

        public FileController(IBlobStorage blobService)
        {
            _blobService = blobService;
        }

        public IActionResult Create()
        {
            return View(new BlobVM());
        }

        [HttpPost]
        public async Task<IActionResult> Create(BlobVM model)
        {
            if (ModelState.IsValid)
            {
                await _blobService.UploadFileAsync(model);
                return Ok();
            }
            
            return View(model);
        }
    }
}
