using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TM470.Pages
{
    public class userListsModel : PageModel
    {
        public string title;
        public string type;
        public void OnGet()
        {
            setPageVariables();
        }



        private void setPageVariables()
        {
            type = Request.Query["type"];
            if (string.IsNullOrEmpty(type))
            {
                type = "list";
            }

            title = type.Equals("list") ? "List of beers you have tried" : "List of beers you have left to try";
        }
    }
}