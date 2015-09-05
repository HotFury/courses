using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Domain.Entities
{
    [MetadataTypeAttribute(typeof(AboutSelf.AboutSelfMetadata))]
    public partial class AboutSelf
    {
        internal sealed class AboutSelfMetadata
        {
            public int Id { get; set; }
            public int UserId { get; set; }
            [Required(ErrorMessage = "Вы не ввели имя")]
            public string Name { get; set; }
            public string Sex { get; set; }
            public string Hobbies { get; set; }
            public string About { get; set; }
        }
    }
}
