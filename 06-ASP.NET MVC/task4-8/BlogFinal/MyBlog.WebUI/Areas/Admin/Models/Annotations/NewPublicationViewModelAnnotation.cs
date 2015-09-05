using MyBlog.WebUI.Areas.Admin.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlog.WebUI.Areas.Admin.Models
{
    [MetadataTypeAttribute(typeof(NewPublicationViewModel.NewPublicationViewModelMetadata))]
    [MustHaveTags(ErrorMessage = "У статьи нет ни одного тэга")]
    public partial class NewPublicationViewModel
    {
        internal sealed class NewPublicationViewModelMetadata
        {
            [Required(ErrorMessage = "Вы не ввели название")]
            public string Title { get; set; }
            [ArticleNotEmpty(ErrorMessage = "Статья не может быть пустой")]
            [NoScripts(ErrorMessage = "Статья не может содержать тег <script>")]
            public string ArticleText { get; set; }
            //[Required(ErrorMessage = "Вы не ввели ни одного тэга")]
            public string NewTags { get; set; }
            public IEnumerable<SelectListItem> Tags { get; set; }
        }
    }
}