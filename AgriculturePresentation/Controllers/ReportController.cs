using AgriculturePresentation.Models;
using ClosedXML.Excel;
using DataAccessLayer.Contexts;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;

namespace AgriculturePresentation.Controllers
{
    public class ReportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult StaticReport()
        {
            ExcelPackage excelPackage = new ExcelPackage();

            var workBook = excelPackage.Workbook.Worksheets.Add("Dosya1");

            workBook.Cells[1, 1].Value = "Ürün Adı";
            workBook.Cells[1, 2].Value = "Ürün Kategorisi";
            workBook.Cells[1, 3].Value = "Ürün Stok";

            workBook.Cells[2, 1].Value = "Mercimek";
            workBook.Cells[2, 2].Value = "Bakliyat";
            workBook.Cells[2, 3].Value = "785 Kg";

            workBook.Cells[3, 1].Value = "Buğday";
            workBook.Cells[3, 2].Value = "Bakliyat";
            workBook.Cells[3, 3].Value = "1.2 Ton";

            var bytes = excelPackage.GetAsByteArray();

            return File(bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "BakliyatRaporu.xlsx");
        }

        public List<ContactViewModel> ContactList()
        {
            List<ContactViewModel> contactModels = new List<ContactViewModel>();

            using (var context = new AgricultureContext())
            {
                contactModels = context.Contacts.Select(x => new ContactViewModel
                {

                    ContactID = x.ContactID,
                    ContactName = x.ContactName,
                    ContactMail = x.ContactMail,
                    ContactMessage = x.ContactMessage,
                    ContactDate = x.ContactDate,

                }).ToList();
            }

            return contactModels;
        }

        public IActionResult ContactReport()
        {
            using (var workBook = new XLWorkbook())
            {
                var workSheet = workBook.Worksheets.Add("Mesaj Listesi");

                workSheet.Cell(1, 1).Value = "Mesaj ID";
                workSheet.Cell(1, 2).Value = "Mesajı Gönderen";
                workSheet.Cell(1, 3).Value = "Mail Adresi";
                workSheet.Cell(1, 4).Value = "Mesaj İçeriği";
                workSheet.Cell(1, 5).Value = "Tarih";

                int contactRowCount = 2;

                foreach(var item in ContactList())
                {
                    workSheet.Cell(contactRowCount, 1).Value = item.ContactID;
                    workSheet.Cell(contactRowCount, 2).Value = item.ContactName;
                    workSheet.Cell(contactRowCount, 3).Value = item.ContactMail;
                    workSheet.Cell(contactRowCount, 4).Value = item.ContactMessage;
                    workSheet.Cell(contactRowCount, 5).Value = item.ContactDate;

                    contactRowCount++;
                }

                using (var stream = new MemoryStream())
                {
                    workBook.SaveAs(stream);
                    
                    var content = stream.ToArray();

                    Guid guid = Guid.NewGuid();
                    var filename = guid.ToString(); //Rastgele karakterler ile isim oluşturma.

                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"{filename}.xlsx");
                }
            }
        }

        public List<AnnouncementViewModel> AnnouncementList()
        {
            List<AnnouncementViewModel> announcementModels = new List<AnnouncementViewModel>();

            using (var context = new AgricultureContext())
            {
                announcementModels = context.Announcements.Select(x => new AnnouncementViewModel
                {

                    AnnouncementID = x.AnnouncementID,
                    AnnouncementTitle = x.AnnouncementTitle,
                    AnnouncementDescription = x.AnnouncementDescription,
                    AnnouncementDate = x.AnnouncementDate,
                    AnnouncementStatus = x.AnnouncementStatus,

                }).ToList();
            }

            return announcementModels;
        }

        public IActionResult AnnouncementReport()
        {
            using (var workBook = new XLWorkbook())
            {
                var workSheet = workBook.Worksheets.Add("Duyuru Listesi");

                workSheet.Cell(1, 1).Value = "Duyuru ID";
                workSheet.Cell(1, 2).Value = "Duyuru Başlığı";
                workSheet.Cell(1, 3).Value = "Açıklama";
                workSheet.Cell(1, 4).Value = "Tarih";
                workSheet.Cell(1, 5).Value = "Durum";

                int announcementRowCount = 2;

                foreach (var item in AnnouncementList())
                {
                    workSheet.Cell(announcementRowCount, 1).Value = item.AnnouncementID;
                    workSheet.Cell(announcementRowCount, 2).Value = item.AnnouncementTitle;
                    workSheet.Cell(announcementRowCount, 3).Value = item.AnnouncementDescription;
                    workSheet.Cell(announcementRowCount, 4).Value = item.AnnouncementDate;
                    workSheet.Cell(announcementRowCount, 5).Value = item.AnnouncementStatus;

                    announcementRowCount++;
                }

                using (var stream = new MemoryStream())
                {
                    workBook.SaveAs(stream);

                    var content = stream.ToArray();

                    Guid guid = Guid.NewGuid();
                    var filename = guid.ToString(); //Rastgele karakterler ile isim oluşturma.

                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"{filename}.xlsx");
                }
            }
        }
    }
}
