using SlotMachine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;


namespace SlotMachine.Controllers
{
    public class HomeController : Controller
    {
        #region private variables

        int[] cherryPayout = { 7, 7, 7 };
        int[] AnybarPayout = { 1, 2, 3, 4, 5, 6 };
        int[] BarPayout = { 4, 5, 6 };

        int[] DoubleBarPayout = { 2, 3 };
        int[] TripleBarPayout = { 1, 1, 1 };
        int[] SevenPayout = { 0, 0, 0 };

        #endregion


        // GET: Home
        public ActionResult Index()
        {
            Session.Add("playerbalance", 100);
            Session.Add("betamount", 1);

            ViewData.Add("maintitle", System.Configuration.ConfigurationManager.AppSettings["title1"]);
            ViewData.Add("maincolor", System.Configuration.ConfigurationManager.AppSettings["color1"]);

            SlotMachineModel model = new SlotMachineModel();
            model.PlayerBalance = Convert.ToInt32(Session["playerbalance"]);
            model.SpinResult = "New Game";
            model.BetAmount = 1;

            List<HighScoreModel> hscoreList = new List<HighScoreModel>();
            model.AllHighScores = hscoreList;

            return View(model);
        }

        public ActionResult AddCredit(int addcred)
        {

            // get last bet amount
            int betamount = Convert.ToInt32(Session["betamount"]);
            SlotMachineModel model = new SlotMachineModel();

            if (addcred == 3)
                betamount = addcred;

            // add to bet until limit of 3 credits
            if (betamount < 3)
                betamount += 1;

            Session["betamount"] = betamount;

            model.BetAmount = betamount;
            model.PlayerBalance = Convert.ToInt32(Session["playerbalance"]);
            model.SpinResult = string.Empty;
            model.WinAmount = 0;

            return PartialView("SlotViewPartial", model);
        }

        public ActionResult GetFinalBalance()
        {
            return Json(new { finalbalance = Session["playerbalance"] }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult PlayGame(int[] results)
        {

            //7, 3Bar, 2Bar, 2Bar, 1Bar, 1Bar, 1Bar, Cherry, Blank, Blank, Blank, Blank, Blank, Blank, Blank, Blank, Blank

            // wait for animation to stop. maybe a better way to do this in jquery, but not sure
            Thread.Sleep(new TimeSpan(0, 0, 5));

            SlotMachineModel model = new SlotMachineModel();

            int betamount = Convert.ToInt32(Session["betamount"]);
            model.WinAmount = CheckResult(results[0], results[1], results[2], betamount);

            model.BetAmount = 1;
            Session["betamount"] = model.BetAmount;

            // if they won change message
            if (model.WinAmount > 0)
                model.SpinResult = "You Win";
            else
                model.SpinResult = "You Loose";

            // save player balance
            model.PlayerBalance = (Convert.ToInt32(Session["playerbalance"]) - betamount) + model.WinAmount;
            Session["playerbalance"] = model.PlayerBalance;

            return PartialView("SlotViewPartial", model);
        }

        public int CheckResult(int slot1, int slot2, int slot3, int betAmt)
        {
            int winAmt = 0;
            int winFactor = 0;

            switch (betAmt)
            {
                case 1:
                    winFactor = 1;
                    break;

                case 2:
                    winFactor = 2;
                    break;

                case 3:
                    winFactor = 3;
                    break;

                default:
                    winFactor = 1;
                    break;
            }

            if (cherryPayout.Contains(slot1))
                winAmt += 2;
            if (cherryPayout.Contains(slot2))
                winAmt += 2;
            if (cherryPayout.Contains(slot3))
                winAmt += 2;

            if (AnybarPayout.Contains(slot1) && AnybarPayout.Contains(slot2) && AnybarPayout.Contains(slot3))
                winAmt = 5;

            if (BarPayout.Contains(slot1) && BarPayout.Contains(slot2) && BarPayout.Contains(slot3))
                winAmt = 25;

            if (DoubleBarPayout.Contains(slot1) && DoubleBarPayout.Contains(slot2) && DoubleBarPayout.Contains(slot3))
                winAmt = 50;

            if (TripleBarPayout.Contains(slot1) && TripleBarPayout.Contains(slot2) && TripleBarPayout.Contains(slot3))
                winAmt = 100;

            if (SevenPayout.Contains(slot1) && SevenPayout.Contains(slot2) && SevenPayout.Contains(slot3))
            {
                winAmt = 300;
                // if 7 7 7 and they bet 3 credits win factor is 5
                if (winFactor == 3)
                    winFactor = 5;
            }

            return (winAmt * winFactor);

        }


    }
}