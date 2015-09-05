using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Domain.Entities
{
     [MetadataTypeAttribute(typeof(Feedbacks.FeedbacksMetadata))]
    public partial class Feedbacks
    {
         internal sealed class FeedbacksMetadata
         {
             public int Id { get; set; }
             public int UserId { get; set; }
             [Required(ErrorMessage = "Обязательно напишите текст отзыва")]
             [Display(Name = "Текст отзыва:")]
             public string FeedbackText { get; set; }
             public string DateTime { get; set; }
         }
    }
}
