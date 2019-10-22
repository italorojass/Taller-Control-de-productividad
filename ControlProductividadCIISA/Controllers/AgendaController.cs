using ControlProductividadCIISA.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlProductividadCIISA.Controllers
{
    public class AgendaController : Controller
    {
        // GET: Agenda
        public ActionResult Index()
        {
            string name = DateTimeFormatInfo.CurrentInfo.GetMonthName(1);

            List<string> nAmedates = new List<string>();
            Dictionary<int, int> mesdia = new Dictionary<int, int>();

            string[] names = DateTimeFormatInfo.CurrentInfo.MonthNames; //nombre de los meses


            var clear = names.Count() - 1; //cantidad de nombres de los meses - 1 = 12.
            ViewBag.CantidadMeses = clear;

            var yearnow = DateTime.Now.Year;
            var monthnow = DateTime.Now.Month;

            ViewBag.WeekNow = monthnow;

            ViewBag.yearNow = yearnow;
            ViewBag.DayNow = DateTime.Now.Day;

            for (int i = 1; i <= clear; i++)//12 
            {
                var diasdelmes = DateTime.DaysInMonth(yearnow, i);
                mesdia.Add(i, diasdelmes);
                nAmedates.Add(DateTimeFormatInfo.CurrentInfo.GetMonthName(i));
            }

            ViewData["dict"] = mesdia;
            ViewBag.Meses = nAmedates;//le paso el nombre de los dias

            List<ListaActividades> ListActividades = new List<ListaActividades>();
            var newdate = DateTime.Now;//05 / 29 / 2015 5:50 AM
            var newdate2 = DateTime.Now.AddDays(-6);//05 / 29 / 2015 5:50 AM
            ListActividades.Add(new ListaActividades { NombreActividad = "Llamar a cliente", EstadoActividad = 0, HoraActividad = newdate });
            ListActividades.Add(new ListaActividades { NombreActividad = "Cancelar a cliente", EstadoActividad = 0, HoraActividad = newdate2 });
            ListActividades.Add(new ListaActividades { NombreActividad = "Ver al jefe", EstadoActividad = 1, HoraActividad = newdate2.AddMonths(2) });
            ListActividades.Add(new ListaActividades { NombreActividad = "Colacion", EstadoActividad = 1, HoraActividad = newdate2.AddDays(-9) });

            return View(ListActividades);
        }

        public ActionResult CalendarPerYear(int? yearnow1)
        {
            string name = DateTimeFormatInfo.CurrentInfo.GetMonthName(1);

            List<string> nAmedates = new List<string>();
            Dictionary<int, int> mesdia = new Dictionary<int, int>();

            string[] names = DateTimeFormatInfo.CurrentInfo.MonthNames; //nombre de los meses


            var clear = names.Count() - 1; //cantidad de nombres de los meses - 1 = 12.
            ViewBag.CantidadMeses = clear;

            var yearnow = DateTime.Now.Year;
            var monthnow = DateTime.Now.Month;

            ViewBag.yearNow = yearnow;

            for (int i = 1; i <= clear; i++)//12 
            {
                var diasdelmes = DateTime.DaysInMonth(yearnow, i);
                mesdia.Add(i, diasdelmes);
                nAmedates.Add(DateTimeFormatInfo.CurrentInfo.GetMonthName(i));
            }

            ViewData["dict"] = mesdia;
            ViewBag.Meses = nAmedates;//le paso el nombre de los dias

            List<ListaActividades> ListActividades = new List<ListaActividades>();
            var newdate = DateTime.Now;//05 / 29 / 2015 5:50 AM
            var newdate2 = DateTime.Now.AddDays(-6);//05 / 29 / 2015 5:50 AM
            ListActividades.Add(new ListaActividades { NombreActividad = "Llamar a cliente", EstadoActividad = 0, HoraActividad = newdate });
            ListActividades.Add(new ListaActividades { NombreActividad = "Cancelar a cliente", EstadoActividad = 0, HoraActividad = newdate2 });
            ListActividades.Add(new ListaActividades { NombreActividad = "Ver al jefe", EstadoActividad = 1, HoraActividad = newdate2.AddMonths(2) });
            ListActividades.Add(new ListaActividades { NombreActividad = "Colacion", EstadoActividad = 1, HoraActividad = newdate2.AddDays(-9) });

            return PartialView(ListActividades);
        }

        [HttpPost]
        public ActionResult NextYear(int yearnow, int contador)
        {


            //string name = DateTimeFormatInfo.CurrentInfo.GetMonthName(1);
            var theyear = DateTime.Today.AddYears(contador);

            List<string> nAmedates = new List<string>();
            Dictionary<int, int> mesdia = new Dictionary<int, int>();

            string[] names = DateTimeFormatInfo.CurrentInfo.MonthNames; //nombre de los meses


            var clear = names.Count() - 1; //cantidad de nombres de los meses - 1 = 12.
            ViewBag.CantidadMeses = clear;

            //var yearnow = DateTime.Now.Year;
            //var monthnow = DateTime.Now.AddYears(1).Month;

            ViewBag.yearNow = yearnow;

            for (int i = 1; i <= clear; i++)//12 
            {
                var diasdelmes = DateTime.DaysInMonth(theyear.Year, i);
                mesdia.Add(i, diasdelmes);
                nAmedates.Add(DateTimeFormatInfo.CurrentInfo.GetMonthName(i));
            }

            ViewData["dict"] = mesdia;
            ViewBag.Meses = nAmedates;//le paso el nombre de los dias

            
            var yearnowNext = theyear.Year;

            ViewBag.theyear = theyear;

            List<ListaActividades> ListActividades = new List<ListaActividades>();
            var newdate = DateTime.Now.AddYears(1);//05 / 29 / 2015 5:50 AM
            var newdate2 = DateTime.Now.AddDays(-6).AddYears(1);//05 / 29 / 2015 5:50 AM
            ListActividades.Add(new ListaActividades { NombreActividad = "Llamar a cliente", EstadoActividad = 0, HoraActividad = newdate.AddDays(-8) });
            ListActividades.Add(new ListaActividades { NombreActividad = "Cancelar a cliente", EstadoActividad = 0, HoraActividad = newdate2.AddHours(3) });
            ListActividades.Add(new ListaActividades { NombreActividad = "Ver al jefe", EstadoActividad = 1, HoraActividad = newdate2.AddMonths(-2) });
            ListActividades.Add(new ListaActividades { NombreActividad = "Colacion", EstadoActividad = 1, HoraActividad = newdate2.AddDays(-2) });

            return Json(new
            {
                Html = RenderRazorViewToString(ControllerContext, "NextYear", ListActividades),
                Mes = yearnowNext
            });
          //  return PartialView(ListActividades);
        }

        [HttpPost]
        public ActionResult AfterYear(int yearnow, int contador)
        {
            //var dt = DateTime.Today.AddYears(-1);
            //string name = DateTimeFormatInfo.CurrentInfo.GetMonthName(1);
            var theyear = DateTime.Today.AddYears(-contador);

            List<string> nAmedates = new List<string>();
            Dictionary<int, int> mesdia = new Dictionary<int, int>();

            string[] names = DateTimeFormatInfo.CurrentInfo.MonthNames; //nombre de los meses


            var clear = names.Count() - 1; //cantidad de nombres de los meses - 1 = 12.
            ViewBag.CantidadMeses = clear;

            //var yearnow = DateTime.Now.Year;
            //var monthnow = DateTime.Now.AddYears(1).Month;

            //ViewBag.yearNow = yearnow;

            for (int i = 1; i <= clear; i++)//12 
            {
                var diasdelmes = DateTime.DaysInMonth(theyear.Year, i);
                mesdia.Add(i, diasdelmes);
                nAmedates.Add(DateTimeFormatInfo.CurrentInfo.GetMonthName(i));
            }

            ViewData["dict"] = mesdia;
            ViewBag.Meses = nAmedates;//le paso el nombre de los dias


            var yearnowNext = theyear.Year;

            ViewBag.theyear = theyear;

            List<ListaActividades> ListActividades = new List<ListaActividades>();
            var newdate = DateTime.Now.AddYears(-1);//05 / 29 / 2015 5:50 AM
            var newdate2 = DateTime.Now.AddDays(-6).AddYears(-1);//05 / 29 / 2015 5:50 AM
            ListActividades.Add(new ListaActividades { NombreActividad = "Llamar a cliente", EstadoActividad = 0, HoraActividad = newdate.AddHours(4) });
            ListActividades.Add(new ListaActividades { NombreActividad = "Cancelar a cliente", EstadoActividad = 0, HoraActividad = newdate2.AddDays(3) });
            ListActividades.Add(new ListaActividades { NombreActividad = "Ver al jefe", EstadoActividad = 1, HoraActividad = newdate2.AddMonths(5) });
            ListActividades.Add(new ListaActividades { NombreActividad = "Colacion", EstadoActividad = 1, HoraActividad = newdate2.AddDays(-1) });
            return Json(new
            {
                Html = RenderRazorViewToString(ControllerContext, "AfterYear", ListActividades),
                Mes = yearnowNext
            });
            //return PartialView();
        }

        [HttpPost]
        public ActionResult CalendarPerMonth(int? year)
        {
            var meshoy1 = new DateTime(year.Value,DateTime.Today.Month,DateTime.Today.Day);
            var meshoy = meshoy1.Month;

            var diasdelmes = DateTime.DaysInMonth(year.Value, meshoy);

            List<ListaActividades> ListActividades = new List<ListaActividades>();
            var newdate = DateTime.Now;//05 / 29 / 2015 5:50 AM
            var newdate2 = DateTime.Now.AddDays(-6);//05 / 29 / 2015 5:50 AM
            ListActividades.Add(new ListaActividades { NombreActividad = "Llamar a cliente", EstadoActividad = 0, HoraActividad = newdate });
            ListActividades.Add(new ListaActividades { NombreActividad = "Cancelar a cliente", EstadoActividad = 0, HoraActividad = newdate2 });
            ListActividades.Add(new ListaActividades { NombreActividad = "Ver al jefe", EstadoActividad = 1, HoraActividad = newdate2.AddMonths(2) });
            ListActividades.Add(new ListaActividades { NombreActividad = "Colacion", EstadoActividad = 1, HoraActividad = newdate2.AddDays(-9) });

            ViewBag.DiasMes = diasdelmes;

            ViewBag.WeekNow = meshoy;

            var NombreMes = DateTimeFormatInfo.CurrentInfo.GetMonthName(meshoy);

            var getabreviado = NombreMes.Substring(0, 1).ToUpper() + NombreMes.Substring(1, 2);

            ViewData["NombreMesActual"] = NombreMes;
            return Json(new
            {
                Html = RenderRazorViewToString(ControllerContext, "CalendarPerMonth", ListActividades),
                Mes = getabreviado
            });
            //return PartialView(ListActividades);
        }

        [HttpPost]
        public ActionResult CalendarPerWeek(int month)
        {
            DateTime today = new DateTime(DateTime.Today.Year,month,DateTime.Today.Day);
            
            var NombreMes = DateTimeFormatInfo.CurrentInfo.GetMonthName(month);
            var getabreviado = NombreMes.Substring(0, 1).ToUpper() + NombreMes.Substring(1, 2);
            ViewBag.NombreMesCorto = getabreviado;
            CultureInfo cul = CultureInfo.CurrentCulture;

            var firstDayWeek = cul.Calendar.GetWeekOfYear(
             today,
             CalendarWeekRule.FirstDay,
             DayOfWeek.Monday);

            int weekNum = cul.Calendar.GetWeekOfYear(
                today,
                CalendarWeekRule.FirstDay,
                DayOfWeek.Monday);
            //var ultimodia = LastDayOfWeek(today);//debe ser 3 de marzo
            //int numeroSem = System.Globalization.CultureInfo.CurrentUICulture.Calendar.GetWeekOfYear(today, CalendarWeekRule.FirstDay, today.DayOfWeek);
            var primerLunes = FirstDateOfWeek(today.Year, weekNum, CultureInfo.CurrentCulture);//debe ser 25 feb
            var LastDayWeek = primerLunes.AddDays(6);

            List<DateTime> listweekdays = new List<DateTime>();
            listweekdays.Add(primerLunes);
            listweekdays.Add(primerLunes.AddDays(1));
            listweekdays.Add(primerLunes.AddDays(2));
            listweekdays.Add(primerLunes.AddDays(3));
            listweekdays.Add(primerLunes.AddDays(4));
            listweekdays.Add(primerLunes.AddDays(5));
            listweekdays.Add(primerLunes.AddDays(6));

            ViewBag.ListDaysOfWeek = listweekdays;


            List<ListaActividades> ListActividades = new List<ListaActividades>();
            var newdate = DateTime.Now;//05 / 29 / 2015 5:50 AM
            var newdate2 = DateTime.Now.AddDays(-6);//05 / 29 / 2015 5:50 AM
            ListActividades.Add(new ListaActividades { NombreActividad = "Llamar a cliente", EstadoActividad = 0, HoraActividad = newdate });
            ListActividades.Add(new ListaActividades { NombreActividad = "Cancelar a cliente", EstadoActividad = 0, HoraActividad = newdate2 });
            ListActividades.Add(new ListaActividades { NombreActividad = "Ver al jefe", EstadoActividad = 1, HoraActividad = newdate2.AddMonths(2) });
            ListActividades.Add(new ListaActividades { NombreActividad = "Colacion", EstadoActividad = 1, HoraActividad = newdate2.AddDays(-9) });

            
            var semana = "Semana: " + weekNum;
            
            List<string> DaysInSpanish = new List<string>();
            
            int count = 0;
            DaysInSpanish.Add(DateTimeFormatInfo.CurrentInfo.GetDayName(DayOfWeek.Monday));
            DaysInSpanish.Add(DateTimeFormatInfo.CurrentInfo.GetDayName(DayOfWeek.Tuesday));
            DaysInSpanish.Add(DateTimeFormatInfo.CurrentInfo.GetDayName(DayOfWeek.Wednesday));
            DaysInSpanish.Add(DateTimeFormatInfo.CurrentInfo.GetDayName(DayOfWeek.Thursday));
            DaysInSpanish.Add(DateTimeFormatInfo.CurrentInfo.GetDayName(DayOfWeek.Friday));
            DaysInSpanish.Add(DateTimeFormatInfo.CurrentInfo.GetDayName(DayOfWeek.Saturday));
            DaysInSpanish.Add(DateTimeFormatInfo.CurrentInfo.GetDayName(DayOfWeek.Sunday));

            List<string> dayabreviado = new List<string>();

            foreach (var i in DaysInSpanish)
            {
                count++;
                //var getabreviado = i.Substring(0, 1).ToUpper() + i.Substring(1, 2);

                dayabreviado.Add(i.Substring(0, 1).ToUpper() + i.Substring(1));
            }

            ViewBag.DiasAbreviados = dayabreviado;

            return Json(new
            {
                Html = RenderRazorViewToString(ControllerContext, "CalendarPerWeek", ListActividades),
                Mes = semana
            });
            //return PartialView(ListActividades);
        }

        [HttpPost]
        public ActionResult CalendarPerDay()
        {
            List<ListaActividades> ListActividades = new List<ListaActividades>();
            var newdate = DateTime.Now.AddHours(-4);//05 / 29 / 2015 5:50 AM
            var newdate2 = DateTime.Now.AddDays(-6);//05 / 29 / 2015 5:50 AM
            ListActividades.Add(new ListaActividades { NombreActividad = "Llamar a cliente", EstadoActividad = 0, HoraActividad = newdate });
            ListActividades.Add(new ListaActividades { NombreActividad = "Cancelar a cliente", EstadoActividad = 0, HoraActividad = newdate2 });
            ListActividades.Add(new ListaActividades { NombreActividad = "Ver al jefe", EstadoActividad = 1, HoraActividad = newdate2.AddMonths(2) });
            ListActividades.Add(new ListaActividades { NombreActividad = "Colacion", EstadoActividad = 1, HoraActividad = newdate2.AddDays(-9) });

            var getdiahoy = DateTime.Today.ToString("dd/MM/yyyy");

            ViewBag.Diahoy = DateTime.Today.Day;

            return Json(new
            {
                Html = RenderRazorViewToString(ControllerContext, "CalendarPerDay", ListActividades),
                Mes = getdiahoy
            });
            //return PartialView();
        }
        
        public static DateTime FirstDateOfWeek(int year, int weekOfYear, System.Globalization.CultureInfo ci)
        {
            DateTime jan1 = new DateTime(year, 1, 1);
            int daysOffset = (int)ci.DateTimeFormat.FirstDayOfWeek - (int)jan1.DayOfWeek;
            DateTime firstWeekDay = jan1.AddDays(daysOffset);
            int firstWeek = ci.Calendar.GetWeekOfYear(jan1, ci.DateTimeFormat.CalendarWeekRule, ci.DateTimeFormat.FirstDayOfWeek);
            if ((firstWeek <= 1 || firstWeek >= 52) && daysOffset >= -3)
            {
                weekOfYear -= 1;
            }
            return firstWeekDay.AddDays(weekOfYear * 7);
        }



        public string RenderRazorViewToString(ControllerContext controllerContext, string viewName, object model)
        {
            controllerContext.Controller.ViewData.Model = model;
            // ViewData.Clear();
            using (var sw = new StringWriter())
            {
                var ViewResult = ViewEngines.Engines.FindPartialView(controllerContext, viewName);
                var ViewContext = new ViewContext(controllerContext, ViewResult.View, controllerContext.Controller.ViewData, controllerContext.Controller.TempData, sw);
                ViewResult.View.Render(ViewContext, sw);
                ViewResult.ViewEngine.ReleaseView(controllerContext, ViewResult.View);
                return sw.GetStringBuilder().ToString();
            }
        }


    }
}