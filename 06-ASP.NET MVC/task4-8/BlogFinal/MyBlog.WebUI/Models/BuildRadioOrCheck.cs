using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlog.WebUI.Models
{
    public class BuildRadioOrCheck
    {
        public List<String> Build(List<String> values, String name, bool checkBox)
        {
            List<String> elements = new List<String>();
            for (int i = 0; i < values.Count; i++)
            {
                TagBuilder input = new TagBuilder("input");
                if (checkBox)
                {
                    input.MergeAttribute("type", "checkbox");
                }
                else
                {
                    input.MergeAttribute("type", "radio");
                }
                input.MergeAttribute("name", name);
                input.MergeAttribute("value", values[i]);
                TagBuilder inputLabel = new TagBuilder("label");
                inputLabel.MergeAttribute("for", values[i]);
                inputLabel.SetInnerText(values[i]);
                String tmp = input.ToString() + inputLabel.ToString();
                elements.Add(tmp);
            }
            return elements;
        }
    }
}