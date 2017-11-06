using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using New.Domain.Entities;
using System.Text;

namespace New.Web.Helpers
{
    public static class ListHelper
    {
        public static MvcHtmlString CreateList(this HtmlHelper html, nesting_plan p)
        {
            StringBuilder result = new StringBuilder();
            TagBuilder Div2=new TagBuilder ("div");
            Div2.MergeAttribute("style", "position:relative; width:1000px;" + " " + "height:"
                + "500px");

            TagBuilder Div1 = new TagBuilder("div");
            Div1.MergeAttribute("class", p.number.ToString());
            int max_x=0;
             int K=3;
            foreach (part_nesting y in p.list_parts_nesting)
            {
                if ((y.x+y.Length) > max_x) max_x = (y.x+y.Length);
            }

     
            if (max_x < 2000 && max_x > 1000)
            { K = 3; }
           

            int Legnth = max_x/K ;
           int Height =(int)p.width/K;
            Div1.MergeAttribute("style", "position:absolute; Top=0; Left=0; width:"+ Legnth.ToString() +"px;" + " " + "height:"
                + Height.ToString() + "px;" + " " + "border: 1px double black; background:green");
            foreach (part_nesting y in p.list_parts_nesting)
            {

                TagBuilder Div = new TagBuilder("Div");
                int Top = y.y / K;
                int Left = y.x / K;
                int Length = y.Length / K;
                int width = y.width / K;
                Div.MergeAttribute("style", "position:absolute; bottom:" + Top.ToString() + "px;"
                    + " " + "left:" + Left.ToString() + "px;" + " " + "width:" + Length.ToString() + "px;" + " " + "height:" +
                    width.ToString() + "px;" + "border: 1px double black; margin:1px; background:blue");



                Div1.InnerHtml += Div.ToString();
            }
                Div2.InnerHtml += Div1.ToString();
            

            result.Append(Div2.ToString());
            return new MvcHtmlString(result.ToString());
        }

    }
}