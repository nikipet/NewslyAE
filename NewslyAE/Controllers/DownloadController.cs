using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using NewslyAE.Models;
using NewsAPI.Models;
using NewslyAE.Models.DTOs;

namespace NewslyAE.Controllers
{
    public class DownloadController : Controller
    {
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ExportTopArticlesToExcel(TopArticlesWrapper topArticlesWrapper)
        {
            var content = getExcel(topArticlesWrapper.Result);
            return File(content,
                "application/vnd.openxmlformats-officedocument.spreedsheetml.sheet",
                "Articles.xlsx");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ExportEverythingToExcel(EverythingWrapper everythingWrapper)
        {
            var content = getExcel(everythingWrapper.Result);
            return File(content,
                "application/vnd.openxmlformats-officedocument.spreedsheetml.sheet",
                "Articles.xlsx");
        }
        private byte[] getExcel(ArticlesResult result)
        {
            using var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("SearchResults");
            var currentRow = 1;
            var currentColumn = 1;
            worksheet.Cell(currentRow, currentColumn++).Value = "Article Number";
            worksheet.Cell(currentRow, currentColumn++).Value = "Article Source ID";
            worksheet.Cell(currentRow, currentColumn++).Value = "Article Source Name";
            worksheet.Cell(currentRow, currentColumn++).Value = "Article Title";
            worksheet.Cell(currentRow, currentColumn++).Value = "Article Author";
            worksheet.Cell(currentRow, currentColumn++).Value = "Article Description";
            worksheet.Cell(currentRow, currentColumn++).Value = "Link to Full Article";

            foreach (var article in result.Articles)
            {
                currentRow++;
                currentColumn = 1;
                worksheet.Cell(currentRow, currentColumn++).Value = currentRow-1;
                worksheet.Cell(currentRow, currentColumn++).Value = article.Source.Id;
                worksheet.Cell(currentRow, currentColumn++).Value = article.Source.Name;
                worksheet.Cell(currentRow, currentColumn++).Value = article.Title;
                worksheet.Cell(currentRow, currentColumn++).Value = article.Author;
                worksheet.Cell(currentRow, currentColumn++).Value = article.Description;
                worksheet.Cell(currentRow, currentColumn++).Value = article.Url;
            }
            using var stream = new MemoryStream();
            workbook.SaveAs(stream);
            return stream.ToArray();
        }
    }
}
