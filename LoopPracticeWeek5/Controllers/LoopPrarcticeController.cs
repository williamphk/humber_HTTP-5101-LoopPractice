using Microsoft.Ajax.Utilities;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Caching;
using System.Web.Http;

namespace LoopPracticeWeek5.Controllers
{
    public class LoopPrarcticeController : ApiController
    {
        [HttpGet]
        [Route("api/LoopPractice/Counter/{start}/{limit}/{step}")]
        public List<int> Counter(int start, int limit, int step)
        {
            bool isIncreasing = (start < limit) && (step > 0);
            bool isDecreasing = (start > limit) && (step < 0);

            List<int> result = new List<int>();

            //prevent an invalid loop.
            if (!isIncreasing && !isDecreasing)
            {
                result.Add(0);
            }
            else
            {
                if(isIncreasing)
                {
                    for (int i = start; i <= limit; i += step)
                    {
                        result.Add(i);
                    }
                }
                else
                {
                    for (int i = start; i >= limit; i += step)
                    {
                        result.Add(i);
                    }
                }
            }
            return result;
        }

        [Route("api/LoopPractice/FizzyBuzzy/{start}/{limit}/{step}/{Fizzy}/{Buzzy}")]
        [HttpGet]
        public string FizzyBuzzy(int start, int limit, int step, int Fizzy, int Buzzy)
        {
            List<int> results = Counter(start, limit, step);
            List<string> resultsInString = new List<string>();
            string message = "";
            //prevent an invalid loop.
            if (results.Count() == 1 && results[0] == 0)
            {
                message = "0";
            }
            else
            {
                for (int i = 0; i < results.Count(); i++)
                {
                    bool isFizzy = (results[i] % Fizzy) == 0;
                    bool isBuzzy = (results[i] % Buzzy) == 0;
                    if (isFizzy && isBuzzy) message += "FizzyBuzzy,";
                    else if (isFizzy) message += "Fizzy,";
                    else if (isBuzzy) message += "Buzzy,";
                    else message += results[i].ToString() + ",";
                }
                message = message.Trim(new char[] { ',' });
            }
            return message;
        }
        [Route("api/LoopPractice/GetChange/{amount}")]
        public List<string> GetChange(decimal amount)
        {
            List<string> denominations = new List<string>();
            decimal twentyValue = 20.00M;
            int twenties = 0;
            decimal tenValue = 10.00M;
            int tens = 0;
            decimal fiveValue = 5.00M;
            int fives = 0;
            decimal toonieValue = 2.00M;
            int toonies = 0;
            decimal loonieValue = 1.00M;
            int loonies = 0;
            decimal quarterValue = 0.25M;
            int quarters = 0;
            decimal dimeValue = 0.10M;
            int dimes = 0;
            decimal nickelValue = 0.05M;
            int nickels = 0;
            decimal pennyValue = 0.01M;
            int pennies = 0;

            twenties = Convert.ToInt32(Math.Floor(amount / twentyValue));
            amount -= twenties * twentyValue;
            tens = Convert.ToInt32(Math.Floor(amount / tenValue));
            amount -= tens * tenValue;
            fives = Convert.ToInt32(Math.Floor(amount / fiveValue));
            amount -= fives * fiveValue;
            toonies = Convert.ToInt32(Math.Floor(amount / toonieValue));
            amount -= toonies * toonieValue;
            loonies = Convert.ToInt32(Math.Floor(amount / loonieValue));
            amount -= loonies * loonieValue;
            quarters = Convert.ToInt32(Math.Floor(amount / quarterValue));
            amount -= quarters * quarterValue;
            dimes = Convert.ToInt32(Math.Floor(amount / dimeValue));
            amount -= dimes * dimeValue;
            nickels = Convert.ToInt32(Math.Floor(amount / nickelValue));
            amount -= nickels * nickelValue;
            pennies = Convert.ToInt32(Math.Floor(amount / pennyValue));

            if (twenties > 0) denominations.Add("Twenties : " + twenties);
            if (tens > 0) denominations.Add("Tens : " + tens);
            if (fives > 0) denominations.Add("Fives : " + fives);
            if (toonies > 0) denominations.Add("Toonies : " + toonies);
            if (loonies > 0) denominations.Add("Loonies : " + loonies);
            if (quarters > 0) denominations.Add("Quarters : " + quarters);
            if (nickels > 0) denominations.Add("Nickels : " + nickels);
            if (dimes > 0) denominations.Add("Dimes : " + dimes);
            if (pennies > 0) denominations.Add("Pennies : " + pennies);
            return denominations;
        }
        [Route("api/LoopPractice/ChessBoard")]
        [HttpGet]
        public string ChessBoard()
        {
            string output = "";
            for (int i = 1; i < 9; i++)
            {
                if (i % 2 == 0)
                {
                    for (int j = 1; j < 9; j++)
                    {
                        if (j % 2 == 0)
                        {
                            char c = Convert.ToChar(j + 64);
                            output += "("  + c + i.ToString() + ":dark),";
                        }
                        else
                        {
                            char c = Convert.ToChar(j + 64);
                            output += "(" + c + i.ToString() + ":light),";
                        }
                    }
                }
                else
                {
                    for (int j = 1; j < 9; j++)
                    {
                        if (j % 2 == 0)
                        {
                            char c = Convert.ToChar(j + 64);
                            output += "(" + c + i.ToString() + ":light),";
                        }
                        else
                        {
                            char c = Convert.ToChar(j + 64);
                            output += "(" + c + i.ToString() + ":dark),";
                        }
                    }
                }
             output = output.Trim(new char[] { ',' });
            }
            return output;
        }
    }
}
