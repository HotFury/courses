using MyBlog.Domain.CodeFirst.PublicationEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;
using MyBlog.WebUI.Models;

namespace MyBlog.WebUI.Models.CodeFirst
{
    public class PublicationPreviewViewModel
    {
        private int previewSymbolsCount = 200;
        private int pageSize = 5;
        private int pageRange = 5;
        public PageInfo pageInfo;
        public List<Article> Articles { get; set; }
        public string GetPreview(Article article)
        {
            //delte html tags
            string cleanArticle = Regex.Replace(article.ArticleText, @"<[\/]*[p|span|strong|em|strike|ul|ol|li|blockquote|a href=].*?>", string.Empty);
            string preview = "";

            for (int i = 0; i < cleanArticle.Length; i++)
            {
                // get first n symbols
                if (i < previewSymbolsCount)
                {
                    preview += cleanArticle[i];
                }
                else
                {
                    break;
                }
            }
            return preview;
        }
        private List<String> voteText;
        public List<String> VoteRadio{get; set;}
        public PublicationPreviewViewModel(List<Article> articles, int pageNum)
        {
            this.Articles = articles.Skip((pageNum - 1) * pageSize).Take(pageSize).ToList();
            //making vote panel
            BuildRadioOrCheck radioBuilder = new BuildRadioOrCheck();
            voteText = new List<String> { "5", "4", "3", "2", "1" };
            VoteRadio = radioBuilder.Build(voteText, "vote", false);
            pageInfo = new PageInfo()
            {
                CurPage = pageNum,
                ItemsPerPage = pageSize,
                TotalItems = articles.Count,
                PageRange = pageRange
            };
        }

    }
}