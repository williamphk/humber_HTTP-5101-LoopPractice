using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LoopPracticeWeek5.Controllers
{
    public class LoopController : ApiController
    {
        /// <summary>
        /// Counts from 1 to 10
        /// </summary>
        /// <returns>0123456789</returns>
        [HttpGet]
        [Route("api/Loop/ForLoopTest")]
        public string ForLoopTest()
        {
            string message = "";
            for(int incrementor = 0; incrementor < 10; incrementor = incrementor + 1)
            {
                message = message + incrementor;
            }
            return message;
        }
        /// <summary>
        /// Counts from 5 to 20
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/Loop/ForLoopTest2")]
        public string ForLoopTest2()
        {
            string message = "";
            for (int incrementor = 5; incrementor <= 20; incrementor = incrementor + 1)
            {
                message = message + incrementor;
            }
            return message;
        }
        /// <summary>
        /// Counts from 10 to 13
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/Loop/ForLoopTest3")]
        public string ForLoopTest3()
        {
            string message = "";
            for (int incrementor = 10; incrementor <= 13; incrementor = incrementor + 1)
            {
                message = message + incrementor;
            }
            return message;
        }
        /// <summary>
        /// Counts from 20 to 0
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/Loop/ForLoopTest4")]
        public string ForLoopTest4()
        {
            string message = "";
            for (int incrementor = 20; incrementor >= 0; incrementor = incrementor - 1)
            {
                message = message + incrementor;
            }
            return message;
        }
        /// <summary>
        /// Counts from 0 to 10 by 2s (0,2,4,6,..)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/Loop/ForLoopTest5")]
        public string ForLoopTest5()
        {
            string message = "";
            for (int i = 0; i <= 10; i+=2)
            {
                message = message + i;
            }
            return message;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/Loop/WhileLoopTest")]
        public string WhileLoopTest()
        {
            string message = "";
            string delimiter = ", ";
            int i = 0;
            int ceiling = 9;
            while (i <= ceiling)
            {
                if (i == ceiling)
                {
                    delimiter = "";
                }
                message = message + i + delimiter;
                i = i + 1;
            }
            return message;
        }
        /// <summary>
        /// output a list of favorite shows
        /// </summary>
        /// <returns>
        /// here are my favourite shows:
        /// 1. house of dragon
        /// 2. dragon ball
        /// 3. bobs burgers
        /// </returns>
        [HttpGet]
        [Route("api/Loop/ForEachLoopTest")]
        public string ForEachLoopTest()
        {
            string output = "";
            List<string> shows = new List<string>() {"house of dragon", "dragon ball", "bobs burgers"};
            foreach(string show in shows)
            {
                output += show;
            }
            return output;
        }
    }
}
